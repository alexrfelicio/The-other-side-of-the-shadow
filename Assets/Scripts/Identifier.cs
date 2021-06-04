using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Identifier : MonoBehaviour {

    [SerializeField] private string mId;
    [SerializeField] private bool mTemplate;

    private bool mCorrect;
    private float mThreshold = 3f;

    private void OnTriggerStay2D(Collider2D collision) {
        Identifier collided = collision.gameObject.GetComponent<Identifier>();
        Identifier current = gameObject.GetComponent<Identifier>();
        
        if (!collided.IsTemplate() && collided.GetId().Equals(current.GetId())) {
            Transform collidedTransform = collision.gameObject.transform;
            Transform currentTransform = gameObject.transform;

            mCorrect = IsPositionAccept(collidedTransform, currentTransform)
                && IsRotateAccept(collidedTransform, currentTransform);

                Debug.Log("Collided: " + collided.name);
                Debug.Log("Current: " + current.name);
                Debug.Log("IsPositionAccept: " + IsPositionAccept(collidedTransform, currentTransform));
                Debug.Log("IsRotateAccept: " + IsPositionAccept(collidedTransform, currentTransform));

        }
    }

    private bool IsPositionAccept(Transform collidedTransform, Transform currentTransform) {
        return Mathf.Abs(collidedTransform.position.x - currentTransform.position.x) <= mThreshold
            && Mathf.Abs(collidedTransform.position.y - currentTransform.position.y) <= mThreshold;
    }

    private bool IsRotateAccept(Transform collidedTransform, Transform currentTransform) {
        return Mathf.Abs(collidedTransform.rotation.z - currentTransform.rotation.z) <= mThreshold;
    }

    public string GetId() {
        return mId;
    }

    public bool IsCorrect() {
        return mCorrect;
    }

    public bool IsTemplate() {
        return mTemplate;
    }
}
