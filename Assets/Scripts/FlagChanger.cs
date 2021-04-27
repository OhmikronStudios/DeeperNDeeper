using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlagChanger : MonoBehaviour
{
    private void Start()
    {
        MeshRenderer rend = GetComponent<MeshRenderer>();
        rend.material.SetInt("_LevelNumber", SceneManager.GetActiveScene().buildIndex);
    }
}
