using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Player
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
            projectile._direction = transform.right.normalized;
            projectile._acceleration = PROJECTILE_ACCELERATION;
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