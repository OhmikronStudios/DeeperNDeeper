using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindInfluence : MonoBehaviour
{
    [SerializeField] private float windInfluence;
    private Rigidbody playerRB;

    [SerializeField] private AudioCue audioCue;

    [SerializeField] private AnimationCurve windInfluenceOverDistance;
    [SerializeField] private float MaxDistance;

    private void Start()
    {
        BoxCollider box = GetComponent<BoxCollider>();
        MaxDistance = box.size.z;
    }

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

            float distance = Vector3.Distance(transform.position, playerRB.position);
            float windInfluenceWithMod = windInfluenceOverDistance.Evaluate(distance / MaxDistance);
            windInfluenceWithMod *= windInfluence;

            playerRB.AddForce(transform.forward * windInfluenceWithMod, ForceMode.Acceleration);
        }
    }
}
