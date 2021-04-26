using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindInfluence : MonoBehaviour
{
    [SerializeField] private float windInfluence;
    private Rigidbody playerRB;

    [SerializeField] private AudioCue audioCue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (audioCue != null)
                audioCue.PlayAudioCue();
        }
    }

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
