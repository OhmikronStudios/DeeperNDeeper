using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameHudScript : MonoBehaviour
{
    public string NextLevelName;

    [SerializeField] private Transform buttonsPanel;
    [SerializeField] private Transform starsPanel;
    [SerializeField] private Image[] stars;

    [SerializeField] private Sprite highlightStar;

    private void Start()
    {
        stars = starsPanel.GetComponentsInChildren<Image>();
    }

    private void OnEnable()
    {
        starsPanel.DOScale(Vector3.one, 0.5f).From(Vector3.zero);
        buttonsPanel.DOScale(Vector3.one, 0.5f).From(Vector3.zero);
    }

    public void OnRestartButton()
    {
        string scene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(scene);
    }

    public void UpdateStars(int numberOfStars)
    {
        for (int i = 0; i <= numberOfStars; i++)
        {
            stars[i].sprite = highlightStar;
        }
    }

    public void OnNextLevelButton()
    {
        SceneManager.LoadScene(NextLevelName);
    }

    public void OnQuitButton()
    {

    }
}
