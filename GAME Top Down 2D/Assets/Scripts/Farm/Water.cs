using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField] private bool dectingPlayer;
    [SerializeField] private int waterValue;

    private PlayerItens player;
    
    void Start()
    {

        player = FindAnyObjectByType<PlayerItens>();

    }

    
    void Update()
    {
        
        if(dectingPlayer && Input.GetKeyDown(KeyCode.E))
        {

            player.WaterLimit(waterValue);

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {

            dectingPlayer = true;

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {

            dectingPlayer = false;

        }

    }

}
