using Fusion;
using UnityEngine;

namespace IsMine.Player
{
    public struct PlayerInput : INetworkInput
    {
        public float Horizontal;
        public float Vertical;
    }
}