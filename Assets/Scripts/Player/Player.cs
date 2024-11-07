using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Models;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class Player : MonoBehaviour, IDamageable
    {
        [SerializeField]
        private float _health = 100;

        public void TakeDamage(float damage)
        {
            _health -= damage;
            if(_health <= 0) {
                Destroy(gameObject);
            }
        }
    }
}
