using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePersist : MonoBehaviour {

    public static GamePersist Instance { get; private set; }
    private int currentLevel;
    private Dictionary<int, Image> silhouettes;
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
        currentLevel = level;
    }

    public int GetLevel() {
        return currentLevel;
    }

    public void AddSilhouette(Image silhouette) {
        silhouettes.Add(currentLevel, silhouette);
    }

    public Dictionary<int, Image> GetSilhouette() {
        return silhouettes;
    }

    public void IncreaseGood() {
        good += 1;
    }

    public void IncreaseBad() {
        bad += 1;
    }

    public void PauseGame() {
        Time.timeScale = 0f;
    }

    public void ResumeGame() {
        Time.timeScale = 1f;
    }
}
