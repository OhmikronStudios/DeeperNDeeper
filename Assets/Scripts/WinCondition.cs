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


    public bool hasPlayerDied = false;

    [SerializeField] private GameObject ball;

    private System.Func<bool>[] starConditions;
    [SerializeField] private Image[] starImages;



    [SerializeField] private float timeTillStarShowsUp = 0.2f;

    [SerializeField] private float timeTillLevelLoads = 1.2f;
    [SerializeField] string nextLevelScene = "Level_01";

    [SerializeField] Text timerText;


    private bool isLevelCompleted = false;

    private void Start()
    {
        StartCoroutine(DelayedCameraSet());

        if (GameWinUI != null)
            GameWinUI.GetComponent<GameHudScript>().NextLevelName = nextLevelScene;
    }

    private void Update()
    {
        if (!isLevelCompleted)
        {
            timeElapsed += Time.deltaTime;
            timerText.text = GetTime();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            winCam.Priority = 12;
            isLevelCompleted = true;
            StartCoroutine(LoadLevelWithDelay());
            GameWinUI.SetActive(true);
            GameWinUI.GetComponent<GameHudScript>().UpdateStars(CheckStars());
        }
    }

    public string GetTime()
    {
        float seconds = Mathf.RoundToInt(timeElapsed % 60);
        return seconds.ToString();
    }

    private int CheckStars()
    {
        int stars = 0;

        if (!hasPlayerDied)
            stars++;

        if (timeElapsed < timeToBeat)
            stars++;

        return stars;
    }

    private IEnumerator LoadLevelWithDelay()
    {
        yield return new WaitForSeconds(timeTillLevelLoads);

        int index = SceneManager.GetActiveScene().buildIndex + 1;

        if (index >= SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(0);
        }

        SceneManager.LoadScene(index);

        
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
