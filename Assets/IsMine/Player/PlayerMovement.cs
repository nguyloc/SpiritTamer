using UnityEngine;

namespace IsMine.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public float speed = 5f;
        public float gravity = -9.81f;
        private CharacterController controller;
        private Vector3 velocity;
        
        private bool isMoving = false;

        void Start()
        {
            controller = GetComponent<CharacterController>();
        }

        void Update()
        {
            Moving();
        }
        
        void Moving()
        {
            if (!isMoving)
            {
                float horizontal = Input.GetAxis("Horizontal");
                float vertical = Input.GetAxis("Vertical");

                Vector3 direction = new Vector3(horizontal, 0, vertical).normalized; 

                if (direction.magnitude >= 0.1f)
                {
                    controller.Move(direction * speed * Time.deltaTime);
                    
                    // Check for encounter
                    CheckForEncounter();
                }
                velocity.y += gravity * Time.deltaTime;
                controller.Move(velocity * Time.deltaTime);
                
            }
        }
        
        private void CheckForEncounter()
        {
            // Check if player moving on Grass
            if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 1f))
            {
                if (hit.collider.CompareTag("Grass"))
                {
                    // Encounter
                    isMoving = true;
                    Debug.Log("Encounter");
                }
            }
        }
    }
}
