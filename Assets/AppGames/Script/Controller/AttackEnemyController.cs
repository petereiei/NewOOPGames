using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AppGames.Script.Model;
using AppGames.Script.View;


namespace AppGames.Script.Controller
{
    public class AttackEnemyController : MonoBehaviour
    {
        private PlayerView Playerview;
        private AttackEnemyView AttackView;

        public void AttackEnemy()
        {
            AttackView.ss.gameObject.SetActive(true);
        }
    }
}

