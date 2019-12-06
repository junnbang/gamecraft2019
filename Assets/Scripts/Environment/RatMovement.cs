﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatMovement : MonoBehaviour
{
    public float movementSpeed = 5;
    public float jumpHeight = 350;
    public float maxRatSize = 5;
    public float ratGrowSpeed = 2;

    private Rigidbody2D rb;
    private Vector3 ratSize = new Vector3(0, 0, 0);
    private bool canJump = false;
    private float currentX = -1.0f;
    private float switchDirectionTimer;
    private bool canMove = false; //Movement is only enabled if rat has grown

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        RandomDirectionTimer();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        //Jump();
        GrowRat();

        UpdateTimers();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Floor")) {
            canJump = true;
        }

        if (col.gameObject.CompareTag("Wall") || col.gameObject.CompareTag("Trophy")) {
            currentX *= -1.0f;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Floor")) {
            canJump = false;
        }
    }

    private void Movement() {
        if (!canMove) {
            return;
        }

        rb.velocity = new Vector2(currentX * movementSpeed, rb.velocity.y);
        if (switchDirectionTimer <= 0.0f)
        {
            currentX *= -1.0f;
            RandomDirectionTimer();
        }

        if(currentX > 0) {
            rb.gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if(currentX < 0) {
            rb.gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    private void Jump() {
        canJump = false;
        rb.AddForce(Vector2.up * jumpHeight);
    }

    private void GrowRat() {
        if (canMove) {
            return;
        }

        Vector3 currSize = rb.transform.localScale;

        if (currSize.x < maxRatSize)
        {
            float size = currSize.x + Time.deltaTime;
            rb.transform.localScale = new Vector3(size, size, size);
        }
        else {
            canMove = true;
        }
    }

    private void UpdateTimers() {
        switchDirectionTimer -= Time.deltaTime;
    }

    private void RandomDirectionTimer() {
        switchDirectionTimer = Random.Range(4.0f, 10.0f);
    }
}