using UnityEngine;

namespace Assets.Scripts
{
    public class CursorObserver : MonoBehaviour
    {
        public const int MAX_ROTATION = -15, MIN_ROTATION = -165;
        public float _angle;
        public Vector2 _mousePos, _direction;

        // Update is called once per frame
        void Update()
        {
            GetMousePosition();
            SetAngle();
            LimitAngle();
        }

        void FixedUpdate()
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, _angle));
        }

        private void SetAngle()
        {
            _direction = _mousePos - (Vector2)transform.position;
            _direction.Normalize();
            _angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        }

        private void GetMousePosition()
        {
            var pos = Input.mousePosition;
            _mousePos = Camera.main.ScreenToWorldPoint(pos);
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
