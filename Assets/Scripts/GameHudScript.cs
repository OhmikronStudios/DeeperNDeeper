using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHudScript : MonoBehaviour
{
    [SerializeField] private string NextLevelName;

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
