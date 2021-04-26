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

    public void OnNextLevelButton()
    {
        SceneManager.LoadScene(NextLevelName);
    }

    public void OnQuitButton()
    {

    }
}
