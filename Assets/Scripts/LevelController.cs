using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    [SerializeField] private Transform playerPosition;
    [SerializeField] private SpriteRenderer[] shadowImage;
    [SerializeField] private ParticleSystem[] shadowParticle;
    [SerializeField] private GameObject firecamp;
    [SerializeField] private AudioClip caveSFX;

    private void Start() {
        MusicPersist musicPersist = FindObjectOfType<MusicPersist>();
        if (!musicPersist.IsPlaying()) {
            musicPersist.ChangeAudioClip(caveSFX);
        }

        GamePersist gamePersist = FindObjectOfType<GamePersist>();
        if (gamePersist.GetSilhouette().Count != 0) {
            var newPlayerPos =
                new Vector3(gamePersist.GetPlayerPosition().x, gamePersist.GetPlayerPosition().y + 1, gamePersist.GetPlayerPosition().z);
            playerPosition.transform.position = newPlayerPos;
            RemoveShadowParticle(gamePersist.GetSilhouette());
        }

        if (gamePersist.GetSilhouette().Count == 3) {
            StartCoroutine(RemoveFire());
        }
    }

    private void RemoveShadowParticle(Dictionary<int, Sprite> silhouettes) {
        foreach (var silhouette in silhouettes) {
            shadowImage[silhouette.Key].sprite = silhouette.Value;
            var colorTmp = shadowImage[silhouette.Key].color;
            shadowImage[silhouette.Key].color =
                    new Color(colorTmp.r, colorTmp.g, colorTmp.b, 0f);
            StartCoroutine(StopShadowParticle(silhouette.Key));
            StartCoroutine(ShowShadowSprite(colorTmp, silhouette.Key));
        }
    }

    IEnumerator StopShadowParticle(int key) {
        var emission = shadowParticle[key].emission;
        for (int i = 10; i >= 0; i--) {
            emission.rateOverTime = i;
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator ShowShadowSprite(Color color, int key) {
        for (int i = 0; i < 10; i++) {
            float showing = (float) i * 0.1f;
            shadowImage[key].color =
                new Color(color.r, color.g, color.b, showing);
            yield return new WaitForSeconds(0.3f);
        }
    }

    IEnumerator RemoveFire() {
        firecamp.GetComponent<Animation>().Stop();
        firecamp.GetComponent<BoxCollider2D>().gameObject.SetActive(false);
        yield return null;
    }

}
