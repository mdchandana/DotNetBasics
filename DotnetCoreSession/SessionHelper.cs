using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;


namespace DotnetCoreSession
{
    public static class SessionHelper
    {



        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);

            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }







        //public static void Add<T>(this ISession iSession, string key, T data)
        //{
        //    string serializedData = JsonConvert.SerializeObject(data);
        //    iSession.SetString(key, serializedData);
        //}
        //public static T Get<T>(this ISession iSession, string key)
        //{
        //    var data = iSession.GetString(key);
        //    return data == null ? default(T) : JsonConvert.DeserializeObject<T>(data);            
        //}



        //public static void SetObjectAsJson1<T>(this ISession iSession, string key, T data)
        //{
        //    string serializedData = JsonConvert.SerializeObject(data);
        //    iSession.SetString(key, serializedData);
        //}
        //public static T GetObjectFromJson<T>(this ISession iSession, string key)
        //{
        //    var data = iSession.GetString(key);
        //    return data == null ? default(T) : JsonConvert.DeserializeObject<T>(data);
        //}


        //public static void SetObjectAsJson(this ISession session, string key, object value)
        //{
        //    session.SetString(key, JsonConvert.SerializeObject(value));
        //}

        //public static T GetObjectFromJson<T>(this ISession session, string key)
        //{
        //    var value = session.GetString(key);
        //    return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        //}
    }
}


