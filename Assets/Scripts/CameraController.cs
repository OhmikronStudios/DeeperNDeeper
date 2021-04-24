using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class CameraController : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera playerCam;
    [SerializeField] CinemachineVirtualCamera mapCam;

    private bool isPlayerCam;

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            ToggleCamera();
        }
    }

    private void ToggleCamera()
    {
        isPlayerCam = !isPlayerCam;

        playerCam.Priority = isPlayerCam ? 11 : 10;
        mapCam.Priority = isPlayerCam ? 10 : 11;
    }
}
