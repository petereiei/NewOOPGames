using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class testANEnemy : MonoBehaviour {

    Animation am;

	// Use this for initialization
	void Start () {
        am = GetComponent<Animation>();

    }
	
	// Update is called once per frame
	void Update () {
        am.Play("Attack_01");
	}
}
