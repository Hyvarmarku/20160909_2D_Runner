using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Runner
{
    public class GUIManager : MonoBehaviour
    {
        [SerializeField] private Text _message;

        private void Awake()
        {
            if (_message == null)
            {
                Debug.LogError("GUIManager: _message is null");
                Debug.Break();
            }

            HideMessage();
        }

        public void ShowMessage(string message)
        {
            _message.gameObject.SetActive(true);
            _message.text = message;
        }

        public void HideMessage()
        {
            _message.gameObject.SetActive(false);
        }
    }
}
