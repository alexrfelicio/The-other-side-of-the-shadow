using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TangramController : MonoBehaviour {

    private bool template = false;
    private float initialSpeed = 0f;
    private float rotationSpeed = 0.5f;
    private float translateSpeed = 0.01f;
    private Transform gameObjectFocused = null;

    // Update is called once per frame
    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit) {
                gameObjectFocused = hit.transform;
                Identifier identifier = hit.collider.GetComponent<Identifier>();
                if (identifier != null)
                    template = hit.collider.GetComponent<Identifier>().IsTemplate();
            }
        }

        if (gameObjectFocused != null && !template) {
            if (Input.GetKey(KeyCode.A)) {
                gameObjectFocused.position =
                    new Vector2(gameObjectFocused.position.x - translateSpeed, gameObjectFocused.position.y);
            } else if (Input.GetKey(KeyCode.D)) {
                gameObjectFocused.position =
                    new Vector2(gameObjectFocused.position.x + translateSpeed, gameObjectFocused.position.y);
            } else if (Input.GetKey(KeyCode.W)) {
                gameObjectFocused.position =
                    new Vector2(gameObjectFocused.position.x, gameObjectFocused.position.y + translateSpeed);
            } else if (Input.GetKey(KeyCode.S)) {
                gameObjectFocused.position =
                    new Vector2(gameObjectFocused.position.x, gameObjectFocused.position.y - translateSpeed);
            } else if (Input.GetKey(KeyCode.Q)) {
                gameObjectFocused.Rotate(initialSpeed, initialSpeed, rotationSpeed);
            } else if (Input.GetKey(KeyCode.E)) {
                gameObjectFocused.Rotate(initialSpeed, initialSpeed, -rotationSpeed);
            }
        }
    }
}
