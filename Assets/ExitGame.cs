using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void Exit()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
