using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingController : MonoBehaviour {

    [SerializeField] private GameObject goodEnd;
    [SerializeField] private GameObject badEnd;
    [SerializeField] private AudioClip goodEndSong;
    [SerializeField] private AudioClip badEndSong;
    [SerializeField] private AudioClip wind;

    private const int CREDITS_SCENE_IDX = 4;

    private void Awake() {
        FindObjectOfType<MusicPersist>().ChangeAudioClip(wind);
    }

    private void Start() {
        StartCoroutine(ShowEnd());
    }

    IEnumerator ShowEnd() {
        yield return new WaitForSeconds(3f);
        GamePersist gamePersist = FindObjectOfType<GamePersist>();
        if (gamePersist.GetBad() > gamePersist.GetGood()) {
            FindObjectOfType<MusicPersist>().ChangeAudioClip(badEndSong);
            badEnd.SetActive(true);
        } else {
            FindObjectOfType<MusicPersist>().ChangeAudioClip(goodEndSong);
            goodEnd.SetActive(true);
        }
        yield return new WaitForSeconds(10);
        FindObjectOfType<ScenesManager>().LoadScene(CREDITS_SCENE_IDX);
    }

}
