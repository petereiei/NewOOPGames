using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    public Image ImageHealtBar;

    private int Min = 0;
    private int Max = 100;
    private int CurrentValue;

    private float CurrentPercent;



	public void SetHealth(int health)
    {
        if (Max - Min == 0)
        {
            CurrentValue = 0;
            CurrentPercent = 0;
        }
        else
        {
            CurrentValue = health;

            CurrentPercent = (float)CurrentValue / (float)(Max - Min);


        }

        ImageHealtBar.fillAmount = CurrentPercent;
    }

    public float mmCurrentPercent
    {
        get{ return CurrentPercent; }
    }

    public float mmCurrentValue
    {
        get { return CurrentValue; }
    }

    private void Start()
    {
        //SetHealth(50);
    }

}
