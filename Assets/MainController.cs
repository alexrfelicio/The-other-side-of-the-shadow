using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour {

    private void Awake() {
        MusicPersist musicPersist = FindObjectOfType<MusicPersist>();
        if (musicPersist != null && musicPersist.IsPlaying()) {
            musicPersist.StopAudio();
        }
    }

}
