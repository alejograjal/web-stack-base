﻿using Newtonsoft.Json;
using WebStackBase.Util.Converter;

namespace WebStackBase.Util;

public static class Serialization
{
    /// <summary>
    /// Serialize object into json
    /// </summary>
    /// <param name="request">Object to be serialized</param>
    /// <returns>string</returns>
    public static string Serialize<T>(T request) => JsonConvert.SerializeObject(request)!;

    /// <summary>
    /// Serialize json into object
    /// </summary>
    /// <param name="model">Json to be deserialize</param>
    /// <returns>T(Object)</returns>
    public static T Deserialize<T>(string model)
    {
        var settings = new JsonSerializerSettings();

        settings.Converters.Add(new DateOnlyJsonConverter());
        settings.Converters.Add(new TimeOnlyJsonConverter());

        return JsonConvert.DeserializeObject<T>(model, settings)!;
    }
}