using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Runner
{
    public class GUIManager : MonoBehaviour
    {
        [SerializeField] private Text _message;
        [SerializeField] private Text _points;
        [SerializeField] private Button _startGamebutton;
        [SerializeField] private Button _newGamebutton;

        private void Awake()
        {
            if (_message == null)
            {
                Debug.LogError("GUIManager: _message is null");
                Debug.Break();
            }
            if (_points == null)
            {
                Debug.LogError("GUIManager: _points is null");
                Debug.Break();
            }
            if (_startGamebutton == null)
            {
                Debug.LogError("GUIManager: _startGameButton is null");
                Debug.Break();
            }
            if (_newGamebutton == null)
            {
                Debug.LogError("GUIManager: _newGameButton is null");
                Debug.Break();
            }

            _newGamebutton.gameObject.SetActive(false);
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

        public void UpdatePoints(int points)
        {
            //_points.text = "Points: " + points.ToString();
            _points.text = string.Format("Points {0}", points);
        }

        public void StartGame()
        {
            _startGamebutton.gameObject.SetActive(false);
        }

        public void NewGame()
        {
            _newGamebutton.gameObject.SetActive(false);
        }

        public void GameOver()
        {
            _newGamebutton.gameObject.SetActive(true);
            ShowMessage("Game Over");
        }
    }
}
