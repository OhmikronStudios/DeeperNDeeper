using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{
    [SerializeField] private float knockBackForce = 45;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

            if (rb != null)
            {
                Debug.Log("Bounce pad is colliding with player");
                Vector3 knockBack = collision.GetContact(0).normal * knockBackForce;
                Debug.DrawLine(transform.position, transform.position + knockBack);


                rb.AddForce(knockBack, ForceMode.Impulse);
            }
        }
    }
}
