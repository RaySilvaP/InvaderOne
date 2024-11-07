using System.Collections;
using UnityEngine;
using Assets.Scripts.Managers;

namespace Assets.Scripts.Models
{
    public class EnemySpawner : MonoBehaviour
    {
        private SceneManager _sceneManager;
        public float _spawnRateSeconds;
        public Vector2 _center, _size;
        public GameObject _enemyPrefab;

        void Start()
        {
            _sceneManager = SceneManager.Inst;
            StartCoroutine(Spawning());
        }

        IEnumerator Spawning()
        {
            while (true)
            {
                if (_sceneManager.EnemyCount < SceneManager.ENEMY_LIMIT)
                {
                    Vector2 pos = _center + new Vector2(Random.Range(-_size.x, _size.x) / 2, Random.Range(-_size.y, _size.y) / 2);
                    var enemy = Instantiate(_enemyPrefab, pos, Quaternion.identity);
                    enemy.GetComponent<Enemy>().TargetPos = transform.position;
                    _sceneManager.EnemyCount++;
                }

                yield return new WaitForSeconds(_spawnRateSeconds);
            }
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(_center, _size);
        }
    }
}
