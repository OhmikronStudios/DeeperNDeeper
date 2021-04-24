using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;

public class WinCondition : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera winCam;

    [SerializeField] private float timeToBeat = 10.0f;
    [SerializeField] GameObject GameWinUI;

    private float timeElapsed;
    private bool hasPlayerDied = false;

    [SerializeField] private GameObject ball;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            winCam.Priority = 12;

        }
    }

    private void WinCutscene()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(ball.transform.DOMove(transform.position, 0.3f));
    }
}
