using UnityEngine;
using Assets.Scripts.Managers;

namespace Assets.Scripts.Models
{
    public class Enemy : MonoBehaviour, IDamageable
    {
        [SerializeField]
        private Movement _movement;
        public const float MAX_HEALTH = 100;
        [SerializeField]
        private float  _distanceWeight;
        private float _health = 100;
        public Vector2 TargetPos {private get; set;}

        // Update is called once per frame
        void FixedUpdate()
        {
            SetDirection();
            SetAcceleration();
        }

        void SetDirection()
        {
            _movement.Direction = (TargetPos - (Vector2)transform.position).normalized;
        }

        void SetAcceleration()
        {
            _movement.Acceleration = Vector2.Distance(transform.position, TargetPos) * _distanceWeight;
        }

        public void TakeDamage(float damage)
        {
            _health -= damage;
            if (_health <= 0)
            {
                Destroy(gameObject);
                SceneManager.Inst.EnemyCount--;
            }
        }
    }
}
