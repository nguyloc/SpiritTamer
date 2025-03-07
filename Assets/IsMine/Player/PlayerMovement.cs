using UnityEngine;

namespace IsMine.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public float speed = 5f;
        public float gravity = -9.81f;
        private CharacterController controller;
        private Vector3 velocity;

        void Start()
        {
            controller = GetComponent<CharacterController>();
        }

        void Update()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

            if (direction.magnitude >= 0.1f)
            {
                controller.Move(direction * speed * Time.deltaTime);
            }

            
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
    }
}
