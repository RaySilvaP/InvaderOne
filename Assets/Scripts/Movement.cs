using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Movement : MonoBehaviour
    {
        public float _acceleration, _brakeForce;
        public const float MIN_VELOCITY = 0.001f, MAX_VELOCITY = 200;
        public Vector2 _direction;
        public Vector2 Speed { get; private set; }
        public Vector2 Resistance { get; private set; }

        void Update()
        {
            Accelerate();
        }

        void FixedUpdate()
        {
            transform.Translate(Speed);
        }

        protected void Accelerate()
        {
            Resistance = _brakeForce * Time.deltaTime * Speed;
            Speed -= Resistance;
            Speed += _acceleration * Time.deltaTime * _direction.normalized;
            LimitVelocity();
        }

        protected void LimitVelocity()
        {
            if (Speed.magnitude > MAX_VELOCITY)
            {
                Speed.Normalize();
                Speed *= MAX_VELOCITY;
            }
            else if (Speed.magnitude < MIN_VELOCITY)
            {
                Speed = Vector2.zero;
            }
        }
    }
}
