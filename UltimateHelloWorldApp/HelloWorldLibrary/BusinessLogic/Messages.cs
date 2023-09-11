using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

using HelloWorldLibrary.Models;

using Microsoft.Extensions.Logging;

namespace HelloWorldLibrary.BusinessLogic;

public class Messages : IMessages
{
    private readonly ILogger<Messages> log;

    public Messages(ILogger<Messages> log)
    {
        this.log = log;
    }

    public string Greeting(string language)
    {
        var output = LookUpCustomText(nameof(Greeting), language);
        return output;
    }

    private string LookUpCustomText(string key, string language)
    {
        var options = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true
        };

        try
        {
            var messageSets = JsonSerializer
                .Deserialize<List<CustomText>>
                (
                    File.ReadAllText("CustomText.json"), options
                );

            var messages = messageSets?.First(x => x.Language == language);

            if (messages is null)
            {
                throw new NullReferenceException("The specified language was not found in the json file.");
            }

            return messages.Translations[key];
        }
        catch (Exception ex)
        {

            log.LogError("Error looking up the custom text", ex);
            throw;
        }
    }
}
