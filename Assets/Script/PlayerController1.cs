using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private Vector3 moveInput;
    public float speed = 8f;
    Animator animator;
    public FloatingJoystick joy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Die()
    {
        gameObject.SetActive(false);
        GameManager gm = FindFirstObjectByType<GameManager>();
        gm.EndGame();

    }
    void Start()
    {
        //으헤
        playerRigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        playerRigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
    }
    
    // Update is called once per frame
    void Update()
    {
        moveInput = joy.isActiveAndEnabled
            ? Vector3.ClampMagnitude(new Vector3(joy.Horizontal, 0f, joy.Vertical), 1f)
            : Vector3.zero;
        animator.SetBool("Walk", moveInput.sqrMagnitude > 0f);
    }

    void FixedUpdate()
    {
        Vector3 velocity = playerRigidbody.linearVelocity;
        velocity.x = moveInput.x * speed;
        velocity.z = moveInput.z * speed;
        playerRigidbody.linearVelocity = velocity;

        if (moveInput.sqrMagnitude > 0f)
            playerRigidbody.MoveRotation(Quaternion.LookRotation(moveInput));
    }
}
