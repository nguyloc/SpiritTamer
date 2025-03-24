using Fusion;
using UnityEngine;

namespace IsMine.Player
{
    public class PlayerSpawner : SimulationBehaviour, IPlayerJoined
    {
        public GameObject playerPrefab;

        public void PlayerJoined(PlayerRef player)
        {
            if (player == Runner.LocalPlayer)
            {
                var randomPosition = new Vector3(Random.Range(-10, 10), 1, Random.Range(-10, 10));
                NetworkObject playerObject = Runner.Spawn(
                    playerPrefab, 
                    randomPosition, 
                    Quaternion.identity, 
                    player
                );
                
                playerObject.AssignInputAuthority(player);
            }
        }
    }
}
