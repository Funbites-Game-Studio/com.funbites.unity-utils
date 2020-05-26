namespace Funbites.UnityUtils.Events {
    using Analytics = UnityEngine.Analytics.Analytics;
    public class AnalyticsEventHandler : UnityEngine.MonoBehaviour {

        [UnityEngine.SerializeField]
        private string m_eventName = "EVENT_NAME";
        [UnityEngine.SerializeField]
        private string[] m_parametersName = null;

        private object[] parametersValue;
        public void LogAnalyticsCustomEvent() {
            if (m_parametersName.Length > 0) {
                var parameters = new System.Collections.Generic.Dictionary<string, object>(m_parametersName.Length);
                for (int i = 0; i < m_parametersName.Length; i++) {
                    parameters.Add(m_parametersName[i], parametersValue[i]);
                }
                Analytics.CustomEvent(m_eventName, parameters);
            } else {
                Analytics.CustomEvent(m_eventName);
            }
        }

        public void SetFirstParameterValue(object value) {
            SetParameterValue(0, value);
        }

        private void SetParameterValue(int index, object value) {
            if (parametersValue == null) parametersValue = new object[m_parametersName.Length];
            parametersValue[0] = value;
        }
    }
}