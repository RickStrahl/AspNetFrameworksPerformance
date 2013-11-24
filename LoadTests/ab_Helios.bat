REM make sure you add 
REM C:\Program Files (x86)\Apache Software Foundation\Apache2.2\bin
REM to your path so ab.exe can be found
REM make sure you run as Administrator for IISRESET to work

del *.txt
del AbParseResults.*

REM Warm up

IISRESET
ab.exe -n100 -c20 http://localhost/HeliosSample/test/person/ > HeliosWebApiJson.txt
ab.exe -n20000 -c20 http://localhost/HeliosSample/test/person/ > HeliosWebApiJson.txt

IISRESET
ab.exe -n100 -c20 http://localhost/HeliosSample/
ab.exe -n20000 -c20 http://localhost/HeliosSample/ > Helios.txt


IISRESET
ab.exe -n100 -c20 http://localhost/aspnetperf/handler.ashx 
ab.exe -n20000 -c20 http://localhost/aspnetperf/handler.ashx > HttpHandler.txt

IISRESET
ab.exe -n100 -c20 http://localhost/aspnetperf/Handler.ashx?action=json
ab.exe -n20000 -c20 http://localhost/aspnetperf/Handler.ashx?action=json > HandlerJson.txt

IISRESET
ab.exe -n100 -c20 http://localhost/aspnetperf/api/HelloWorldCode/ 
ab.exe -n20000 -c20 http://localhost/aspnetperf/api/HelloWorldCode/ > WebApi.txt

IISRESET 
ab.exe -n100 -c20 http://localhost/aspnetperf/api/HelloWorldJson/ 
ab.exe -n20000 -c20 http://localhost/aspnetperf/api/HelloWorldJson/ > WebApiJson.txt 

IISRESET
ab.exe -n100 -c20 http://localhost/aspnetperf/MvcPerformance/HelloWorldCode/
ab.exe -n20000 -c20 http://localhost/aspnetperf/MvcPerformance/HelloWorldCode/ > Mvc.txt

IISRESET
ab.exe -n100 -c20 http://localhost/aspnetperf/MvcPerformance/HelloWorldJson
ab.exe -n20000 -c20 http://localhost/aspnetperf/MvcPerformance/HelloWorldJson > MvcJson.txt


abParse -i"*.txt" -o"AbParseResults.html" -m"html"
abParse -i"*.txt" -o"AbParseResults.csv" -m"csv"
abParse -i"*.txt" -o"AbParseResults.xml" -m"xml"

abparseresults.html
