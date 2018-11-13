using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityStandardAssets.CrossPlatformInput;


namespace AppGames.Script.View
{

    [System.Serializable]
    public class ColliderEvent : UnityEvent<Collider> { }

    [System.Serializable]
    public class InputPhysicsEvent : UnityEvent<float> { }


    public class PlayerView : MonoBehaviour
    {

        [SerializeField]
        public InputPhysicsEvent OnHorizontalInputEvents;

        [SerializeField]
        public ColliderEvent OnCollierEvents;

        public UnityEvent OnAttackEvent;

        public Animator animator;

        public bool Attack = false;
        public bool Land = false;
        bool TimeAttack = false;

        public float AttackTime;

        private void Start()
        {
            Land = false;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                Land = true;
            }

            HandleAttackInput();
           // TimeAnimator();

        }

        private void FixedUpdate()
        {
            if (!Attack)
            {
                HandleMovement();
            }


            /*
            if (Land)
            {
                animator.SetTrigger("Land");
                Land = false;
                Debug.Log("Land animator");
            }*/
            // HandleAttackInput();

            //HandleAttacks();
            if (Attack == true)
            {
                AttackTime -= Time.deltaTime;
            }
            
            if (AttackTime <= 0.0f)
            {
                //TimeAttack = true;
                AttackTime = 0.5f;
                ResetValues();
            }
            //TimeAnimator();
            //ResetValues();
        }

        private void TimeAnimator()
        {
            if (Attack)
            {
                Debug.Log("time ---");
                AttackTime -= Time.deltaTime;
                ResetValues();
            }
           
        }

        private void HandleMovement()
        {
            float h = CrossPlatformInputManager.GetAxisRaw("Horizontal");

            animator.SetFloat("Run", Mathf.Abs(h));

            OnHorizontalInputEvents.Invoke(h);

        }

        void HandleAttackInput()
        {
            if (CrossPlatformInputManager.GetButtonDown("Attack"))
            {
                Debug.Log("attack event");
                animator.SetTrigger("Attack");
                OnAttackEvent.Invoke();
                Attack = true;
            }
        }
        /*
        void HandleAttacks()
        {
            if (Attack)
            {
                animator.SetTrigger("Attack");
                Debug.Log("attack animator");

            }
        }*/

        private void ResetValues()
        {
            Attack = false;
        }

        void OnTriggerEnter(Collider other)
        {
            OnCollierEvents.Invoke(other);
        }


    }
}



