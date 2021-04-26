using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private float coolDownDuration = 3.0f;
    [SerializeField] Teleporter secondLink;

    private bool canTeleport = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canTeleport)
        {
            canTeleport = false;
            secondLink.canTeleport = false;
            other.transform.position = secondLink.transform.position;
            StartCoroutine(Cooldown());
        }
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(coolDownDuration);
        secondLink.canTeleport = true;
        canTeleport = true;
    }

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        if (secondLink != null)
            Gizmos.DrawLine(transform.position, secondLink.transform.position);
    }

#endif
}
