using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsController : MonoBehaviour {

    private const int START_SCENE_IDX = 0;

    public void BackToHome() {
        FindObjectOfType<MusicPersist>().StopAudio();
        StartCoroutine(BackToHomeCoroutine());
    }

    IEnumerator BackToHomeCoroutine() {
        FindObjectOfType<ScenesManager>().LoadScene(START_SCENE_IDX);
        yield return null;
    }
}
