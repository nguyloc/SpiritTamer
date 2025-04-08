using System;
using UnityEngine;

namespace IsMine.TestPlayMode.TestSource
{
    public class Movement : MonoBehaviour
    {
        public float moveSpeed = 5f;
        public IInputProvider input;
        
        void Start()
        {
            // If no input provider is set, use the default Unity input provider
            if (input == null)
                input = new UnityInputProvider();
        }

        void Update()
        {
            float h = input.GetHorizontal();
            float v = input.GetVertical();
        
            Vector3 move = new Vector3(h, 0, v);
            transform.Translate(move * moveSpeed * Time.deltaTime);
        }
    }
}
