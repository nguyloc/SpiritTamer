using Fusion;
using UnityEngine;

namespace IsMine.Player
{
    public class PlayerSpawner : SimulationBehaviour, IPlayerJoined
    {
        public GameObject playerPrefab;
        public readonly Color[] playerColors = new Color[]
        {
            Color.red,
            Color.blue,
            Color.green,
            Color.yellow
        };

        public void PlayerJoined(PlayerRef player)
        {
            if (player == Runner.LocalPlayer)
            {
                var randomPosition = new Vector3(Random.Range(-10, 10), 1, Random.Range(-10, 10));
                NetworkObject playerObject = Runner.Spawn(
                    playerPrefab, 
                    randomPosition, 
                    Quaternion.identity, 
                    player,
                    (runner, obj) =>
                    {
                        // Set player color
                        PlayerColor playerColor = obj.GetComponent<PlayerColor>();
                        if (playerColor != null)
                        {
                            Color randomColor = new Color(Random.value, Random.value, Random.value); 
                            playerColor.NetworkColor = new Vector3(randomColor.r, randomColor.g, randomColor.b);
                        }
                    }
                );
                
                playerObject.AssignInputAuthority(player);
            }
        }
    }
}
