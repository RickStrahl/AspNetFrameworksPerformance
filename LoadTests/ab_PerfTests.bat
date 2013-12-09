REM Run as Administrator so that IISRESET Works

REM If you want to test self-hosted Web API uncomment the last
REM tests below and make sure to start SELFHOST.EXE from the
REM project with the same name's BIN\RELEASE folder.

REM make sure you run as Administrator for IISRESET to work

del *.txt
del AbParseResults.*

IISRESET
ab.exe -n20 http://localhost/aspnetperf/handler.ashx
ab.exe -n40000 -c20 http://localhost/aspnetperf/handler.ashx > HttpHandler.txt

IISRESET
ab.exe -n20 http://localhost/aspnetperf/api/HelloWorldCode 
ab.exe -n40000 -c20 http://localhost/aspnetperf/api/HelloWorldCode > WebApi.txt

IISRESET
ab.exe -n20 http://localhost/aspnetperf/MvcPerformance/HelloWorldCode > Mvc.txt
ab.exe -n40000 -c20 http://localhost/aspnetperf/MvcPerformance/HelloWorldCode > Mvc.txt

IISRESET
ab.exe -n20 http://localhost/aspnetperf/HelloWorld_CodeBehind.aspx
ab.exe -n40000 -c20 http://localhost/aspnetperf/HelloWorld_CodeBehind.aspx > AspxCodeBehind.txt

IISRESET
ab.exe -n20 -c20 http://localhost/aspnetperf/HelloWorld_Markup.aspx > AspxMarkup.txt
ab.exe -n40000 -c20 http://localhost/aspnetperf/HelloWorld_Markup.aspx > AspxMarkup.txt


IISRESET
ab.exe -n20 http://localhost/aspnetperf/HelloWorld.cshtml
ab.exe -n40000 -c20 http://localhost/aspnetperf/HelloWorld.cshtml > WebPages.txt

IISRESET
ab.exe -n20 http://localhost/AspNetPerf/WcfService.svc/HelloWorld 
ab.exe -n40000 -c20 http://localhost/AspNetPerf/WcfService.svc/HelloWorld > Wcf.txt


REM JSON RESPONSES

IISRESET
ab.exe -n20 http://localhost/aspnetperf/Handler.ashx?action=json
ab.exe -n40000 -c20 http://localhost/aspnetperf/Handler.ashx?action=json > HandlerJson.txt

IISRESET
ab.exe -n20 http://localhost/aspnetperf/api/HelloWorldJsonTypedResult 
ab.exe -n40000 -c20 http://localhost/aspnetperf/api/HelloWorldJsonTypedResult > WebApiJsonTypedResult.txt 

IISRESET
ab.exe -n20 http://localhost/aspnetperf/api/HelloWorldJsonCreateResponse
ab.exe -n40000 -c20 http://localhost/aspnetperf/api/HelloWorldJsonCreateResponse > WebApiJsonCreateResponse.txt 

IISRESET
ab.exe -n20 http://localhost/aspnetperf/MvcPerformance/HelloWorldJson
ab.exe -n40000 -c20 http://localhost/aspnetperf/MvcPerformance/HelloWorldJson > MvcJson.txt

IISRESET
ab.exe -n20 http://localhost/AspNetPerf/WcfService.svc/HelloWorldJson
ab.exe -n40000 -c20 http://localhost/AspNetPerf/WcfService.svc/HelloWorldJson > WcfJson.txt


REM *** IMPORTANT:
REM In order to run these run SelfHost.exe from the SelfHost project first
REM ab.exe -n20 http://localhost:9000/
REM ab.exe -n40000 -c20 http://localhost:9000/ > SelfHost.txt

REM ab.exe -n20 http://localhost:9000/test/HelloWorldJson/ 
REM ab.exe -n40000 -c20 http://localhost:9000/test/HelloWorldJson/ > SelfHostJson.txt 


REM West Wind Callback Handler 
REM IISRESET
REM ab.exe -n20 http://localhost/AspNetPerf/WestWindCallbackHandler.ashx?Method=HelloWorldJson 
REM ab.exe -n40000 -c20 http://localhost/AspNetPerf/WestWindCallbackHandler.ashx?Method=HelloWorldJson > WestWindCallbackJson.txt

REM IISRESET
REM ab.exe -n20 http://localhost/AspNetPerf/WestWindCallbackHandler.ashx?Method=HelloWorld
REM ab.exe -n40000 -c20 http://localhost/AspNetPerf/WestWindCallbackHandler.ashx?Method=HelloWorld > WestWindCallbackJson.txt

abParse -i"*.txt" -o"AbParseResults.html" -m"html"
abParse -i"*.txt" -o"AbParseResults.csv" -m"csv"
abParse -i"*.txt" -o"AbParseResults.xml" -m"xml"

abparseresults.html