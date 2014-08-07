Testing REST Services using RESTSharp
=====================


##Objective##
Intent of this project is to illustrate REST services testing using RESTSharp (http://restsharp.org/) in DotNet World

###This project illustrate four types of service tests###
* Contract Tests - Tests which would fail when contract changes
* Positive Tests - Tests which assert Json response
* Negative Tests - Tests which check for service response when invalid parameters are passed
* Boundary Tests - Tests which check behaviour of tests at boundary values of parameters


##Stack##
This C# project has been created using Visual Studio Express Edition. RESTSharp is included as nuget package. Tests have been written in NUnit.


Steps:
-------
   * Clone this repository
   * Open the solution
   * Rebuild
   * Open your test assembly's properties. For example, right-click on the assembly and select Properties. On the Application tab, select Output Type: Windows Application; and Startup Object: NUNitConolseRunner. On the Debug tab, enter the .csproj file name in Command Line Arguments; and browse to the folder of the .csproj file in Working Directory. Save everything. (This step is needed to execute tests within Visual Studio Express Only)
   * Run tests using F5 or the green arrow button.
