using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNext : MonoBehaviour
{
    [SerializeField] int sceneTarget;
    public Animator transition;

    public bool isNextSceneWin;

    public void Upgrade()
    {
        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {
        if (!isNextSceneWin)
        {
            transition.SetTrigger("EndOfScene");
            yield return new WaitForSeconds(1.2f);
            SceneManager.LoadScene(sceneTarget);
        }

        else if (isNextSceneWin)
        {
            WinHandler.instance.CallEnding();
            yield return new WaitForSeconds(1.2f);
            SceneManager.LoadScene(sceneTarget);
        }
    }
}
