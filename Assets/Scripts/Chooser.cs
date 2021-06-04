using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chooser : MonoBehaviour {

    private const int GAME_SCENE_IDX = 1;

    [SerializeField] private Image[] silhouttes;

    public void Choose(int index) {
        GamePersist gamePersist = FindObjectOfType<GamePersist>();
        if (index % 2 == 0) {
            gamePersist.IncreaseGood();
        } else {
            gamePersist.IncreaseBad();
        }
        gamePersist.AddSilhouette(silhouttes[index].sprite);
        FindObjectOfType<ScenesManager>().LoadScene(GAME_SCENE_IDX);
    }
}
