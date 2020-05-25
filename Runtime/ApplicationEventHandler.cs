using UnityEngine;

namespace ScriptUtils
{
    [CreateAssetMenu(menuName = "Utils/Application Event Handler")]
    public class ApplicationEventHandler : ScriptableObject
    {
        [SerializeField]
        private bool m_debug = true;

        public void Quit()
        {
            Application.Quit();
        }

        public void HideMouseCursor()
        {
            if (m_debug) Debug.Log("Hiding mouse cursor");
            Cursor.visible = false;
        }

        public void ShowMouseCursor()
        {
            if (m_debug) Debug.Log("Showing mouse cursor");
            Cursor.visible = true;
        }
    }
}