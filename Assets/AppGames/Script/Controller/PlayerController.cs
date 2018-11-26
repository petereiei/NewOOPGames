using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AppGames.Script.Model;
using AppGames.Script.View;


namespace AppGames.Script.Controller
{
    public class PlayerController : MonoBehaviour
    {
        private PlayerModel model;
        private PlayerView view;
        private AttackEnemyView Attackview;
        private HealthBar healthBar;
        // private TrollEnemy trollerEnemy;

        private Rigidbody rb;

        public GameObject playerModelObject;
        public GameObject playerViewObject;
        public GameObject healthBarObject;
        public GameObject BGscoreObject;
        //public GameObject TrollEnemyObject;


        public bool C_Attack = false;

        private void Start()
        {
            model = playerModelObject.GetComponent<PlayerModel>();
            view = playerViewObject.GetComponent<PlayerView>();
            healthBar = healthBarObject.GetComponent<HealthBar>();

            healthBar.SetHealth(model.hp);
            Debug.Log("HP Player : " + model.hp);
           // TrollEnemyObject = GameObject.Find("Troll");
           //trollerEnemy = TrollEnemyObject.GetComponent<TrollEnemy>();
        }

        private void Update()
        {
            //Debug.Log("HP Player : " + model.Health);
            //healthBar.SetHealth(model.Health);
        }

        public void OnHorizontalInput(float h)
        {
            

            Rigidbody rb = view.GetComponent<Rigidbody>();
            Vector3 Movement = new Vector3(h, 0.0f, 0.0f);

            
            if(!this.view.animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
            {
                rb.velocity = Movement * model.MaxSpeed;
            }

            if (h >= 1)
            {
                rb.rotation = Quaternion.LookRotation(Vector3.right);
            }
            if (h <= -1)
            {
                rb.rotation = Quaternion.LookRotation(Vector3.left);
            }

        }

        public  void OnTriggerEnter(Collider other)
        {
            if (other.tag == "AttackBox")
            {
                Debug.Log("Attack Box");
                if (model.hp > 0 )
                {
                    TakeDamage();
                }
                else if (model.hp <= 0)
                {
                    Debug.Log("Save");
                    BGscoreObject.SetActive(true);
                    SubmitNewPlayerScore(Score.score);
                }
            }
        }

        void TakeDamage()
        {
            Debug.Log("Take Damage");
            model.hp -=  model.DamageAmount;
            healthBar.SetHealth(model.hp);
            Debug.Log("HP Player : " + model.hp);
        }

        public void OnAttackInput()
        {
            Debug.Log("attack event2");
            C_Attack = true;
            //view.SS.gameObject.SetActive(true);
            if (view.Attack == true && !this.view.animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
            {              
                transform.position = Vector3.zero;
            }
        }

        public void OnJumpInput()
        {
            view.GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, 0.0f, 55f));
        }

        public void SubmitNewPlayerScore(int newScore)
        {
            if (newScore > model.highestScore)
            {
                model.highestScore = newScore;
                SavePlayerProgress();
            }
        }

        private void SavePlayerProgress()
        {
            PlayerPrefs.SetInt("highestScore", model.highestScore);
        }
    }
}



