using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text ScoreText;
    public int chestScore;
    [SerializeField] private AudioClip chestSound;

    void Start()
    {
        chestScore = 0;
        ScoreText.text = chestScore.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Chest")
        {
            SoundManager.instance.PlaySound(chestSound);
            chestScore += 1;
            Destroy(collision.gameObject);
            ScoreText.text = chestScore.ToString();
        }
    }
}
