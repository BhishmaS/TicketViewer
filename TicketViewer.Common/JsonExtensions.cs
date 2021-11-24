using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace TicketViewer.Common
{
    public static class JsonExtensions
    {
        #region ToJson

        public static string ToJson<T>(this T source) where T : class
        {
            return source == default(T) ? string.Empty : JsonConvert.SerializeObject(source);
        }

        public static string ToJson<T>(this T source, SerializerSettings jsonSerializerSettings) where T : class
        {
            return source == default(T) ? string.Empty : JsonConvert.SerializeObject(source, jsonSerializerSettings);
        }

        #endregion

        #region FromJson

        public static T FromJson<T>(this string str)
        {
            return string.IsNullOrWhiteSpace(str) ? default(T) : JsonConvert.DeserializeObject<T>(str);
        }

        public static T FromJson<T>(this string str, SerializerSettings jsonSerializerSettings)
        {
            return string.IsNullOrWhiteSpace(str) ? default(T) : JsonConvert.DeserializeObject<T>(str, jsonSerializerSettings);
        }

        public static object FromJson(this string str, Type type, SerializerSettings jsonSerializerSettings = null)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return null;
            }

            return jsonSerializerSettings != null ? JsonConvert.DeserializeObject(str, type, jsonSerializerSettings) : JsonConvert.DeserializeObject(str, type);
        }

        #endregion

        #region TryParseJson

        public static bool TryParseJson<T>(this string str)
        {
            try
            {
                var jsonObject = JsonConvert.DeserializeObject<T>(str);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion
    }

    public class SerializerSettings : JsonSerializerSettings
    {
        public static readonly SerializerSettings OBJECTTYPEHANDLINGSETTINGS = new SerializerSettings() { TypeNameHandling = TypeNameHandling.All };

        public static readonly SerializerSettings ARRAYTYPEHANDLINGSETTINGS = new SerializerSettings() { TypeNameHandling = TypeNameHandling.Auto, ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor };

        public static readonly SerializerSettings ARRAYTYPEHANDLINGSETTINGSWithCAMELCASECONTRACTRESOLVER = new SerializerSettings() { TypeNameHandling = TypeNameHandling.Auto, ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor, ContractResolver = new CamelCasePropertyNamesContractResolver() };
    }
}
