using Microsoft.Extensions.Logging;

namespace HelloWorldLibrary.BusinessLogic;

public class Messages
{
    private readonly ILogger<Messages> log;

    public Messages(ILogger<Messages> log)
    {
        this.log=log;
    }
}
