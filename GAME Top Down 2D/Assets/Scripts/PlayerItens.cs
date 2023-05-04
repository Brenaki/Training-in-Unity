using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItens : MonoBehaviour
{
    [Header("Amouts")]
    [SerializeField] private int totalWood;
    [SerializeField] private float currentWater;
    [SerializeField] private int carrots;

    [Header("Limits")]
    public float waterLimit = 50;
    public float carrotLimit = 10;
    public float woodLimit = 5;

    public int TotalWood 
    { 
        get => totalWood; 
        set => totalWood = value; 
    }
    public float CurrentWater
    { 
        get => currentWater; 
        set => currentWater = value; 
    }
    public int Carrots 
    { 
        get => carrots; 
        set => carrots = value; 
    }

    public float WaterLimit1
    { 
        get => waterLimit; 
        set => waterLimit = value; 
    }
    public float CarrotLimit 
    { 
        get => carrotLimit; 
        set => carrotLimit = value; 
    }
    public float WoodLimit 
    { 
        get => woodLimit; 
        set => woodLimit = value; 
    }

    public void WaterLimit(float water)
    {

        if(currentWater <= WaterLimit1)
        {

            currentWater += water;

        }

    }
}
