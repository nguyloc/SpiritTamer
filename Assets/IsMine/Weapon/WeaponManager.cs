using Fusion;
using IsMine.Player;
using UnityEngine;

namespace IsMine.Weapon
{
    public class WeaponManager : NetworkBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                PlayerPropeties opponentCombat = other.GetComponent<PlayerPropeties>();
                if (opponentCombat != null)
                {
                    Debug.Log("Player: " + opponentCombat.name);
                    opponentCombat.RpcTakeDamage(10);
                }
            }
        }
    }
}
