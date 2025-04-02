using UnityEngine;
using Fusion;
using UnityEngine.UI;
using TMPro;
using System;

namespace IsMine.Player
{
    public class PlayerPropeties : NetworkBehaviour
    {
        [Networked, OnChangedRender(nameof(OnInfoChanged))]
        public int health { get; set; } = 100;
        [Networked, OnChangedRender(nameof(OnInfoChanged))]
        public int mana { get; set; } = 100;
        [Networked, OnChangedRender(nameof(OnInfoChanged))]
        public int score { get; set; } = 0;

        public GameObject weapon;


        Animator anim;
        [Networked,OnChangedRender(nameof(OnAnimationChanged))]
        public bool Slash{get;set;}=false;


        private void OnAnimationChanged()
        {
            anim.SetTrigger("Slash");
        }
    
        public Slider sliderHealth;
        public Slider sliderMana;
        public TextMeshProUGUI scoreText;


        private void OnInfoChanged()
        {   
            sliderHealth.value=health;
            sliderMana.value=mana;
            if (HasInputAuthority) scoreText.text=score+"";
        }
        void Start()
        {
            anim=gameObject.GetComponent<Animator>();
            
            //if (!HasInputAuthority) 
            //{
                //scoreText.gameObject.SetActive(false); 
            //}
        }
        public override void FixedUpdateNetwork()
        {
            if(HasInputAuthority)
            {
                if(Input.GetMouseButtonDown(0))
                {
                    Slash =! Slash;
                    weapon.GetComponent<BoxCollider>().enabled = true;
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    weapon.GetComponent<BoxCollider>().enabled = false;
                }
            }
        }

        [Rpc(RpcSources.All, RpcTargets.StateAuthority)]
        public void RpcTakeDamage(int damage)
        {
            health -= damage;
            score += 10;
        }
        
        public override void Spawned()
        {
            // Chỉ hiển thị UI cho chính người chơi
            if (Object.HasInputAuthority)
            {
                // Ẩn UI của người khác
                scoreText.gameObject.SetActive(false); 
            }
        } 

    }
}
