using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallPhysics : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float ballSpeed = 5.0f;

    private RaycastHit groundHit;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 desiredRotation = new Vector3(-verticalInput, 0, horizontalInput);
        if (desiredRotation.magnitude > Mathf.Epsilon)
        {
            if (Physics.Raycast(transform.position, Vector3.down, out groundHit, 0.85f))
            {
                Debug.Log("We are hitting the ground");
                Vector3 planeProj = Vector3.ProjectOnPlane(rb.velocity, groundHit.normal);

                Debug.DrawRay(rb.position, planeProj * ballSpeed);

                rb.AddForce(planeProj * ballSpeed, ForceMode.Acceleration);
            }
        }

        //rb.velocity = Vector3.ClampMagnitude(rb.velocity, 10.0f);
    }
}
