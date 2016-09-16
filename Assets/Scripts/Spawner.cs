using UnityEngine;
using System.Collections;

namespace Runner
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] _spawnPrefabs;
        [SerializeField] private float _spawnTimeMin;
        [SerializeField] private float _spawnTimerMax;

        private SpawnerController _spawnerController;

        public void Init(SpawnerController spawnerController)
        {
            _spawnerController = spawnerController;
        }

        private void Start()
        {
            Spawn();
        }

        private void Spawn()
        {
            if (_spawnerController != null)
            {
                var prefab = _spawnPrefabs[Random.Range(0, _spawnPrefabs.Length)];
                Instantiate(prefab, transform.position, Quaternion.identity);
            }
            else
            {
                var spawnerObject = _spawnerController.GetRandomObject();
                spawnerObject.transform.position = transform.position;
            }
            Invoke("Spawn", Random.Range(_spawnTimeMin, _spawnTimerMax));
        }
    }
}