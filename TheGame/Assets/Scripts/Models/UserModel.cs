using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using ProjectLokaverkefni.Models.Transfer;

namespace ProjectLokaverkefni.Models.Transfer
{
	
	public class UserModel 
	{
 		public int userid { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string city { get; set; }
        public string postalcode { get; set; }
        public string ssn { get; set; }
        public string phone { get; set; }
        public string gender { get; set; }
        public string passwordhash { get; set; }
        public int scenesCleared { get; set; }


    }
}