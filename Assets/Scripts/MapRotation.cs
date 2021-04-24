using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRotation : MonoBehaviour
{
    [Range(0, 45)]public int tiltRotation;
    [Range (0.1f, 1f)]public float tiltSpeed; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 desiredRotation = new Vector3(horizontalInput, 0, verticalInput)* tiltRotation;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(desiredRotation), tiltSpeed); 
    }
}
