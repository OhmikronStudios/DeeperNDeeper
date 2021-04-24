using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSystem : MonoBehaviour
{
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


    public void Quit()
    {
        FindObjectOfType<GameManager>().QuitGame();
    }






}
