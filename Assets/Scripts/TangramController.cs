using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;
using System;

public class TangramController : MonoBehaviour {

    [SerializeField] private GameObject[] levels;
    [SerializeField] private AudioClip clickSFX;
    [SerializeField] private Slider moveSlider;
    [SerializeField] private Slider rotateSlider;

    private bool template = false;
    private float initialSpeed = 0f;
    private float rotationSpeed;
    private float translateSpeed;
    private Transform gameObjectFocused = null;

    private void Awake() {
        int level = FindObjectOfType<GamePersist>().GetLevel();
        levels[level].SetActive(true);
    }

    private void Update() {
        rotationSpeed = GetRotationSpeed();
        translateSpeed = GetTranslateSpeed();
        if (Input.GetMouseButtonDown(0)) {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit) {
                if (gameObjectFocused != null) {
                    Color tmpFocus = gameObjectFocused.GetComponent<SpriteShapeRenderer>().color;
                    gameObjectFocused.GetComponent<SpriteShapeRenderer>().color =
                        new Color(tmpFocus.r, tmpFocus.g, tmpFocus.b, 0.7f);
                }
                gameObjectFocused = hit.transform;
                Identifier identifier = hit.collider.GetComponent<Identifier>();
                Color tmp = hit.collider.GetComponent<SpriteShapeRenderer>().color;
                hit.collider.GetComponent<SpriteShapeRenderer>().color = new Color(tmp.r, tmp.g, tmp.b, 1f);
                if (identifier != null)
                    template = hit.collider.GetComponent<Identifier>().IsTemplate();
                if (!template) {
                    AudioSource.PlayClipAtPoint(clickSFX, hit.transform.position, 0.6f);
                }
            }
        }

        if (gameObjectFocused != null && !template) {
            if (Input.GetKey(KeyCode.A)) {
                gameObjectFocused.position =
                    new Vector2(
                        gameObjectFocused.position.x - translateSpeed,
                        gameObjectFocused.position.y);
            } else if (Input.GetKey(KeyCode.D)) {
                gameObjectFocused.position =
                    new Vector2(
                        gameObjectFocused.position.x + translateSpeed,
                        gameObjectFocused.position.y);
            } else if (Input.GetKey(KeyCode.W)) {
                gameObjectFocused.position =
                    new Vector2(
                        gameObjectFocused.position.x,
                        gameObjectFocused.position.y + translateSpeed);
            } else if (Input.GetKey(KeyCode.S)) {
                gameObjectFocused.position =
                    new Vector2(
                        gameObjectFocused.position.x,
                        gameObjectFocused.position.y - translateSpeed);
            } else if (Input.GetKey(KeyCode.Q)) {
                gameObjectFocused.Rotate(initialSpeed, initialSpeed, rotationSpeed);
            } else if (Input.GetKey(KeyCode.E)) {
                gameObjectFocused.Rotate(initialSpeed, initialSpeed, -rotationSpeed);
            }
        }
    }

    private float GetTranslateSpeed() {
        return (0.06f * moveSlider.value) + 0.01f;
    }

    private float GetRotationSpeed() {
        return (0.6f * rotateSlider.value) + 0.1f;
    }
}
