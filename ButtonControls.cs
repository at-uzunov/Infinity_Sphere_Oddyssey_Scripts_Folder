using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControls : MonoBehaviour
{
    string skin_select = "";
    void Awake()
    {
        skin_select = gameObject.name;
    }
    public void setSelectedSkin()
    {
        Debug.Log(skin_select);
        if(skin_select == "Skin 1")
        {
            PlayerPrefs.SetInt("Players", 0);
        }
        if(skin_select == "Blue Skin")
        {
            PlayerPrefs.SetInt("Players", 1);
        }
    }

    public void GoToShop()
    {
        Time.timeScale = 1;
        string load_scene = "Shop_View";
        SceneManager.LoadScene(load_scene);
        Debug.Log(load_scene);
    }
    public void GoToGame()
    {
        Time.timeScale = 1;
        string load_scene = "MainScene";
        SceneManager.LoadScene(load_scene);
    }
    public void GoToStore()
    {
        Time.timeScale = 1;
        string load_scene = "Donate";
        SceneManager.LoadScene(load_scene);
    }

}
