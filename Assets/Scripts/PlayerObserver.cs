using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Extensions;
using Assets.Scripts.Managers;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerObserver : MonoBehaviour
    {
        void FixedUpdate()
        {
            var direction = GetDirection();
            transform.LookAt2D(direction);
        }

        private Vector2 GetDirection()
        {
            var player = SceneManager.Inst.Player;
            if(player == null)
                return Vector2.zero;

            var direction = player.transform.position - transform.position;
            return direction.normalized;
        }
    }
}
