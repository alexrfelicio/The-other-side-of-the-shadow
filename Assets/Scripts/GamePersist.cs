using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePersist : MonoBehaviour {

    public static GamePersist Instance { get; private set; }
    private int currentLevel;
    private int good;
    private int bad;
    private ColorBlindMode colorBlindMode;
    private Dictionary<int, Sprite> silhouettes = new Dictionary<int, Sprite>();
    private Vector3 playerPosition;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Instance.colorBlindMode = ColorBlindMode.Normal;
            Instance.good = 0;
            Instance.bad = 0;
        } else {
            Destroy(gameObject);
        }
    }

    public void SetLevel(int level) {
        Instance.currentLevel = level;
    }

    public int GetLevel() {
        return Instance.currentLevel;
    }

    public void AddSilhouette(Sprite silhouette) {
        Instance.silhouettes.Add(currentLevel, silhouette);
    }

    public Dictionary<int, Sprite> GetSilhouette() {
        if (Instance != null) {
            return Instance.silhouettes;
        }
        return silhouettes;
    }

    public void IncreaseGood() {
        Instance.good += 1;
    }

    public void IncreaseBad() {
        Instance.bad += 1;
    }

    public int GetGood() {
        return Instance.good;
    }

    public int GetBad() {
        return Instance.bad;
    }

    public void SetPlayerPosition(Vector3 pos) {
        Instance.playerPosition = pos;
    }

    public Vector3 GetPlayerPosition() {
        return Instance.playerPosition;
    }

    public void SetColorBlindMode(ColorBlindMode mode) {
        Instance.colorBlindMode = mode;
    }

    public ColorBlindMode GetColorBlindMode() {
        return Instance.colorBlindMode;
    }

    public void ResetGamePersist() {
        Instance.good = 0;
        Instance.bad = 0;
        Instance.silhouettes = new Dictionary<int, Sprite>();
    }

}
