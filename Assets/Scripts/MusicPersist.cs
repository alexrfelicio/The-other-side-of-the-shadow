using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPersist : MonoBehaviour {
    public static MusicPersist Instance { get; private set; }

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            PlayAudio();
        } else {
            Destroy(gameObject);
        }
    }

    IEnumerator Play() {
        yield return new WaitForSeconds(0.5f);
        GetComponent<AudioSource>().Play();
    }

    public void PlayAudio() {
        StartCoroutine(Play());
    }

    public void StopAudio() {
        GetComponent<AudioSource>().Stop();
    }

    public bool IsPlaying() {
        return Instance.GetComponent<AudioSource>().isPlaying;
    }
}
