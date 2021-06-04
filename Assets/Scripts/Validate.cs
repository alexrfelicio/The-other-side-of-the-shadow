using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Validate : MonoBehaviour {

    [SerializeField] private GameObject[] templates;
    [SerializeField] private GameObject[] pieces;
    [SerializeField] private Button checkButton;
    [SerializeField] private Image errorImg;
    [SerializeField] private GameObject answerModal;
    [SerializeField] private AudioClip winSFX;
    [SerializeField] private AudioClip errorSFX;

    private Identifier[] identifiers;
    private Transform[] gameObjects;
    private bool win = false;
    private float volume = 0.2f;

    public void Verify() {
        StartCoroutine(ValidateTangram());
    }

    IEnumerator ValidateTangram() {
        int level = FindObjectOfType<GamePersist>().GetLevel();
        identifiers = templates[level].GetComponentsInChildren<Identifier>();
        gameObjects = pieces[level].GetComponentsInChildren<Transform>();

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
            checkButton.gameObject.SetActive(false);
            answerModal.SetActive(true);
            answerModal.gameObject.transform.GetChild(level).gameObject.SetActive(true);
            AudioSource.PlayClipAtPoint(winSFX, transform.position, volume);
        }
        else {
            foreach (Transform gameObject in gameObjects) {
                Destroy(gameObject.gameObject.GetComponent<Rigidbody2D>());
            }
            errorImg.gameObject.SetActive(true);
            AudioSource.PlayClipAtPoint(errorSFX, transform.position, volume);
            yield return new WaitForSeconds(2);
            errorImg.gameObject.SetActive(false);
        }
    }
}
