using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadNext : MonoBehaviour
{
    [SerializeField] int sceneTarget;
    public Animator transition;
    private GameObject winHandler;
    public bool isNextSceneWin;



    private void Awake()
    {
        Debug.Log("test");

    }

    public void NextScene()
    {
        if (isNextSceneWin)
        {
            winHandler = WinHandler.instance.gameObject;

            Image image = winHandler.GetComponentInChildren<Image>();
            Color color = image.color;
            color.a = 0;
            image.color = color;

            winHandler.SetActive(true);
            Debug.Log("Potato");
           
        }
        StartCoroutine(LoadScene());

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
            yield return new WaitForSeconds(1.4f);
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
            Debug.Log("piss");
            winHandler = WinHandler.instance.gameObject;
            WinHandler.instance.CallEnding();
         
            yield return new WaitForSeconds(1.8f);
            SceneManager.LoadScene(sceneTarget);

            AudioManager.Instance.StopMusic();
            AudioManager.Instance.PlayMusic("End");
        }
    }
}
