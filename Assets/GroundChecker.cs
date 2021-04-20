using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{

    [SerializeField] PlayerController playerController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            return;
        }
        playerController.isGrounded = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            return;
        }
        playerController.isGrounded = true;

    }

    private void OnTriggerExit(Collider other)
    {
        playerController.isGrounded = false;

    }
}
