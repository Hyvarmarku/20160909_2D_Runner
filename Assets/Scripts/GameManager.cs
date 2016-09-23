using UnityEngine;
using System.Collections;

namespace Runner
{
    public class GameManager : MonoBehaviour
    {
        #region Statics
        private static GameManager _instance;

        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<GameManager>();
                    if (_instance == null)
                    {
                        GameObject go = new GameObject("GameManager");
                        _instance = go.AddComponent<GameManager>();
                        _instance.Init();
                    }
                }

                return _instance;
            }
        }
        #endregion

        public GUIManager guiManager
        {
            get
            {
                if (_guiManager == null)
                    _guiManager = FindObjectOfType<GUIManager>();
                if (_guiManager == null)
                {
                    Debug.LogError("GameManager: guiManager is not found from scene!");
                    Debug.Break();
                }
                return _guiManager;
            }
        }

        private Camera _mainCamera;
        private CameraFollow _cameraFollow;
        private GUIManager _guiManager;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                Init();
            }
            else if (_instance != this)
                Destroy(this);
        }

        private void Init()
        {
            _mainCamera = Camera.main;
            _cameraFollow = _mainCamera.transform.GetComponent<CameraFollow>();
        }

        public void Pause(bool pause)
        {
            if (pause)
                Time.timeScale = 0;
            else
                Time.timeScale = 1;
        }

        public void GameOver()
        {
            Pause(true);
            _cameraFollow.GameOver();
            guiManager.ShowMessage("Game Over");
        }
    }
}
