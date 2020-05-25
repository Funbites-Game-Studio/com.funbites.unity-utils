using UnityEngine;

namespace ScriptUtils
{
    [CreateAssetMenu(menuName = "Utils/Event Debugger")]
    public class EventDebugger : ScriptableObject
    {
        public void Log(string message)
        {
            Debug.Log(message);
        }
    }
}