using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.EditorCoroutines.Editor;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;


namespace Funbites.UnityUtils.Editor
{
    public class WebRequestTestTool : OdinEditorWindow
    {

        [MenuItem("Tools/Funbites/Web Request Test")]
        private static void OpenWindow()
        {
            GetWindow<WebRequestTestTool>().Show();
        }
        [SerializeField, Required]
        private string m_url = "http://www.my-server.com/myform";
        [ShowInInspector]
        private Dictionary<string, string> m_headers = new Dictionary<string, string>();
        [ShowInInspector]
        private Dictionary<string, string> m_data = new Dictionary<string, string>();
        [ShowInInspector]
        private EditorCoroutine currentRequest;

        [Button]
        private void PostJson()
        {
            if (currentRequest != null) return;
            currentRequest = EditorCoroutineUtility.StartCoroutine(WebRequestHelper.RequestJsonPost(m_url, m_headers, m_data, OnComplete), this);
        }

        [Button]
        private void PostForm()
        {
            if (currentRequest != null) return;
            currentRequest = EditorCoroutineUtility.StartCoroutine(WebRequestHelper.PostForm(m_url, m_headers, m_data, OnComplete), this);
        }

        private void OnComplete(UnityWebRequest response)
        {
#if UNITY_2020_1_OR_NEWER
            if (response.result != UnityWebRequest.Result.Success)
#else
            if (response.isNetworkError || response.isHttpError)
#endif
                {
                Debug.Log(response.error);
            }
            else
            {
                Debug.Log("Request complete!");
            }
            foreach (var responseHeader in response.GetResponseHeaders())
            {
                Debug.Log($"{responseHeader.Key}: {responseHeader.Value}");
            }
            Debug.Log(response.downloadHandler.text);
            currentRequest = null;
        }

        IEnumerator Post(string url, string bodyJsonString)
        {
            var request = new UnityWebRequest(url, "POST");
            byte[] bodyRaw = Encoding.UTF8.GetBytes(bodyJsonString);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("api-key", "iddYrtZvqLUjU8FByAgQjyfkxRTbPlevGiMjfODXva4uHuNdLuMaWKstMPkZr8Se");
            yield return request.SendWebRequest();
            Debug.Log("Status Code: " + request.responseCode);
            foreach (var responseHeader in request.GetResponseHeaders())
            {
                Debug.Log($"{responseHeader.Key}: {responseHeader.Value}");
            }
        }

        IEnumerator PostCoroutine()
        {
            WWWForm form = new WWWForm();
            if (m_data != null)
            {
                foreach (var datum in m_data)
                {
                    form.AddField(datum.Key, datum.Value);
                }
            }

            using (UnityWebRequest www = UnityWebRequest.Post(m_url, form))
            {
                //www.SetRequestHeader("Content-Type", "multipart/form-data");
                www.SetRequestHeader("api-key", "iddYrtZvqLUjU8FByAgQjyfkxRTbPlevGiMjfODXva4uHuNdLuMaWKstMPkZr8Se");
                
                //www.SetRequestHeader("api-key", "wnavz7xfN3pskCEUHEgYOWIlNTPHQmy5iriTTDEXz4McWyDQChKo3MMb6o9WkDLs");
                yield return www.SendWebRequest();


                currentRequest = null;
            }
        }
    }
}