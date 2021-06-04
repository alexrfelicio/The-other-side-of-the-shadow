using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cave : MonoBehaviour {

    private const int ENDING_SCENE_IDX = 3;

    private void OnTriggerEnter2D(Collider2D collision) {
        FindObjectOfType<ScenesManager>().LoadScene(ENDING_SCENE_IDX);
    }

}
