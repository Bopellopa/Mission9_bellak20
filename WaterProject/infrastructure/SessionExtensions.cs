using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace WaterProject.infrastructure
{
    public static class SessionExtensions
    {
        // A method that sets an object as a JSON string in session
        public static void SetJson(this ISession session, string key, object value)
        {
            // Serialize the object to a JSON string and set it in the session
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        // A method that gets a JSON string from session and deserializes it to an object of type T
        public static T GetJson<T>(this ISession session, string key)
        {
            // Get the JSON string from session for the specified key
            var sessionData = session.GetString(key);

            // If there is no data for the key in session, return the default value for type T
            // Otherwise, deserialize the JSON string to an object of type T and return it
            return sessionData == null ? default(T) : JsonSerializer.Deserialize<T>(sessionData);
        }
    }
}
