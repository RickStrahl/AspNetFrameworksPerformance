REM make sure you add 
REM C:\Program Files (x86)\Apache Software Foundation\Apache2.2\bin
REM to your path so ab.exe can be found
REM make sure you run as Administrator for IISRESET to work

REM If you want to test self-hosted Web API uncomment the last
REM tests below and make sure to start SELFHOST.EXE from the
REM project with the same name's BIN\RELEASE folder.

del *.txt
del AbParseResults.*

REM Warm up

IISRESET
ab.exe -n20 http://localhost/HeliosSample/
ab.exe -n40000 -c20 http://localhost/HeliosSample/ > Helios.txt

IISRESET
ab.exe -n20 http://localhost/HeliosSample/test/person/ 
ab.exe -n40000 -c20 http://localhost/HeliosSample/test/person/ > HeliosWebApiJson.txt

IISRESET
ab.exe -n20 http://localhost/aspnetperf/api/HelloWorldCode/ 
ab.exe -n40000 -c20 http://localhost/aspnetperf/api/HelloWorldCode/ > WebApiStringResult.txt

iisreset 
ab.exe -n20 http://localhost/aspnetperf/api/helloworldjson/ 
ab.exe -n40000 -c20 http://localhost/aspnetperf/api/helloworldjson/ > webapijsonTypedResult.txt 

iisreset 
ab.exe -n20 http://localhost/aspnetperf/api/HelloWorldJsonCreateResponse/ 
ab.exe -n40000 -c20 http://localhost/aspnetperf/api/HelloWorldJsonCreateResponse/ > WebApiJsonHttpCreateResponse.txt 

iisreset 
ab.exe -n20 http://localhost/aspnetperf/api/HelloWorldJsonManualResponse/ 
ab.exe -n40000 -c20 http://localhost/aspnetperf/api/HelloWorldJsonManualResponse/ > WebApiJsonManualResponse.txt 

IISRESET
ab.exe -n20 -c20 http://localhost/aspnetperf/handler.ashx 
ab.exe -n40000 -c20 http://localhost/aspnetperf/handler.ashx > HttpHandler.txt

IISRESET
ab.exe -n20 -c20 http://localhost/aspnetperf/Handler.ashx?action=json
ab.exe -n40000 -c20 http://localhost/aspnetperf/Handler.ashx?action=json > HandlerJson.txt

IISRESET
ab.exe -n20 -c20 http://localhost/aspnetperf/MvcPerformance/HelloWorldCode/
ab.exe -n40000 -c20 http://localhost/aspnetperf/MvcPerformance/HelloWorldCode/ > Mvc.txt

IISRESET
ab.exe -n20 http://localhost/aspnetperf/MvcPerformance/HelloWorldJson
ab.exe -n40000 -c20 http://localhost/aspnetperf/MvcPerformance/HelloWorldJson > MvcJson.txt

REM *** IMPORTANT:
REM In order to run these run SelfHost.exe from the SelfHost project first
REM ab.exe -n20 http://localhost:9000/
REM ab.exe -n40000 -c20 http://localhost:9000/ > SelfHost.txt

REM ab.exe -n20 http://localhost:9000/test/HelloWorldJson/ 
REM ab.exe -n40000 -c20 http://localhost:9000/test/HelloWorldJson/ > SelfHostJson.txt 

abParse -i"*.txt" -o"AbParseResults.html" -m"html"
abParse -i"*.txt" -o"AbParseResults.csv" -m"csv"
abParse -i"*.txt" -o"AbParseResults.xml" -m"xml"

abparseresults.html