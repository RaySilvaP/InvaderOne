using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Models
{
    public class Gun : MonoBehaviour
    {
        public const float PROJECTILE_ACCELERATION = 3f, PROJECTILE_LIFETIME_SECONDS = 3;
        public float _fireRateSeconds, _damage;
        public int _maxPenetration = 0;
        public GameObject _projectilePrefab;
        public Transform _muzzle;

        void Start()
        {
            StartCoroutine(Shooting());
        }

        private void Shoot()
        {
            var obj = Instantiate(_projectilePrefab, _muzzle.position, Quaternion.identity);
            var projectile = obj.AddComponent<Projectile>();
            var movement = obj.AddComponent<Movement>();
            movement.Direction = transform.right.normalized;
            movement.Acceleration = PROJECTILE_ACCELERATION;
            projectile.Damage = _damage;

            Destroy(obj, PROJECTILE_LIFETIME_SECONDS);
        }

        IEnumerator Shooting()
        {
            while (true)
            {
                Shoot();
                yield return new WaitForSeconds(1 / _fireRateSeconds);
            }
        }
    }
}