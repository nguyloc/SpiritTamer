using Fusion;
using UnityEngine;

namespace IsMine.Player
{
    public class PlayerColor : NetworkBehaviour
    {
        [Networked] 
        public Vector3 NetworkColor { get; set; }  // Lưu màu bằng Vector3

        private Renderer _renderer;
        private Vector3 _lastColor; // Lưu màu trước đó để kiểm tra thay đổi

        public override void Spawned()
        {
            _renderer = GetComponentInChildren<Renderer>();
            UpdateColor();
            _lastColor = NetworkColor; // Gán màu ban đầu
        }

        public override void FixedUpdateNetwork()
        {
            // Kiểm tra nếu NetworkColor thay đổi thì update màu
            if (NetworkColor != _lastColor)
            {
                UpdateColor();
                _lastColor = NetworkColor;
            }
        }

        private void UpdateColor()
        {
            if (_renderer == null) _renderer = GetComponentInChildren<Renderer>();
            if (_renderer != null)
            {
                _renderer.material.color = new Color(NetworkColor.x, NetworkColor.y, NetworkColor.z);
            }
        }
    }
}