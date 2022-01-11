using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryGame : MonoBehaviour
{
   
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
}
