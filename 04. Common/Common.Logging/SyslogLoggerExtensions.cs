using Microsoft.Extensions.Logging;

namespace Common.Logging;

public static class SyslogLoggerExtensions
{
    public static ILoggerFactory AddSyslog(this ILoggerFactory factory,
                                    string host, int port,
                                    Func<string, LogLevel, bool> filter = null)
    {
        factory.AddProvider(new SyslogLoggerProvider(host, port, filter));
        return factory;
    }
}