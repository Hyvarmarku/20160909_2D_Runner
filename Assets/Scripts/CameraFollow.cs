using UnityEngine;
using System.Collections;

namespace Runner
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        [SerializeField] private float _xOffset;

        void Update()
        {
            transform.position = new Vector3(_player.transform.position.x + _xOffset, 0, -10);
        }
    }
}
