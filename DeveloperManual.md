Developer Manual

The following programs are required for this project to run:

- GitHub + Git Shell

Install information for Windows:

- Go to https://windows.github.com/ and download GitHub for Windows (GitHub + Git Shell).
- Please be noted that the repository is private and needs authorization to be cloned.
- Clone this repo to your computer: https://github.com/hilmario10/UnityGame
- If Git Shell does not recognize git command you need to add: (example: C:\Program Files (x86)\Git\bin;) to the windows path.

Gradle setup guide for Windows:

- Extract gradle-2.1-all.zip
- Move the unzipped folder to C:\Program Files
- Add C:\Program Files\Gradle\gradle2.1\bin; to the windows path
- Open Git Shell and add a file gradle.properties under the .gradle folder in your home directory and add the following line org.gradle.daemon=true: echo "org.gradle.daemon=true" > ~/.gradle/gradle.properties
- If Git Shell cannot find System Java Compiler, ensure that you have installed a JDK (not just a JRE) and configured your JAVA_HOME system variable to point to the according directory. You may have to add %JAVA_HOME%\bin; to the windows path.
