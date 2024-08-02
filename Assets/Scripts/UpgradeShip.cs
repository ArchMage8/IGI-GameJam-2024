using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradeShip : MonoBehaviour
{
    [SerializeField] int sceneTarget;
    public Animator transition;

    public void Upgrade()
    {
        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {
        transition.SetTrigger("EndOfScene");
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene(sceneTarget);
    }
}
