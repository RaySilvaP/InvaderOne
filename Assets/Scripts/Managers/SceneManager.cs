using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class SceneManager : MonoBehaviour
    {
        public const int ENEMY_LIMIT = 3;
        public static SceneManager Inst { get; private set; }
        public int EnemyCount {get; set;}
        [SerializeField]
        private GameObject _player;
        public GameObject Player {get{return _player;}}

        void Awake()
        {
            if (Inst == null)
                Inst = this;
            else
                Destroy(gameObject);
        }
    }
}
