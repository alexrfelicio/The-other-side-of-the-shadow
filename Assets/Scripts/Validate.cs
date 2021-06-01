using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Validate : MonoBehaviour {

    [SerializeField] private GameObject[] templates;
    [SerializeField] private GameObject[] pieces;
    [SerializeField] private Rigidbody2D defaultBody;

    private Identifier[] identifiers;
    private Transform[] gameObjects;
    private bool win = false;

    public void Verify() {
        StartCoroutine(ValidateTangram());
    }

    IEnumerator ValidateTangram() {
        identifiers = templates[0].GetComponentsInChildren<Identifier>();
        gameObjects = pieces[0].GetComponentsInChildren<Transform>();

        foreach (Transform gameObject in gameObjects) {
            Rigidbody2D body = gameObject.gameObject.AddComponent<Rigidbody2D>();
            body.bodyType = RigidbodyType2D.Kinematic;
        }
        yield return new WaitForSeconds(2);
        foreach (Identifier identifier in identifiers) {
            if (!identifier.IsCorrect()) break;
            win = true;
        }

        if (win) {
            // TODO: SHOW BALLOONS
        }
        else {
            foreach (Transform gameObject in gameObjects) {
                Destroy(gameObject.gameObject.GetComponent<Rigidbody2D>());
            }
            // TODO: SHOW ERROR MESSAGE AND SOUND
        }
    }
}
