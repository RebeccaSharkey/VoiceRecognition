using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SCR_SceneManager: MonoBehaviour
{
    public static SCR_SceneManager sceneManager; 
    
    void Awake()
    {
        if(sceneManager != null)
        {
            GameObject.Destroy(gameObject);
        }
        else
        {
            sceneManager = this;
            DontDestroyOnLoad(this);
        }
    }

    public void LoadNewScene(string nextScene)
    {
        StartCoroutine(LoadingScene(nextScene));
    }

    private IEnumerator LoadingScene(string scene)
    {
        SceneManager.LoadScene("LoadScene");
        yield return new WaitForSeconds(1f);
        AsyncOperation asycOp = SceneManager.LoadSceneAsync(scene);
        while(!asycOp.isDone)
        {
            yield return null;
        }
    }

    public Scene ReturnCurrentScene()
    {
        return SceneManager.GetActiveScene();
    }
}
