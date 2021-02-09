using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DeleteAndScore : MonoBehaviour
{
    //varibles
    public CraneMove crane; // access crane movement script for player score
    public AnimationQuitGame quitGameScript;
    public GameObject playerScore, playerBillboardScreen; //access billboards to lock transform position
    public GameObject AIScore, AIBillboardScreen; //

    public Color green, red;

    //FADE PANNEL ON DEATH
    

    private void Start()
    {
        playerScore.GetComponent<TextMeshProUGUI>().text = "Score: " + crane.playerScore;
        AIScore.GetComponent<TextMeshProUGUI>().text = "Score: " + crane.AIScore;

        playerScore.transform.position = new Vector3(playerBillboardScreen.transform.position.x, playerBillboardScreen.transform.position.y, playerBillboardScreen.transform.position.z + 0.5f);
        AIScore.transform.position = new Vector3(AIBillboardScreen.transform.position.x +2f, AIBillboardScreen.transform.position.y, AIBillboardScreen.transform.position.z + 1f);
    }




    private void OnTriggerEnter(Collider other)
    {
        //Player Green Score and removing lives for GreenBox mistakes
        if (other.tag == "BoxGreen")
        {
            if(this.gameObject.tag == "ScoreGreen" && this.gameObject.name == "PlayerGreenZone")
            {
                crane.playerScore = crane.playerScore + crane.greenScore;
                Destroy(other.gameObject);
                playerScore.GetComponent<TextMeshProUGUI>().text = "Score: " + crane.playerScore;

            }            

            if(this.gameObject.tag == "ScoreRed" && this.gameObject.name == "PlayerRedZone")
            {
                crane.playerLives = crane.playerLives - 1;
                Destroy(other.gameObject);
                if (crane.playerLives <= 0)
                {
                    Die();
                }
            }



            //AI GREEN SCORE
            if (this.gameObject.tag == "ScoreGreen" && this.gameObject.name == "AIGreenZone")
            {
                crane.AIScore = crane.AIScore + crane.greenScore;
                Destroy(other.gameObject);
                AIScore.GetComponent<TextMeshProUGUI>().text = "Score: " + crane.AIScore;

            }
        }


        //Player Red Score and removing lives for RedBox mistakes
        if (other.tag == "BoxRed")
        {
            if (this.gameObject.tag == "ScoreRed" && this.gameObject.name == "PlayerRedZone")
            {
                crane.playerScore = crane.playerScore + crane.redscore;
                Destroy(other.gameObject);
                playerScore.GetComponent<TextMeshProUGUI>().text = "Score: " + crane.playerScore;
            }

            if (this.gameObject.tag == "ScoreGreen" && this.gameObject.name == "PlayerGreenZone")
            {
                crane.playerLives = crane.playerLives - 1;
                Destroy(other.gameObject);
                if(crane.playerLives <= 0)
                {
                    Die();
                }
            }


            //AI RED SCORE
            if (this.gameObject.tag == "ScoreRed" && this.gameObject.name == "AIRedZone")
            {
                crane.AIScore = crane.AIScore + crane.redscore;
                Destroy(other.gameObject);
                AIScore.GetComponent<TextMeshProUGUI>().text = "Score: " + crane.AIScore;

            }
        }
    }


    public void Die()
    {
        quitGameScript.FadeOut();
    }

    

    private void Quit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
