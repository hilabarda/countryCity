using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    [SerializeField]
    private Image iconsCollectedImage;
    [SerializeField]
    private Text iconsCollectedText;
    [SerializeField]
    private Text playerScoreText;

    [SerializeField]
    private Image countryImage;

    [SerializeField]
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>().GetComponent<GameManager>();
        gameManager.OnIconCollected += ChangeIconsCollectedImage;
        gameManager.OnAllIconsCollected += DisplayWinText;
    }

    private void DisplayWinText()
    {
        ChangeIconsCollectedImage(gameManager.MaxIcons);
    }

    private void ChangeIconsCollectedImage(int icon)
    {
        iconsCollectedText.text = $"Icons Collected:{icon.ToString()}";
        countryImage.color = new Color(100, 50, 100);
       
    }

    private void ScoreText(int score)
    {
        playerScoreText.text = $"Score: {score.ToString()}";
    }


    public void ClickEndGameButtom()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }



}
