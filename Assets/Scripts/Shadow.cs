using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour {

    private const int TANGRAM_SCENE_IDX = 2;

    [SerializeField] private int level;

    private void OnTriggerEnter2D(Collider2D collision) {
        FindObjectOfType<GamePersist>().SetLevel(level);
        FindObjectOfType<ScenesManager>().LoadScene(TANGRAM_SCENE_IDX);
    }
}
