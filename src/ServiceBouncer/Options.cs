using CommandLine;

namespace ServiceBouncer
{
    public class Options
    {
        [Option('m', "machine", HelpText = "The machine to initially connect to.", Hidden = false, Required = false)]
        public string Machine { get; set; }
    }
}
