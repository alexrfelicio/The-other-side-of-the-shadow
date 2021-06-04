using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenesManager : MonoBehaviour {

    private const int START_SCENE_IDX = 0;
    private const int GAME_SCENE_IDX = 1;
    private const int TANGRAM_SCENE_IDX = 2;
    private const int ENDING_SCENE_IDX = 3;
    private const int CREDITS_SCENE_IDX = 4;

    private readonly string START_SCENE = "Start Scene";
    private readonly string GAME_SCENE = "Game Scene";
    private readonly string TANGRAM_SCENE = "Tangram Scene";
    private readonly string ENDING_SCENE = "Ending Scene";
    private readonly string CREDITS_SCENE = "Credits Scene";

    public void StartScene() {
        SceneManager.LoadScene(START_SCENE);
    }

    public void LoadScene(int scene) {
        string sceneToLoad = null;
        switch(scene) {
            case START_SCENE_IDX:
                sceneToLoad = START_SCENE;
                break;
            case GAME_SCENE_IDX:
                sceneToLoad = GAME_SCENE;
                break;
            case TANGRAM_SCENE_IDX:
                sceneToLoad = TANGRAM_SCENE;
                break;
            case ENDING_SCENE_IDX:
                sceneToLoad = ENDING_SCENE;
                break;
            case CREDITS_SCENE_IDX:
                sceneToLoad = CREDITS_SCENE;
                break;
            default:
                Debug.LogError("No scene to load for: " + scene);
                break;
        }
        if (sceneToLoad != null) {
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    public void test (Image img, int test)
    {

    }

    public void QuitGame() {
        Application.Quit();
    }

}
