using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Identifier : MonoBehaviour {

    [SerializeField] private string id;
    [SerializeField] private bool template;

    private bool correct;
    private float threshold = 0.5f;

    private void OnTriggerStay2D(Collider2D collision) {
        Identifier collided = collision.gameObject.GetComponent<Identifier>();
        Identifier current = gameObject.GetComponent<Identifier>();
        
        if (collided.GetId().Equals(current.GetId())) {
            Transform collidedTransform = collision.gameObject.transform;
            Transform currentTransform = gameObject.transform;
            correct = IsPositionAccept(collidedTransform, currentTransform)
                && IsRotateAccept(collidedTransform, currentTransform);
        }
    }

    private bool IsPositionAccept(Transform collidedTransform, Transform currentTransform) {
        return Mathf.Abs(collidedTransform.position.x - currentTransform.position.x) <= threshold 
            && Mathf.Abs(collidedTransform.position.y - currentTransform.position.y) <= threshold;
    }

    private bool IsRotateAccept(Transform collidedTransform, Transform currentTransform) {
        return Mathf.Abs(collidedTransform.rotation.z - currentTransform.rotation.z) <= threshold;
    }

    public string GetId() {
        return id;
    }

    public bool IsCorrect() {
        return correct;
    }

    public bool IsTemplate() {
        return template;
    }
}
