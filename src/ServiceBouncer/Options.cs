using CommandLine;

namespace ServiceBouncer
{
    public class Options
    {
        [Option('m', "machine", HelpText = "The machine to initially connect to.", Hidden = false, Required = false)]
        public string Machine { get; set; }

        [Option('t', "terminateMinutes", HelpText = "The number of minutes of user inactivity before application terminates.", Hidden = false, Required = false)]
        public int? TerminationUserInactivityMinutes { get; set; }
    }
}
