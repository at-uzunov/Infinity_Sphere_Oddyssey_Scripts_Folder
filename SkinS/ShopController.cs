using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopController : MonoBehaviour
{
  [SerializeField] private Image selectedSkin;
  [SerializeField] private Text coinsText;
  [SerializeField] private Text coinsText2;
  [SerializeField] private Text coinsText3;
  [SerializeField] private SkinManager skinManager;

  void Update()
  {
    coinsText.text = "Coins: " + PlayerPrefs.GetInt("Coins");
    coinsText2.text = "Coins: " + PlayerPrefs.GetInt("Coins");
    coinsText3.text = "Coins: " + PlayerPrefs.GetInt("Coins");
    PlayerPrefs.SetInt("Players", skinManager.GetSelectedSkin().index);
  }

  public void LoadMenu() => SceneManager.LoadScene("MainScene");
}
