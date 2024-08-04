using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNext : MonoBehaviour
{
    [SerializeField] int sceneTarget;
    public Animator transition;
    private GameObject winHandler;
    public bool isNextSceneWin;


    public void NextScene()
    {
        StartCoroutine(LoadScene());

    }
    private void Start()
    {
        winHandler = WinHandler.instance.gameObject;
        winHandler.SetActive(false);
    }
    public void Upgrade()
    {
        AudioManager.Instance.PlaySFX("Upgrade");
        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {
        if (!isNextSceneWin)
        {
            transition.SetTrigger("EndOfScene");
            yield return new WaitForSeconds(1.2f);
            SceneManager.LoadScene(sceneTarget);

        switch (sceneTarget)
        {
        case 6:
            AudioManager.Instance.StopMusic();
            break;
        case 5:
            AudioManager.Instance.StopMusic();
            break;
        case 4:
            AudioManager.Instance.StopMusic();
            AudioManager.Instance.PlayMusic("Lv3");
            break;
        case 3:
            AudioManager.Instance.StopMusic();
            AudioManager.Instance.PlayMusic("Lv2");
            break;
        case 2:
            AudioManager.Instance.StopMusic();
            AudioManager.Instance.PlayMusic("Lv1");
            break;
        default:
            break;
        }

        }

        else if (isNextSceneWin)
        {
            winHandler.SetActive(true);
            WinHandler.instance.CallEnding();
            yield return new WaitForSeconds(1.2f);
            SceneManager.LoadScene(sceneTarget);

            AudioManager.Instance.StopMusic();
            AudioManager.Instance.PlayMusic("End");
        }
    }
}
