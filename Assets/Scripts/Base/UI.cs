using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text_score;
    [SerializeField]
    private TextMeshProUGUI text_lives;
    [SerializeField]
    private TextMeshProUGUI text_pause;
    [SerializeField]
    private TextMeshProUGUI text_gameOver;

    public void UpdateDisplay(int score, int lives)
    {
        text_score.text = "Punkte: " + score;
        text_lives.text = "Leben: " + lives;
        text_gameOver.text = "Game Over!\n" + score;
    }

    public void ShowPause(bool show)
    {
        text_pause.gameObject.SetActive(show);
    }

    public void ShowGameOver(bool show)
    {
        text_gameOver.gameObject.SetActive(show);
    }
}
