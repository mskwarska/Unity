using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text ScoreText;
    private int chestScore;
    [SerializeField] private AudioClip chestSound;

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
            SoundManager.instance.PlaySound(chestSound);
            chestScore += 1;
            Destroy(collision.gameObject);
            ScoreText.text = "Chests: " + chestScore +"/50";
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Chest"))
        {
            SoundManager.instance.PlaySound(chestSound);//nie wiem czy tu potrzebne ?
        }
    }
}
