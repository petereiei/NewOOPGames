using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AppGames.Script
{
    public class AttackBoxPlayer : MonoBehaviour
    {
        TrollEnemy trollEenemy;

        public GameObject TrollObject;

        public bool attackBox = false;

        private void Start()
        {
            trollEenemy = TrollObject.GetComponent<TrollEnemy>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player" && trollEenemy.OnAttack == true)
            {
                Debug.Log("PLayer HP -- 10 ");
                
            }
        }
    }
}
   
