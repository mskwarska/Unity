using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    bool gameEnded = false;

    public Text Score;

    //public GameObject completeUI;

    public float restart = 1f;
    /*public void EndGame()
    {
        if(gameEnded == false)
        {
            gameEnded = true;
            Debug.Log("GAME OVER");
            Invoke("Restart", restart);
        }
    }*/
    //


    void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void WinGame()
    {
        Debug.Log("YOU WIN!!");
        //completeUI.SetActive(true);
    }

}
