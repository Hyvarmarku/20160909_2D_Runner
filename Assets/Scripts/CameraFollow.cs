using UnityEngine;
using System.Collections;

namespace Runner
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        [SerializeField] private float _xOffset;

        private bool _follow = true;

        void Update()
        {
            if(_follow)
                transform.position = new Vector3(_player.transform.position.x + _xOffset, 0, -10);
        }

        public void GameOver()
        {
            _follow = false;
        }
    }
}
