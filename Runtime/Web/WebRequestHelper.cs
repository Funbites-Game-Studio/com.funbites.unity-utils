using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace Funbites.UnityUtils
{
    public static class WebRequestHelper
    {
        /*
        public static IEnumerator PostJson(string url, Dictionary<string, string> headers, Dictionary<string,string> body, Action<UnityWebRequest> onComplete)
        {
            using (var request = new UnityWebRequest(url, "POST"))
            {
                byte[] bodyRaw = Encoding.UTF8.GetBytes(DicToJsonString(body));
                request.uploadHandler = new UploadHandlerRaw(bodyRaw);
                request.downloadHandler = new DownloadHandlerBuffer();
                request.SetHeaders(headers);
                request.SetRequestHeader("Content-Type", "application/json");
                yield return request.SendWebRequest();
                onComplete.Invoke(request);
            }
        }

        public static IEnumerator GetJson(string url, Dictionary<string, string> headers, Dictionary<string, string> body, Action<UnityWebRequest> onComplete)
        {
            using (var request = new UnityWebRequest(url, "GET"))
            {
                byte[] bodyRaw = Encoding.UTF8.GetBytes(DicToJsonString(body));
                request.uploadHandler = new UploadHandlerRaw(bodyRaw);
                request.downloadHandler = new DownloadHandlerBuffer();
                request.SetHeaders(headers);
                request.SetRequestHeader("Content-Type", "application/json");
                yield return request.SendWebRequest();
                onComplete.Invoke(request);
            }
        }
        */

        public static IEnumerator RequestGet(string url, Dictionary<string, string> headers, Dictionary<string, string> query, Action<UnityWebRequest> onComplete)
        {
            var newUrl = url + DicToQueryString(query);
            using (var request = UnityWebRequest.Get(newUrl))
            {
                request.SetHeaders(headers);
                request.SetRequestHeader("Content-Type", "application/json");
                yield return request.SendWebRequest();
                onComplete.Invoke(request);
            }
        }

        public static IEnumerator RequestJsonPost(string url, Dictionary<string, string> headers, Dictionary<string, string> body, Action<UnityWebRequest> onComplete)
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(DicToJsonString(body));
            using (var request = new UnityWebRequest(url, "POST", new DownloadHandlerBuffer(), new UploadHandlerRaw(bodyRaw)))
            {
                request.SetHeaders(headers);
                request.SetRequestHeader("Content-Type", "application/json");
                yield return request.SendWebRequest();
                onComplete.Invoke(request);
            }
        }

        

        private static string DicToJsonString(Dictionary<string, string> dic)
        {
            StringBuilder dicToJson = new StringBuilder("{");
            foreach (var keyValue in dic)
            {
                dicToJson.Append('"');
                dicToJson.Append(keyValue.Key);
                dicToJson.Append("\":\"");
                dicToJson.Append(keyValue.Value);
                dicToJson.Append("\",");
            }
            dicToJson.Remove(dicToJson.Length - 1, 1);
            dicToJson.Append('}');
            return dicToJson.ToString();
        }

        private static string DicToQueryString(Dictionary<string, string> dic)
        {
            StringBuilder dicToQuery = new StringBuilder("?");
            foreach (var keyValue in dic)
            {
                dicToQuery.Append(keyValue.Key);
                dicToQuery.Append("=");
                dicToQuery.Append(keyValue.Value);
                dicToQuery.Append("&");
            }
            dicToQuery.Remove(dicToQuery.Length - 1, 1);
            return dicToQuery.ToString();
        }

        public static IEnumerator PostForm(string url, Dictionary<string, string> headers, Dictionary<string, string> body, Action<UnityWebRequest> onComplete)
        {
            using (UnityWebRequest request = UnityWebRequest.Post(url, body))
            {
                request.SetHeaders(headers);
                yield return request.SendWebRequest();
                onComplete.Invoke(request);
            }
        }

        private static void SetHeaders(this UnityWebRequest request, Dictionary<string, string> headers)
        {
            foreach (var header in headers)
            {
                request.SetRequestHeader(header.Key, header.Value);
            }
        }
    }
}