using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private MenuSystem menuSystem;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayLevel()
    {
        menuSystem = FindObjectOfType<MenuSystem>();
        SceneManager.LoadScene(menuSystem.chosenLevel);
    }

}
