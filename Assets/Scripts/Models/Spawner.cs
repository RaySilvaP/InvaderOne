using System.Collections;
using UnityEngine;
using Assets.Scripts.Managers;

namespace Assets.Scripts.Models
{
    public class Spawner : MonoBehaviour
    {
        private SceneManager _sceneManager;
        public float _spawnRateSeconds;
        public Vector2 _center, _size;
        public GameObject _obj;

        void Start()
        {
            _sceneManager = SceneManager.Inst;
            StartCoroutine(Spawning());
        }

        IEnumerator Spawning()
        {
            while (true)
            {
                if (_sceneManager._enemyCount < SceneManager.ENEMY_LIMIT)
                {
                    Vector2 pos = _center + new Vector2(Random.Range(-_size.x, _size.x) / 2, Random.Range(-_size.y, _size.y) / 2);
                    Instantiate(_obj, pos, Quaternion.identity);
                    _sceneManager._enemyCount++;
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
