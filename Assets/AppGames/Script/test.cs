using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AppGames.Script.View;

namespace AppGames.Script
{
    public class test : MonoBehaviour
    {

        public GameObject testa;

        private void Start()
        {
            testa = GameObject.Find("Player/Controller/PlayerController");
        }


    }
}
   
