using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gameOverScoreText;
    ScoreKeeper scoreKeeper;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    // Start is called before the first frame update
    void Start()
    {
        gameOverScoreText.text = "Score:\n" + scoreKeeper.GetScore();
    }
}
