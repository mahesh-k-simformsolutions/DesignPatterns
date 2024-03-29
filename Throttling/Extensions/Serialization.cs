﻿using Newtonsoft.Json;
using System.Text;

namespace Throttling.Extensions;

public static class Serialization
{
    public static byte[] ToByteArray(this object objectToSerialize)
    {
        return objectToSerialize == null ? null : Encoding.Default.GetBytes(JsonConvert.SerializeObject(objectToSerialize));
    }

    public static T FromByteArray<T>(this byte[] arrayToDeserialize) where T : class
    {
        return arrayToDeserialize == null ? default : JsonConvert.DeserializeObject<T>(Encoding.Default.GetString(arrayToDeserialize));
    }
}

