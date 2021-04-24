using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSystem : MonoBehaviour
{
    public string chosenLevel;
    [SerializeField] Image levelImage;
    [SerializeField] Sprite baseLevelImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MenuPanelSwitch(GameObject On_obj)
    {
        On_obj.SetActive(true);
        //Off_obj.SetActive(false); 
    }


    public void QuitGame()
    {
        FindObjectOfType<GameManager>().QuitGame();
    }

    public void SelectLevel(string level)
    {
        chosenLevel = level;
    }

    public void SelectImage(Sprite image)
    {
        if (image != null)
        {
            levelImage.sprite = image;
        }
        else
        {
            levelImage.sprite = baseLevelImage;
        }
    }


    



}
