using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerInputManager : MonoBehaviour
    {
        [SerializeField]
        private Movement _movement;

        void Update()
        {
            SetDirection();
        }

        private void SetDirection()
        {
            Vector2 direction;
            if (Input.GetKey(KeyCode.D))
                direction.x = 1;
            else if (Input.GetKey(KeyCode.A))
                direction.x = -1;
            else
                direction.x = 0;

            if (Input.GetKey(KeyCode.W))
                direction.y = 1;
            else if (Input.GetKey(KeyCode.S))
                direction.y = -1;
            else
                direction.y = 0;

            _movement.Direction = direction;
        }
    }
}
