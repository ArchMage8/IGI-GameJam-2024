using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    // This method will be called when the button is clicked
    public void Quit()
    {
        #if UNITY_EDITOR
            // If we're in the editor, stop playing the game
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            // If we're in a build, quit the application
            Application.Quit();
        #endif
    }
}
