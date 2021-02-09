using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public CraneMove crane;
    public DeleteAndScore killScript;

    private float maxTime, currentTime;
    private string winner;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI winText;
    public Image timerImage;          

    private void Start()
    {
        maxTime = 120f;
        currentTime = maxTime;

        timerImage.fillAmount = (currentTime / 120f);
    }


    private void FixedUpdate()
    {
        if(currentTime >= 0.01)
        {
            currentTime -= 1 * Time.deltaTime;
            timerText.text = currentTime.ToString("F0");

            timerImage.fillAmount = (currentTime / 120);
        }
        else
        {
            if(crane.playerScore > crane.AIScore)
            {
                winner = "Blue Player Wins.";
            }
            else if(crane.playerScore <= crane.AIScore)
            {
                winner = "Red Player Wins.";
            }
            else
            {
                winner = "Neither of you win Employee of the month.";
            }

            killScript.Die();
            winText.text = "Shift Over! " + winner;
        }
}

}
