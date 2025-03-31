using UnityEngine;
using Fusion;
using UnityEngine.UI;
using TMPro;
using System;

[System.Serializable]
public struct PlayerInfo: INetworkStruct
{
    public int health;
    //public int mana;
    public int score;
}


namespace IsMine.Player
{
    public class PlayerPropeties : NetworkBehaviour
    {
        [Networked,OnChangedRender(nameof(OnInfoChanged))]
        private PlayerInfo info{get;set;}
    
        public Slider sliderHealth;
       // public Slider sliderMana;
        public TextMeshProUGUI scoreText;


        private void OnInfoChanged()
        {   
            sliderHealth.value=info.health;
            //sliderMana.value=info.mana;
            scoreText.text=info.score+"";
            Debug.Log("score: "+info.score);
        }
        void Start()
        {
            info=new PlayerInfo
            {
                health=(int)sliderHealth.value,
                //mana=(int)sliderMana.value,
                score=0
            }; 
        }
        void Update()
        {
            if(HasInputAuthority)
            {
                if(Input.GetMouseButtonDown(0))
                {
                    int currenthealth=info.health;
                    //int currentmana=info.mana;
                    int currentscore=info.score;
                    info =new PlayerInfo
                    {
                        health=currenthealth-10,
                        //mana=currentmana-20,
                        score=currentscore+30,
                    };
                }
            }
        }
    }
}
