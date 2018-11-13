using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AppGames.Script.View;


namespace AppGames.Script
{
    public class TrollEnemy : MonoBehaviour
    {
        Enemy Troll = new Enemy();
        Animation Troll_animation;
        SpawnerEnemy SE;
        PlayerView playerView;

        int ScoreTroll = 100;
        int HP_Enemy = 10;
        int ScoreValue = 100;
        float Speeds = 2.5f;

        private Transform Target;

        public float AttackTime = 0.8f;
        public bool OnAttack = false;

       // public GameObject sptrool;
        public GameObject ViewObject;
        public GameObject SpawnTroll;


        private void Awake()
        {
            Troll_animation = GetComponent<Animation>();

            Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            

            Troll.HP = 10;
            Troll.Speed = 2.0f;
        }

        public void Start()
        {
            //playerView = GetComponent<PlayerView>();
            //sptrool = GameObject.Find("SpwanTroll");
            //se = sptrool.GetComponent<SpawnerEnemy>();
            SpawnTroll = GameObject.Find("SpwanTroll");
            SE = SpawnTroll.GetComponent<SpawnerEnemy>();

            ViewObject = GameObject.Find("Player/View/unitychan");
            // playerController = gameObject.GetComponent<PlayerController>();
            playerView = ViewObject.GetComponent<PlayerView>();


            Debug.Log("HP " + Troll.HP);
            Debug.Log("Speed " + Troll.Speed);
        }

        private void Update()
        {
            Troll.GetScore(ScoreTroll);
            transform.LookAt(Target);

            if (OnAttack == true)
            {
                AttackTime -= Time.deltaTime;
            }

            if (AttackTime <= 0.0f)
            {
                //TimeAttack = true;
                AttackTime = 1.4f;
                ResetValues();
            }
        }

        private void FixedUpdate()
        {
            if (Vector3.Distance(transform.position, Target.position) > 1.2f)
            {
                transform.position = Vector3.MoveTowards(transform.position,Target.position, Troll.Speed * Time.deltaTime);
            }

            AttackPlayer();


            if (Input.GetKeyDown(KeyCode.X))
            {
                SE.countTroll--;
                gameObject.SetActive(false);
            }
        }

        /*
        private void OnTriggerStay(Collider other)
        {
            Debug.Log("attackPlayer1");
            if (other.tag == "Player")
            {
                Debug.Log("attackPlayer2");
                OnAttack = true;
            }
        }
        */
        void AttackPlayer()
        {
            if (OnAttack == true)
            {
                Debug.Log("Attack01");
                Troll_animation.Play("Attack_01");

            }
            else if(OnAttack == false)
            {
                Debug.Log("Walk");
                Troll_animation.Play("Walk");
            }
        }

        public  void OnTriggerEnter(Collider other)
        {
            Debug.Log("enemy hp On Trigger");
            if (other.tag == "Attack" && playerView.Attack == true)
            {
                Debug.Log("enemy hp --");
                Troll_animation.Play("Hit");
                HP_Enemy -= 10;
                SE.countTroll--;
                Debug.Log("HP Enemy : " + HP_Enemy);
                gameObject.SetActive(false);
                Score.score += ScoreValue;
            }
        }

        public void OnTriggerStay(Collider other)
        {
            if (other.tag == "Player")
            {
                OnAttack = true;
            }
            if (other.tag == "PLayer")
            {
                Debug.Log(" Troll Attack ");
            }
        }

        void ResetValues()
        {
            OnAttack = false;
        }
    }
}
    
