using UnityEngine;
using System.Collections;

namespace Runner
{
    public class DeSpawner : MonoBehaviour
    {
        [SerializeField]
        private SpawnerController _spawnnerController;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_spawnnerController == null || !_spawnnerController.AddToPool(other.gameObject))
                Destroy(other.gameObject);

        }
    }
}

