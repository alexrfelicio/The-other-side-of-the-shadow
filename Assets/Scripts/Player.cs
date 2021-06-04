using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] private Rigidbody2D mRigidBody2D;
    [SerializeField] private Animator mAnimator;

    private float mSpeed = 1f;
    private Vector2 mMovement;
    private bool mMoving;

    // Update is called once per frame
    private void Update() {
        mMovement.x = Input.GetAxisRaw("Horizontal");
        mMovement.y = Input.GetAxisRaw("Vertical");

        mAnimator.SetFloat("Horizontal", mMovement.x);
        mAnimator.SetFloat("Vertical", mMovement.y);
        mAnimator.SetFloat("Speed", mMovement.sqrMagnitude);
    }

    private void FixedUpdate() {
        mRigidBody2D.MovePosition(mRigidBody2D.position + mMovement * mSpeed * Time.fixedDeltaTime);
    }
}
