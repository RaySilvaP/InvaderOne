using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Enemy : Movement, IDamageable
    {
        public const float MAX_HEALTH = 100;
        public float _health = 100, _distanceWeight;
        public Transform _combatZone;
        public Vector2 _point;

        // Start is called before the first frame update
        void Start()
        {
            SetPoint();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            SetDirection();
            SetAcceleration();
            transform.Translate(Speed);
        }

        void SetPoint()
        {
            _combatZone = GameObject.Find("CombatZone").transform;
            int index = Random.Range(0, _combatZone.childCount);
            _point = _combatZone.GetChild(index).position;
        }

        void SetDirection()
        {
            _direction = (_point - (Vector2)transform.position).normalized;
        }

        void SetAcceleration()
        {
            _acceleration = Vector2.Distance(transform.position, _point) * _distanceWeight;
        }

        public void TakeDamage(float damage)
        {
            _health -= damage;
            if (_health <= 0)
            {
                Destroy(gameObject);
                SceneManager.Inst._enemyCount--;
            }
        }
    }
}
