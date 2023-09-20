using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public static void LoadSceneSingle(string sceneName){
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public static void LoadSceneAdd(string sceneName){
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }

    public static AsyncOperation LoadSceneSingleAsync(string sceneName, bool isActive){
        var scene = SceneManager.LoadSceneAsync(sceneName,LoadSceneMode.Single);
        scene.allowSceneActivation = isActive;

        return scene;
    }

    public static AsyncOperation LoadSceneAddAsync(string sceneName, bool isActive){
        var scene = SceneManager.LoadSceneAsync(sceneName,LoadSceneMode.Additive);
        scene.allowSceneActivation = isActive;

        return scene;
    }

    public static void UnloadSceneAsync(string sceneName){
        SceneManager.UnloadSceneAsync(sceneName);
    }
}
