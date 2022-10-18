using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{
    public void StartNewGame()
    {
        Debug.Log("Empezando nueva partida...");
        SceneManager.LoadScene("Game");
    }
}
