using UnityEngine;

namespace IsMine.TestPlayMode.TestSource
{
    public interface IInputProvider
    {
        float GetHorizontal();
        float GetVertical();
    }
    
    public class UnityInputProvider : IInputProvider
    {
        public float GetHorizontal() => Input.GetAxis("Horizontal");
        public float GetVertical() => Input.GetAxis("Vertical");
    }
}