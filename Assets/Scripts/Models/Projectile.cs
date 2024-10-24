using UnityEngine;

namespace Assets.Scripts.Models
{
    public class Projectile : MonoBehaviour
    {
        public float Damage { get; set; }
        public int MaxPenetration { get; set; }
        private int _penetrationCount;

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
