using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;

public class WinCondition : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera winCam;

    [SerializeField] private float timeToBeat = 10.0f;
    private float timeElapsed;

    [SerializeField] GameObject GameWinUI;


    private bool hasPlayerDied = false;

    [SerializeField] private GameObject ball;

    private System.Func<bool>[] starConditions;
    [SerializeField] private float timeTillStarShowsUp = 0.2f;

    private void Start()
    {
        starConditions = new System.Func<bool>[3];

        starConditions[0] = () => true;
        starConditions[1] = () => timeElapsed <= timeToBeat;
        starConditions[2] = () => hasPlayerDied;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            winCam.Priority = 12;

        }
    }

    private void WinCutscene()
    {
        
    }

    private IEnumerator DisplayStars()
    {
        foreach (var condition in starConditions) 
        {
            if (condition() == true)
            {
                // Highlight Star
                yield return new WaitForSeconds(timeTillStarShowsUp);
            }
        }
    }
}
