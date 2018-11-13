using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AppGames.Script
{
    public class PlayerMove : MonoBehaviour
    {

        public float Speed = 1f;
       // public CharacterController contoroller;
        public Animator animator;

        //float horizontalMove = 0f;
        private Rigidbody rb;
        private Transform platerTransform;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            float horizontalMoveH = Input.GetAxisRaw("Horizontal") * Speed;

            Vector3 movement = new Vector3(horizontalMoveH,0.0f,0.0f);

            rb.velocity = movement;
            animator.SetFloat("Run", Mathf.Abs(horizontalMoveH));

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                rb.rotation = Quaternion.LookRotation(Vector3.left);
                //animator.SetFloat("Run", Mathf.Abs(horizontalMoveH));
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                rb.rotation = Quaternion.LookRotation(Vector3.right);
                //animator.SetFloat("Run", Mathf.Abs(horizontalMoveH));
            }

        }

        

    }
}

