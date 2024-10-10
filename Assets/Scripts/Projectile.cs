using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Projectile : Movement
    {
        public float Damage { get; set; }
        public int MaxPenetration { get; set; }
        private int _penetrationCount;

        void Update()
        {
            Accelerate();
        }

        void FixedUpdate()
        {
            transform.Translate(Speed);
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<IDamageable>(out var damageable))
            {
                damageable.TakeDamage(Damage);
                _penetrationCount++;
                if (_penetrationCount > MaxPenetration)
                    Destroy(gameObject);
            }
        }
    }
}
