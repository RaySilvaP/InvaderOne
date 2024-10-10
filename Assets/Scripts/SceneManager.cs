using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class SceneManager : MonoBehaviour
    {
        public const int ENEMY_LIMIT = 3;
        public static SceneManager Inst { get; private set; }
        public int _enemyCount;

        void Awake()
        {
            if (Inst == null)
                Inst = this;
            else
                Destroy(gameObject);
        }
    }
}
