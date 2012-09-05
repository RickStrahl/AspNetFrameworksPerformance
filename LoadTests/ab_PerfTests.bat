IISRESET

REM make sure you add 
REM C:\Program Files (x86)\Apache Software Foundation\Apache2.2\bin
REM to your path so ab.exe can be found

REM Warm up
ab.exe -n100 -c20 http://localhost/aspnetperf/MvcPerformance/HelloWorldJson > MvcJson.txt
ab.exe -n100 -c20 http://localhost/aspnetperf/api/HelloWorldJson > WebApiJson.txt
ab.exe -n100 -c20 http://localhost/AspNetPerf/WcfService.svc/HelloWorld > WcfJson.txt

ab.exe -n100000 -c20 http://localhost/aspnetperf/handler.ashx > handler.txt
ab.exe -n100000 -c20 http://localhost/aspnetperf/HelloWorld_CodeBehind.aspx > AspxCodeBehind.txt
ab.exe -n100000 -c20 http://localhost/aspnetperf/HelloWorld_Markup.aspx > AspxMarkup.txt
ab.exe -n100000 -c20 http://localhost/aspnetperf/HelloWorld.cshtml > WebPages.txt
ab.exe -n100000 -c20 http://localhost/AspNetPerf/WcfService.svc/HelloWorld > Wcf.txt
ab.exe -n100000 -c20 http://localhost/aspnetperf/MvcPerformance/HelloWorldCode > Mvc.txt
ab.exe -n100000 -c20 http://localhost/aspnetperf/api/HelloWorld > WebApi.txt
ab.exe -n100000 -c20 http://localhost/AspNetPerf/WestWindCallbackHandler.ashx?Method=HelloWorld > WestWindCallback.txt
ab.exe -n100000 -c20 http://localhost/AspNetPerf/nancy/HelloWorldCode > NancyCode.txt

REM JSON RESPONSES
ab.exe -n100000 -c20 http://localhost/aspnetperf/Handler.ashx?action=json > HandlerJson.txt
ab.exe -n100000 -c20 http://localhost/aspnetperf/MvcPerformance/HelloWorldJson > MvcJson.txt
ab.exe -n100000 -c20 http://localhost/aspnetperf/api/HelloWorldJson > WebApiJson.txt 
ab.exe -n100000 -c20 http://localhost/AspNetPerf/WcfService.svc/HelloWorldJson > WcfJson.txt
ab.exe -n100000 -c20 http://localhost/AspNetPerf/WestWindCallbackHandler.ashx?Method=HelloWorldJson > WestWindCallbackJson.txt
ab.exe -n100000 -c20 http://localhost/AspNetPerf/nancy/HelloWorldCode > NancyJson.txt

pause