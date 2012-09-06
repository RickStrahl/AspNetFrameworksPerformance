using System;
using System.Collections.Generic;

namespace Westwind.Utilities.System
{
    /// <summary>
    /// Basic Command Line Parser class that can deal with simple
    /// switch based command line arguments
    /// 
    /// supports: FirstParm (first commandline argume
    /// -pString or -p"String"
    /// -f     switch/flag parameters
    /// </summary>
    public abstract class CommandLineParser
    {
        /// <summary>
        /// The Command Line arguments string array
        /// </summary>
        public string[] args {get; set;}

        /// <summary>
        /// The full command line including the executable
        /// </summary>
        public string CommandLine  {get; set;}

        /// <summary>
        /// The first argument (if any). Useful for a 
        /// command/action parameter
        /// </summary>
        public string FirstParm  {get; set;} 

        public CommandLineParser()
        {
            CommandLine = Environment.CommandLine;
            List<string> argList = new List<string>(Environment.GetCommandLineArgs());

            if (argList.Count > 1)
            {
                FirstParm = argList[1];

                // argument array contains startup exe - remove
                argList.RemoveAt(0);
                args = argList.ToArray();
            }
            else
            {
                FirstParm = string.Empty;
                // empty array - not null to match args array
                args = new string[0];
            }
        }

        /// <summary>
        /// Override to provide parse switches\parameter
        /// into object structure
        /// </summary>
        public abstract void Parse();
 

        /// <summary>
        /// Parses a string Parameter switch in the format of:
        /// 
        /// -p"c:\temp files\somefile.txt"
        /// -pc:\somefile.txt
        /// 
        /// Note no spaces are allowed between swich and value.
        /// </summary>        
        /// <param name="parm">parameter switch key</param>
        /// <param name="defaultValue">value returned if switch is not found</param>
        /// <returns>The value of the switch. If not found defaultValue (null by default) is returned</returns>
        protected string ParseStringParameterSwitch(string parm, string defaultValue = null)
        {
            int at = CommandLine.IndexOf(parm,0,StringComparison.OrdinalIgnoreCase);            

            if (at > -1)
            {
                string rest = CommandLine.Substring(at + parm.Length);
                
                if (rest.StartsWith("\""))
                {
                    // read to end quote
                    at = rest.IndexOf('"',2);
                    if (at == -1)
                        return CommandLine;

                    return rest.Substring(1,at-1);
                }
                else if (rest == " ")
                {
                    // no spaces after parameters
                    return CommandLine;
                }
                else
                {
                    // read to end quote
                    at = (rest + " ").IndexOf(' ', at + 1);
                    if (at == -1)
                        return CommandLine;

                    return rest.Substring(0, at - 1);
                }
            }

            return defaultValue;
        }

        protected bool ParseParameterSwitch(string parm)
        {
            int at = CommandLine.IndexOf(parm,0,StringComparison.OrdinalIgnoreCase);

            if (at > -1)
                return true;

            return false;
        }
    }
}
