using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePersist : MonoBehaviour {

    public static GamePersist Instance { get; private set; }
    private int currentLevel;
    private Dictionary<int, Sprite> silhouettes = new Dictionary<int, Sprite>();
    private Vector3 playerPosition;
    private int good;
    private int bad;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            ResumeGame();
        } else {
            Destroy(gameObject);
            Instance.ResumeGame();
        }
    }

    public void SetLevel(int level) {
        Instance.currentLevel = level;
    }

    public int GetLevel() {
        return Instance.currentLevel;
    }

    public void AddSilhouette(Sprite silhouette) {
        Debug.Log(silhouette);
        Instance.silhouettes.Add(currentLevel, silhouette);
        Debug.Log(silhouettes.Count);
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

    public void PauseGame() {
        Time.timeScale = 0f;
    }

    public void ResumeGame() {
        Time.timeScale = 1f;
    }
}
