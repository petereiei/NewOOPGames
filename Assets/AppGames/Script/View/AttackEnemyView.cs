using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace AppGames.Script.View
{

    public class AttackEnemyView : MonoBehaviour
    {
        public GameObject ss;

        public void OnAttackEnemyChange()
        {
            ss.gameObject.SetActive(false);
        }
    }

}
