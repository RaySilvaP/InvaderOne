using UnityEngine;

namespace Assets.Scripts
{
    public class Movement : MonoBehaviour
    {
        public const float MIN_VELOCITY = 0.001f, MAX_VELOCITY = 200;
        [SerializeField]
        private float _acceleration, _brakeForce;
        [SerializeField]
        private Vector2 _direction;
        private Vector2 _resistance;
        public Vector2 Direction {get{return _direction;} set{_direction = value;}}
        public float Acceleration {get{return _acceleration;} set{_acceleration = value;}}
        public float BrakeForce {get{return _brakeForce;} set{_brakeForce = value;}}
        public Vector2 Speed { get; private set; }

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
