using Newtonsoft.Json;

namespace TicketViewer.Common
{
    public static class JsonExtensions
    {
        #region ToJson

        public static string ToJson<T>(this T source) where T : class
        {
            return source == default(T) ? string.Empty : JsonConvert.SerializeObject(source);
        }

        #endregion

        #region FromJson

        public static T FromJson<T>(this string str)
        {
            return string.IsNullOrWhiteSpace(str) ? default(T) : JsonConvert.DeserializeObject<T>(str);
        }

        #endregion
    }
}
