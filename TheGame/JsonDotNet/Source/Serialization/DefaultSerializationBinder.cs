#if !UNITY_WINRT || UNITY_EDITOR || UNITY_WP8
#region License
// Copyright (c) 2007 James Newton-King
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
#endregion

using System;
using System.Runtime.Serialization;
using System.Reflection;
using System.Globalization;
using Newtonsoft.Json.Utilities;
#pragma warning disable 436
namespace Newtonsoft.Json.Serialization
{
  /// <summary>
  /// The default serialization binder used when resolving and loading classes from type names.
  /// </summary>
  public class DefaultSerializationBinder : SerializationBinder
  {
    internal static readonly DefaultSerializationBinder Instance = new DefaultSerializationBinder();

    private readonly ThreadSafeStore<TypeNameKey, Type> _typeCache = new ThreadSafeStore<TypeNameKey, Type>(GetTypeFromTypeNameKey);

    private static Type GetTypeFromTypeNameKey(TypeNameKey typeNameKey)
    {
      string assemblyName = typeNameKey.AssemblyName;
      string typeName = typeNameKey.TypeName;

      if (assemblyName != null)
      {
        Assembly assembly;

#if !UNITY_WP8 && !UNITY_WEBPLAYER &&  (!UNITY_WINRT || UNITY_EDITOR) && !UNITY_ANDROID
        // look, I don't like using obsolete methods as much as you do but this is the only way
        // Assembly.Load won't check the GAC for a partial name
#pragma warning disable 618,612
        assembly = Assembly.LoadWithPartialName(assemblyName);
#pragma warning restore 618,612
#else
        assembly = Assembly.Load(assemblyName);
#endif

        if (assembly == null)
          throw new JsonSerializationException("Could not load assembly '{0}'.".FormatWith(CultureInfo.InvariantCulture, assemblyName));

        Type type = assembly.GetType(typeName);
        if (type == null)
          throw new JsonSerializationException("Could not find type '{0}' in assembly '{1}'.".FormatWith(CultureInfo.InvariantCulture, typeName, assembly.FullName));

        return type;
      }
      else
      {
        return Type.GetType(typeName);
      }
    }

    internal struct TypeNameKey 
#if !(UNITY_ANDROID || (UNITY_IOS || UNITY_IPHONE))
		: IEquatable<TypeNameKey>
#endif
    {
      internal readonly string AssemblyName;
      internal readonly string TypeName;

      public TypeNameKey(string assemblyName, string typeName)
      {
        AssemblyName = assemblyName;
        TypeName = typeName;
      }

      public override int GetHashCode()
      {
        return ((AssemblyName != null) ? AssemblyName.GetHashCode() : 0) ^ ((TypeName != null) ? TypeName.GetHashCode() : 0);
      }

      public override bool Equals(object obj)
      {
        if (!(obj is TypeNameKey))
          return false;

        return Equals((TypeNameKey)obj);
      }

      public bool Equals(TypeNameKey other)
      {
        return (AssemblyName == other.AssemblyName && TypeName == other.TypeName);
      }
    }

    /// <summary>
    /// When overridden in a derived class, controls the binding of a serialized object to a type.
    /// </summary>
    /// <param name="assemblyName">Specifies the <see cref="T:System.Reflection.Assembly"/> name of the serialized object.</param>
    /// <param name="typeName">Specifies the <see cref="T:System.Type"/> name of the serialized object.</param>
    /// <returns>
    /// The type of the object the formatter creates a new instance of.
    /// </returns>
    public override Type BindToType(string assemblyName, string typeName)
    {
      return _typeCache.Get(new TypeNameKey(assemblyName, typeName));
    }
  }
}
#pragma warning restore 436
#endif