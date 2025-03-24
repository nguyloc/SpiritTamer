using System;
using Fusion;
using UnityEngine;

namespace IsMine.Player
{
    public class PlayerController : NetworkBehaviour
    {
        public float speed = 5f;
        private CharacterController controller;

        private void Start()
        {
            controller = GetComponent<CharacterController>();
        }

        public override void FixedUpdateNetwork()
        {
            if (GetInput(out PlayerInput input))
            {
                Vector3 moveDirection = new Vector3(input.Horizontal, 0, input.Vertical).normalized;
                controller.Move(moveDirection * speed * Runner.DeltaTime);
            }
        }
    }
}
