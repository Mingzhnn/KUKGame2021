using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool doorOpen = false;
    Animator animator;
    public GameObject door;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        animator.SetBool("doorOpen", doorOpen);
        //door.SetActive(!doorOpen);
    }


}
