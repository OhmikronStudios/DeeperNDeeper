using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindInfluence : MonoBehaviour
{
    [SerializeField] private float windInfluence;
    private Rigidbody playerRB;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (playerRB == null)
            {
                playerRB = other.GetComponent<Rigidbody>();
            }

            playerRB.AddForce(transform.forward * windInfluence, ForceMode.Acceleration);
        }
    }
}
