using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class FollowMouse : MonoBehaviour
    {
        public const int MAX_ROTATION = -15, MIN_ROTATION = -165;
        public float _angle;
        public Vector2 _mousePos, _direction;

        // Update is called once per frame
        void Update()
        {
            SetMousePosition();
            SetAngle();
            LimitAngle();
        }

        void FixedUpdate()
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, _angle));
        }

        private void SetMousePosition()
        {
            var pos = Input.mousePosition;
            _mousePos = Camera.main.ScreenToWorldPoint(pos);
        }

        private void SetAngle()
        {
            _direction = _mousePos - (Vector2)transform.position;
            _direction.Normalize();
            _angle = MathF.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        }

        private void LimitAngle()
        {
            if (_angle > MAX_ROTATION && _angle < 90)
                _angle = MAX_ROTATION;
            else if (_angle < MIN_ROTATION || _angle > 90)
                _angle = MIN_ROTATION;
        }
    }
}
