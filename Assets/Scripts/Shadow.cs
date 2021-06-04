using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour {

    private const int TANGRAM_SCENE_IDX = 2;

    [SerializeField] private int level;

    private bool canCollide = true;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (!canCollide) return;
        FindObjectOfType<GamePersist>().SetPlayerPosition(collision.transform.position);
        FindObjectOfType<GamePersist>().SetLevel(level);
        FindObjectOfType<ScenesManager>().LoadScene(TANGRAM_SCENE_IDX);
        canCollide = false;
    }
}
