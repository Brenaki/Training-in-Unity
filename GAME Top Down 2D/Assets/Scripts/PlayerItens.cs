using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItens : MonoBehaviour
{
    [SerializeField] private int totalWood;
    [SerializeField] private float currentWater;
    private float waterLimit = 50;

    public int TotalWood { 
        get => totalWood; 
        set => totalWood = value; 
    }
    public float CurrentWater
    { 
        get => currentWater; 
        set => currentWater = value; 
    }

    public void WaterLimit(float water)
    {

        if(currentWater <= waterLimit)
        {

            currentWater += water;

        }

    }
}
