using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class TangramController : MonoBehaviour {

    [SerializeField] private GameObject[] levels;
    [SerializeField] private AudioClip clickSFX;

    private bool mTemplate = false;
    private float mInitialSpeed = 0f;
    private float mRotationSpeed = 0.2f;
    private float mTranslateSpeed = 0.01f;
    private Transform mGameObjectFocused = null;

    private void Awake() {
        int level = FindObjectOfType<GamePersist>().GetLevel();
        levels[level].SetActive(true);
    }

    // Update is called once per frame
    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit) {
                if (mGameObjectFocused != null) {
                    Color tmpFocus = mGameObjectFocused.GetComponent<SpriteShapeRenderer>().color;
                    mGameObjectFocused.GetComponent<SpriteShapeRenderer>().color =
                        new Color(tmpFocus.r, tmpFocus.g, tmpFocus.b, 0.7f);
                }
                mGameObjectFocused = hit.transform;
                Identifier identifier = hit.collider.GetComponent<Identifier>();
                Color tmp = hit.collider.GetComponent<SpriteShapeRenderer>().color;
                hit.collider.GetComponent<SpriteShapeRenderer>().color = new Color(tmp.r, tmp.g, tmp.b, 1f);
                if (identifier != null)
                    mTemplate = hit.collider.GetComponent<Identifier>().IsTemplate();
                if (!mTemplate) {
                    AudioSource.PlayClipAtPoint(clickSFX, hit.transform.position, 0.6f);
                }
            }
        }

        if (mGameObjectFocused != null && !mTemplate) {
            if (Input.GetKey(KeyCode.A)) {
                mGameObjectFocused.position =
                    new Vector2(
                        mGameObjectFocused.position.x - mTranslateSpeed,
                        mGameObjectFocused.position.y);
            } else if (Input.GetKey(KeyCode.D)) {
                mGameObjectFocused.position =
                    new Vector2(
                        mGameObjectFocused.position.x + mTranslateSpeed,
                        mGameObjectFocused.position.y);
            } else if (Input.GetKey(KeyCode.W)) {
                mGameObjectFocused.position =
                    new Vector2(
                        mGameObjectFocused.position.x,
                        mGameObjectFocused.position.y + mTranslateSpeed);
            } else if (Input.GetKey(KeyCode.S)) {
                mGameObjectFocused.position =
                    new Vector2(
                        mGameObjectFocused.position.x,
                        mGameObjectFocused.position.y - mTranslateSpeed);
            } else if (Input.GetKey(KeyCode.Q)) {
                mGameObjectFocused.Rotate(mInitialSpeed, mInitialSpeed, mRotationSpeed);
            } else if (Input.GetKey(KeyCode.E)) {
                mGameObjectFocused.Rotate(mInitialSpeed, mInitialSpeed, -mRotationSpeed);
            }
        }
    }
}
