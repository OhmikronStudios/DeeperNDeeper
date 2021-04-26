using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MapRotation : MonoBehaviour
{
    [Range(0, 45)]public int tiltRotation;
    [Range (0.1f, 1f)]public float tiltWorldSpeed;
    [Range(0.1f, 1f)] public float tiltPlayerSpeed;

    [SerializeField] CinemachineVirtualCamera playerCam;
    [SerializeField] CinemachineVirtualCamera mapCam;

    private bool isPlayerCam = false;

    [SerializeField] Transform spawnPos;
    [SerializeField] GameObject playerBall;

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            ToggleCamera();
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (horizontalInput != Mathf.Epsilon || verticalInput != Mathf.Epsilon)
        {
            float tiltSpeed = isPlayerCam ? tiltPlayerSpeed : tiltWorldSpeed;

            Vector3 desiredRotation = new Vector3(-verticalInput, 0, horizontalInput) * tiltRotation;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(desiredRotation), tiltSpeed);

            //transform.RotateAround(Vector3.zero, desiredRotation, 1);
        }
    }

    private void ToggleCamera()
    {
        isPlayerCam = !isPlayerCam;

        playerCam.Priority = isPlayerCam ? 11 : 10;
        mapCam.Priority = isPlayerCam ? 10 : 11;
    }

    public void RespawnPlayer()
    {
        playerBall.transform.position = spawnPos.position;
    }

}
