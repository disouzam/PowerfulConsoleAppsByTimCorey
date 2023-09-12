using System;

using HelloWorldLibrary.BusinessLogic;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

using Xunit;

namespace HelloWorldTests.BusinessLogic;

public class MessagesTests
{
    [Fact]
    public void GreetingInEnglish()
    {
        ILogger<Messages> logger = new NullLogger<Messages>();

        var messages = new Messages(logger);

        var expected = "Hello World";
        var actual = messages.Greeting("en");

        Assert.Equal(expected, actual); 
    }

    [Fact]
    public void GreetingInSpanish()
    {
        ILogger<Messages> logger = new NullLogger<Messages>();

        var messages = new Messages(logger);

        var expected = "Hola Mundo";
        var actual = messages.Greeting("es");

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GreetingInValid()
    {
        ILogger<Messages> logger = new NullLogger<Messages>();

        var messages = new Messages(logger);

        var expected = "Hola Mundo";
        var actual = messages.Greeting("es");

        Assert.Throws<InvalidOperationException>
        (
            () => messages.Greeting("fr")
        );
    }
}
