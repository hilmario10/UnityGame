Developer Manual

The following programs are required for this project to run:

- GitHub + Git Shell
- Gradle 2.1
- Java SE Development Kit (JDK) 7/8

Install information for Windows:

- Go to https://windows.github.com/ and download GitHub for Windows (GitHub + Git Shell).
- Clone this repo to your computer: https://github.com/hilmario10/Sidannaverkefni
- If Git Shell does not recognize git command you need to add: (example: C:\Program Files (x86)\Git\bin;) to the windows path.
- Go to http://gradle.org/downloads and download gradle-2.1-all.zip.

Gradle setup guide for Windows:

- Extract gradle-2.1-all.zip
- Move the unzipped folder to C:\Program Files
- Add C:\Program Files\Gradle\gradle2.1\bin; to the windows path
- Open Git Shell and add a file gradle.properties under the .gradle folder in your home directory and add the following line org.gradle.daemon=true: echo "org.gradle.daemon=true" > ~/.gradle/gradle.properties
- If Git Shell cannot find System Java Compiler, ensure that you have installed a JDK (not just a JRE) and configured your JAVA_HOME system variable to point to the according directory. You may have to add %JAVA_HOME%\bin; to the windows path.


Install information for Linux:

- To get Git setup type:
		
		$ sudo apt-get install git

- Clone this repo to the machine:

		https://github.com/hilmario10/Sidannaverkefni

Gradle setup:
- Gradle that is installable via “apt-get” on the GreenQloud servers is Gradle 1.4, to update to a newer version the following must be done:

- 1.Add the following software: software-properties-common

		sudo apt-get install software-properties-common

		If you have issues with that run: 
		sudo apt-get install python-software-common

- 2.Add the following apt-repo: ppa:cwchien/gradle

		sudo add-apt-repository ppa:cwchien/gradle

- 3.Update sources:

		sudo apt-get update

- 4.Install new Gradle version:

		sudo apt-get install gradle

You should now have Gradle 2.1 installed.
