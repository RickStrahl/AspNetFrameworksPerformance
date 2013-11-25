using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Westwind.Utilities;
using Westwind.Utilities.System;


namespace AbParse
{
    class Program
    {
        static void Main(string[] args)
        {
            var cl = new AbParseCommandLineParser();
            cl.Parse();

            Console.WriteLine("*** Apache Bench Output Parser\r\n\n");


            if (cl.IsHelp)
            {
                string syntax = @"
Usage:

AbParse -i""InputFilePathOrWildCard"" -o""OutputFile"" -m""OutputMode""

    -i - Input file or WildCard to match output generated from ab.exe
    -o - Filename for the output generated
    -m - Output Mode: html,csv, xml
";
                Console.WriteLine(syntax);
                return;
            }

            if (string.IsNullOrEmpty(cl.InputFilePath))
            {
                Console.WriteLine("Input filename is required. Please use the -i switch to specify a file or wildcard path");
                return;
            }
                
            ParseFiles(cl);

        }

        public static void ParseFiles(AbParseCommandLineParser cl)
        {            
            var path = Path.GetDirectoryName(cl.InputFilePath);
            if (path == string.Empty) 
                path = ".\\";
            var fileName = Path.GetFileName(cl.InputFilePath);            
            var files = Directory.GetFiles(path,fileName);
            var testInfoList = new List<TestInfo>();

            foreach (var file in files)
            {
                var testInfo = new TestInfo();

                var lines = File.ReadAllLines(file);
                testInfo.RequestName = Path.GetFileNameWithoutExtension(file);

                foreach (var line in lines)
                {
                    //Requests per second:    174.14 [#/sec] (mean)
                    if (line.StartsWith("Requests per"))
                    {
                        var req = StringUtils.ExtractString(line, ":", "[");
                        req = req.Trim();
                        decimal rps = 0;
                        decimal.TryParse(req, NumberStyles.Any, NumberFormatInfo.InvariantInfo, out rps);
                        testInfo.RequestsPerSecond = rps;
                    }

                }
                testInfoList.Add(testInfo);
                
            }

            WriteOutput(testInfoList,cl);
        }

        public static void WriteOutput(List<TestInfo> testInfoList, AbParseCommandLineParser cl)
        {
            var sb = new StringBuilder();
            if (cl.OutputMode == "html")
            {
                WriteHtmlOutput(testInfoList, sb);
                cl.OutputFile = Path.ChangeExtension(cl.OutputFile, "html");
            }
            else if (cl.OutputMode == "xml")
            {
                WriteXmlOutput(testInfoList, sb);
                cl.OutputFile = Path.ChangeExtension(cl.OutputFile, "xml");
            }
            else
            {
                WriteCsvOutput(testInfoList, sb);
                cl.OutputFile = Path.ChangeExtension(cl.OutputFile, "csv");
            }
            
            File.WriteAllText(cl.OutputFile, sb.ToString());
        }
        private static void WriteHtmlOutput(List<TestInfo> testInfoList, StringBuilder sb)
        {
            string html = @"<!DOCTYPE HTML>
    <html>
    <head>
        <style>
            body { font-family: verdana; }
            td { padding: 5px; }
        </style>
    </head>
    <body>
    <h1>Apache Bench Test Results</h1>
    <small><i>Requests per second</i></small>
    <hr />    
";

            sb.AppendLine(html);
            sb.AppendLine("<table>");
            foreach (var testInfo in testInfoList.OrderByDescending(ti => ti.RequestsPerSecond))
            {
                sb.AppendLine("\t<tr>");

                sb.AppendLine("\t\t<td>" + testInfo.RequestName + "</td>");
                sb.AppendLine("\t\t<td>" + testInfo.RequestsPerSecond.ToString("n2") + "</td>");

                sb.AppendLine("\t</tr>");

            }



            sb.AppendLine("</table>");
            sb.AppendLine("</body>\r\n</html>");
        }
        private static void WriteXmlOutput(List<TestInfo> testInfoList, StringBuilder sb)
        {
            // serialize to Xml
            var xml = SerializationUtils.SerializeObjectToString(testInfoList);
            sb.Append(xml);
            return;

            sb.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            sb.AppendLine("<testResults>");

            foreach (var testInfo in testInfoList.OrderByDescending(ti => ti.RequestsPerSecond))
            {
                sb.AppendLine("\t<testInfo>");

                sb.Append("\t\t<requestName>");
                sb.Append(testInfo.RequestName);
                sb.AppendLine("</requestName>");

                sb.Append("\t\t<requestsPerSecond>");
                sb.Append(testInfo.RequestsPerSecond.ToString());
                sb.AppendLine("</requestsPerSecond>");

                sb.AppendLine("\t</testInfo>");
            }

            sb.AppendLine("</testResults>");            
        }
        private static void WriteCsvOutput(List<TestInfo> testInfoList, StringBuilder sb)
        {
            sb.AppendLine("RequestName,RequestsPerSecond");
            foreach (var testInfo in testInfoList.OrderByDescending(ti => ti.RequestsPerSecond))
            {
                sb.Append(testInfo.RequestName + ",");
                sb.AppendLine(testInfo.RequestsPerSecond.ToString());
            }            
        }
    }

    public class TestInfo
    {
        public string RequestName { get; set; }
        public decimal RequestsPerSecond { get; set; }

    }

    public class AbParseCommandLineParser : CommandLineParser
    {
        public string InputFilePath { get; set; }
        public string OutputFile { get; set; }
        public string OutputMode { get; set; }
        public bool IsHelp { get; set; }

        public override void Parse()
        {
            InputFilePath = ParseStringParameterSwitch("-i");
            OutputFile = ParseStringParameterSwitch("-o","AbParseResults.html");
            OutputMode = ParseStringParameterSwitch("-m","html");
            this.IsHelp = ParseParameterSwitch("-h");            
        }
    }

}
