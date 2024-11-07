using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Extensions
{
    public static class TransformExtension
    {
        public static void LookAt2D(this Transform transform, Vector2 direction)
        {
            direction.Normalize();
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    
    }
}
