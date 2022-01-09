using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text ScoreText;
    private int chestScore;

    void Start()
    {
        //ScoreText = GetComponent<Text>();
        chestScore = 0;
        ScoreText.text = "Chests: " + chestScore;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Chest")
        {
            chestScore += 1;
            Destroy(collision.gameObject);
            ScoreText.text = "Chests: " + chestScore;
        }
    }
}
