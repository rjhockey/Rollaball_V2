using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    [SerializeField] private Animator doorAnimationController;

    // when Player tag collides, the animation will begin
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorAnimationController.SetBool("moveWall", true);
        }
    }

    // when Player tag leaves collider, the animation will stop
    //private void OnTriggerExit(Collider other)
    //{
      //  if (other.CompareTag("Player"))
        //{
        //    doorAnimationController.SetBool("moveWall", false);
        //}
    // }
}
