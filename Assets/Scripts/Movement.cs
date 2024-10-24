using UnityEngine;

namespace Assets.Scripts
{
    public class Movement : MonoBehaviour
    {
        public float _acceleration, _brakeForce;
        public const float MIN_VELOCITY = 0.001f, MAX_VELOCITY = 200;
        public Vector2 _direction;
        public Vector2 Speed { get; private set; }
        private Vector2 _resistance;

        void Update()
        {
            Accelerate();
        }

        void FixedUpdate()
        {
            transform.Translate(Speed);
        }

        private void Accelerate()
        {
            _resistance = _brakeForce * Time.deltaTime * Speed;
            Speed -= _resistance;
            Speed += _acceleration * Time.deltaTime * _direction.normalized;
            LimitVelocity();
        }

        private void LimitVelocity()
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
