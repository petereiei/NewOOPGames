using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spwan : MonoBehaviour {

    Pooler pooler;

    private void Start()
    {
        pooler = Pooler.Instance;

        Debug.Log("bbb");
    }

    void FixedUpdate()
    {
        pooler.SpawnFromPool("Cube", transform.position,Quaternion.identity);
    }
}
