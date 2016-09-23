using UnityEngine;
using System.Collections;

namespace Runner
{
    public class Collectable : MonoBehaviour
    {
        [SerializeField] private int _rotationSpeed = 10;
        [SerializeField] private int _points;
        private Transform _transform;

        void Start()
        {
            _transform = transform;
        }

        void Update()
        {
            _transform.Rotate(new Vector3(0, 0, _transform.rotation.z + _rotationSpeed * Time.deltaTime));
        }

        public void OnTriggerEnter2D(Collider2D col)
        {
            if (col.tag == "Player")
            {
                GameManager.Instance.AddPoints(_points);
                Destroy(gameObject);
            }
        }
    }
}
