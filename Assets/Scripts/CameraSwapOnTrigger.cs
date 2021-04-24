using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwapOnTrigger : MonoBehaviour
{
    [SerializeField] private bool exitCameraOnTriggerExit = false;
    [SerializeField] private CinemachineVirtualCamera lookAtCamera;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            lookAtCamera.Priority = 13;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && exitCameraOnTriggerExit)
        {
            lookAtCamera.Priority = 9;
        }
    }
}
