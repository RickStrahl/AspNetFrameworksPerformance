#ASP.NET Framework Performance Tests

Sample code for post at:
[ASP.NET Frameworks and Raw Throughput Performance](http://www.west-wind.com/weblog/)


This is a small sample project that contains simple HelloWorld and HelloWorldJson 
type requests for several of ASP.NET's frameworks including:

* HttpHandlers
* WebForms
* MVC
* WebPages
* WCF REST
* Web API
* Helios Server (pre-alpha)
* Web API Self-Host

It uses Apache's Benchmark tool (ab.exe) to test raw throughput performance
running tests into text files for comparison.

AB Benchmark Testing Setup

If you want to run these examples, they are set up to run in full IIS as that's
the most realistic way to test performance. 

In order to do this:

* You need to use IIS
* Create an ApplicationPool for AspNetPerformance and set host permissions to NetworkService or System
* Set up a virtual directory for AspNetPerf and set to the AppPool
* For Helios set up another AppPool (Helios) and virtual directory HeliosSample
* For Self-Host run SelfHost.exe out of SelfHost\bin\Release folder
  Then uncomment the self-host tests on the bottom in ab_Helios.bat
* Go to the LoadTests folder
* Run the ab_perftests.bat or ab_helios.bat files as an Administrator
* Best to open an Admin command prompt and run from there