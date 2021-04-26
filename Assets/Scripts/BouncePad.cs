using System.Collections;
using UnityEngine;
using DG.Tweening;
using Cinemachine;

public class BouncePad : MonoBehaviour
{
    [SerializeField] private float knockBackForce = 45;

    [SerializeField] float scaleModifier = 1.2f;
    [SerializeField] float scaleDuration = 0.4f;

    [SerializeField] float coolDownDuration = 1f;

    [SerializeField] ParticleSystem rippleFX;

    private bool canKnock = true;

    private AudioCue audioPlayer;

    private CinemachineImpulseSource impulse;

    private void OnCollisionEnter(Collision collision)
    {
        if (canKnock == false) return;

        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

        if (rb != null)
        {
            Debug.Log("Bounce pad is colliding with player");
            Vector3 knockBack = collision.GetContact(0).normal * knockBackForce;
            Debug.DrawLine(transform.position, transform.position + knockBack);

            if (audioPlayer == null)
                audioPlayer = GetComponent<AudioCue>();

            if (audioPlayer != null)
                audioPlayer.PlayAudioCue();


                

            Transform child = transform.GetChild(0);
            if (child != null)
            child.DOPunchScale(child.localScale * scaleModifier, scaleDuration, 4, 1).SetEase(Ease.OutElastic);

            rippleFX.Play();

            rb.AddForce(knockBack, ForceMode.Impulse);
            canKnock = false;
            StartCoroutine(CoolDown());
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            if (impulse == null)
                impulse = GetComponent<CinemachineImpulseSource>();

            if (impulse != null)
            {
                impulse.GenerateImpulse(knockBackForce / 10);
                Debug.Log("Generating Impulse");
            }
        }
    }

    private IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(coolDownDuration);
        canKnock = true;
    }

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, knockBackForce / 10);
    }

#endif
}
