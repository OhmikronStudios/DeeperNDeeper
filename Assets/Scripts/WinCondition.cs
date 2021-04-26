using System.Collections;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class WinCondition : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera winCam;

    [SerializeField] private float timeToBeat = 10.0f;
    private float timeElapsed;

    [SerializeField] GameObject GameWinUI;


    private bool hasPlayerDied = false;

    [SerializeField] private GameObject ball;

    private System.Func<bool>[] starConditions;
    [SerializeField] private Image[] starImages;



    [SerializeField] private float timeTillStarShowsUp = 0.2f;

    [SerializeField] private float timeTillLevelLoads = 1.2f;
    [SerializeField] string nextLevelScene = "Level_01";

    private void Start()
    {
        StartCoroutine(DelayedCameraSet());
        starConditions = new System.Func<bool>[3];

        starConditions[0] = () => true;
        starConditions[1] = () => timeElapsed <= timeToBeat;
        starConditions[2] = () => hasPlayerDied;

        if (GameWinUI != null)
            GameWinUI.GetComponent<GameHudScript>().NextLevelName = nextLevelScene;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            winCam.Priority = 12;
            StartCoroutine(LoadLevelWithDelay());
            GameWinUI.SetActive(true);
        }
    }

    private void WinCutscene()
    {
        
    }

    private IEnumerator LoadLevelWithDelay()
    {
        yield return new WaitForSeconds(timeTillLevelLoads);
        SceneManager.LoadScene(nextLevelScene);
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

            else 
            {
                // Show Dark Star
            }
        }
    }

    private IEnumerator DelayedCameraSet()
    {
        yield return new WaitForSeconds(0.85f);
        Debug.Log("Camera should be reset");
        winCam.Priority = 9;
    }
}
