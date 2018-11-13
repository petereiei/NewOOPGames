using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AppGames.Script.Model
{
    [System.Serializable]
    public class HealthChangedEvent : UnityEvent<float> { }

    [System.Serializable]
    public class PlayerModel : MonoBehaviour
    {
        //[SerializeField]
        public int hp = 100;

        public float MaxSpeed = 10f;
        public int DamageAmount = 10;
        /*
        public int Health
        {
            get {
                return hp;
            }

            set{
                hp = 100;
                if (hp > 100) hp = 100;

            }
        }
        */
        [SerializeField]
        public HealthChangedEvent OnHealthChangedEvents;

    }
}


