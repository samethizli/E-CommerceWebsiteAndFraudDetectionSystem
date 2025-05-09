using Newtonsoft.Json;

namespace Ekitap.WebUI.ExtensionMethods
{
    public static class SessionExtensionMethods
    {
        public static void SetJson(this ISession session,string key, object value)//json olarak tutup döndürücez
        {
            session.SetString(key, JsonConvert.SerializeObject(value));//önce jsona çevir
            
        }
        public static T? GetJson<T>(this ISession session, string key) where T : class
        {
            var data = session.GetString(key);//parametre olarak alınan keyi al ordaki sessiondaki datayı getir 
            
            return data == null ? default(T) : JsonConvert.DeserializeObject<T>(data);
        }
    }
}
