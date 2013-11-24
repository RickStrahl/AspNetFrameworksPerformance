REM make sure you add 
REM C:\Program Files (x86)\Apache Software Foundation\Apache2.2\bin
REM to your path so ab.exe can be found

REM make sure you run as Administrator for IISRESET to work
IISRESET

del *.txt
del AbParseResults.*

REM Warm up
ab.exe -n100 -c20 http://localhost/aspnetperf/MvcPerformance/HelloWorldJson
ab.exe -n100 -c20 http://localhost/aspnetperf/api/HelloWorldJson
ab.exe -n100 -c20 http://localhost/AspNetPerf/WcfService.svc/HelloWorld
ab.exe -n100 -c20 http://localhost/HeliosSample/


ab.exe -n20000 -c20 http://localhost/aspnetperf/handler.ashx > HttpHandler.txt
ab.exe -n20000 -c20 http://localhost/aspnetperf/api/HelloWorldCode > WebApi.txt
ab.exe -n20000 -c20 http://localhost/aspnetperf/MvcPerformance/HelloWorldCode > Mvc.txt

ab.exe -n20000 -c20 http://localhost/aspnetperf/HelloWorld_CodeBehind.aspx > AspxCodeBehind.txt
ab.exe -n20000 -c20 http://localhost/aspnetperf/HelloWorld_Markup.aspx > AspxMarkup.txt
ab.exe -n20000 -c20 http://localhost/aspnetperf/HelloWorld.cshtml > WebPages.txt
ab.exe -n20000 -c20 http://localhost/AspNetPerf/WcfService.svc/HelloWorld > Wcf.txt

IISRESET

REM JSON RESPONSES

ab.exe -n20000 -c20 http://localhost/aspnetperf/Handler.ashx?action=json > HandlerJson.txt
ab.exe -n20000 -c20 http://localhost/aspnetperf/api/HelloWorldJson > WebApiJson.txt 

ab.exe -n20000 -c20 http://localhost/aspnetperf/MvcPerformance/HelloWorldJson > MvcJson.txt
ab.exe -n20000 -c20 http://localhost/AspNetPerf/WcfService.svc/HelloWorldJson > WcfJson.txt

IISRESET
ab.exe -n100 -c20 http://localhost/AspNetPerf/WestWindCallbackHandler.ashx?Method=HelloWorldJson 
ab.exe -n20000 -c20 http://localhost/AspNetPerf/WestWindCallbackHandler.ashx?Method=HelloWorldJson > WestWindCallbackJson.txt

IISRESET
ab.exe -n100 -c20 http://localhost/AspNetPerf/WestWindCallbackHandler.ashx?Method=HelloWorld
ab.exe -n20000 -c20 http://localhost/AspNetPerf/WestWindCallbackHandler.ashx?Method=HelloWorld > WestWindCallbackJson.txt

abParse -i"*.txt" -o"AbParseResults.html" -m"html"
abParse -i"*.txt" -o"AbParseResults.csv" -m"csv"
abParse -i"*.txt" -o"AbParseResults.xml" -m"xml"

abparseresults.html