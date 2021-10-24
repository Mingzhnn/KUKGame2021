using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Door doori;
    public bool playerStay = false;
    public GameObject canvas;

    private void Update()
    {
        canvas.SetActive(playerStay);
        if (playerStay && Input.GetKeyDown(KeyCode.E))
        {
            doori.doorOpen = !doori.doorOpen;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") ;
        {
            playerStay = true;
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") ;
        {
            playerStay = false;
        }
    }
}
