using Assets.Scripts.Extensions;
using UnityEngine;

namespace Assets.Scripts
{
    public class CursorObserver : MonoBehaviour
    {
        private Vector2 _mousePos, _direction;
        [SerializeField]
        private Vector2 _maxDirection = new Vector2(1, 1), _minDirection = new Vector2(-1, -1);
        // Update is called once per frame
        void Update()
        {
            GetMousePosition();
            SetDirection();
            LimitAngle();
        }

        void FixedUpdate()
        {
            transform.LookAt2D(_direction);
        }

        private void SetDirection()
        {
            _direction = _mousePos - (Vector2)transform.position;
            _direction.Normalize();
        }

        private void GetMousePosition()
        {
            var pos = Input.mousePosition;
            _mousePos = Camera.main.ScreenToWorldPoint(pos);
        }

        private void LimitAngle()
        {
            if (_direction.y > _maxDirection.y)
                _direction.y = _maxDirection.y;
            else if(_direction.y < _minDirection.y)
                _direction.y = _minDirection.y;
            
            if(_direction.x > _maxDirection.x)
                _direction.x = _maxDirection.x;
            else if(_direction.x < _minDirection.x)
                _direction.x = _minDirection.x;
        }
    }
}
