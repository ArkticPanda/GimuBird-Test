using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    private int coinTotal;

    // Start is called before the first frame update
    void Start()
    {
        coinTotal = PlayerPrefs.GetInt("CumulativeScore", 0);
        UpdateScoreText();
    }

    public void IncrementScore(int coinIncrement)
    {
        coinTotal += coinIncrement;
        UpdateScoreText();

        PlayerPrefs.SetInt("CumulativeScore", coinTotal);
        PlayerPrefs.Save();
    }

    void UpdateScoreText()
    {
        scoreText.text = coinTotal.ToString();
    }

    public int GetCoinCount()
    {
        return coinTotal;
    }
}
