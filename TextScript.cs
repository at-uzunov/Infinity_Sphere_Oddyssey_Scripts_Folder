using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    public Text high_score;
    public Text current_score;
    public Text current_coins;
    public Text pause_menu_score;
    public Text shields;
    // Start is called before the first frame update
    void Start()
    {
        if (current_score != null)
        {
            PlayerPrefs.SetInt("Current_Score", 0);
        }

    }
    void Update()
    {
        if (high_score != null)
        {
            int high_score_value = PlayerPrefs.GetInt("High_Score");
            int current_score_value = PlayerPrefs.GetInt("Current_Score");
            if(current_score_value > high_score_value)
            {
                PlayerPrefs.SetInt("High_Score", current_score_value);
            }
            high_score.text = "Best: " + PlayerPrefs.GetInt("High_Score");
        }
        if(current_score != null)
        {
            current_score.text = "Score: " + PlayerPrefs.GetInt("Current_Score");
        }
        if(current_coins != null)
        {
            current_coins.text = PlayerPrefs.GetInt("Coins").ToString();
        }
        if (pause_menu_score != null)
        {
            pause_menu_score.text = "Score: " + PlayerPrefs.GetInt("Current_Score");
        }
        if(shields != null)
        {
            shields.text = PlayerPrefs.GetInt("Shields").ToString();
        }
    }
}
