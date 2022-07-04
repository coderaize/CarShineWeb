using Newtonsoft.Json;

namespace CarShineWeb.Converters
{
    public static class Json
    {
        public static string SerializeObject(object T)
        {
            return JsonConvert.SerializeObject(T);
        }

        public static T DesrializeObject<T>(string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }

    }
}
