using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour {

    Pooler objectPooler;

    public Transform[] point;

    int number;
    public int countTroll;
    float number2 = 1.5f;

    private void Start()
    {
        objectPooler = Pooler.Instance;
    }

    private void FixedUpdate()
    {
        number2 -= Time.deltaTime;
        
        //number2 = Random.Range(0, 1);
        if (number2 <= 0 && countTroll <= 4)
        {
            numberTime();
            objectPooler.SpawnFromPool("Troll", point[number].position, Quaternion.identity);
            countTroll++;
            number2 = 1.5f;
        }


       
    }

    void numberTime()
    {
        number = Random.Range(0, 2);
        Debug.Log("number :" + number);
    }

}
