REM make sure you add 
REM C:\Program Files (x86)\Apache Software Foundation\Apache2.2\bin
REM to your path so ab.exe can be found
REM Start NowinSample.exe and have free port 8080

del *.txt
del AbParseResults.*

REM Warm up

ab.exe -n100 -c20 http://localhost:8080/test/person/ > NowinWebApiJson.txt
ab.exe -n20000 -c20 http://localhost:8080/test/person/ > NowinWebApiJson.txt

ab.exe -n100 -c20 http://localhost:8080/
ab.exe -n20000 -c20 http://localhost:8080/ > Nowin.txt

ab.exe -n100 -c20 http://localhost:8080/aspnetperf/handler.ashx 
ab.exe -n20000 -c20 http://localhost:8080/aspnetperf/handler.ashx > HttpHandler.txt

ab.exe -n100 -c20 http://localhost:8080/aspnetperf/Handler.ashx?action=json
ab.exe -n20000 -c20 http://localhost:8080/aspnetperf/Handler.ashx?action=json > HandlerJson.txt

ab.exe -n100 -c20 http://localhost:8080/aspnetperf/api/HelloWorldCode/ 
ab.exe -n20000 -c20 http://localhost:8080/aspnetperf/api/HelloWorldCode/ > WebApi.txt

ab.exe -n100 -c20 http://localhost:8080/aspnetperf/api/HelloWorldJson/ 
ab.exe -n20000 -c20 http://localhost:8080/aspnetperf/api/HelloWorldJson/ > WebApiJson.txt 

ab.exe -n100 -c20 http://localhost:8080/aspnetperf/MvcPerformance/HelloWorldCode/
ab.exe -n20000 -c20 http://localhost:8080/aspnetperf/MvcPerformance/HelloWorldCode/ > Mvc.txt

ab.exe -n100 -c20 http://localhost:8080/aspnetperf/MvcPerformance/HelloWorldJson
ab.exe -n20000 -c20 http://localhost:8080/aspnetperf/MvcPerformance/HelloWorldJson > MvcJson.txt

abParse -i"*.txt" -o"AbParseResults.html" -m"html"
abParse -i"*.txt" -o"AbParseResults.csv" -m"csv"
abParse -i"*.txt" -o"AbParseResults.xml" -m"xml"

abparseresults.html
