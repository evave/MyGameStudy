﻿using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {
    public float maxSpeed = 6.0f;
    public bool facingRight = true;
    public float moveDirection;

	public bool doubleJump = false;
    public float jumpSpeed = 600.0f;
    public bool grounded = false;
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask whatIsGround;

	public float swordSpeed = 600.0f;
	public Transform swordSpawn;
	public Rigidbody swordPrefab;

	Rigidbody clone;

    void Awake() {
        groundCheck = GameObject.Find("GroundCheck").transform;
		swordSpawn = GameObject.Find("SwordSpawn").transform;
    }

	void FixedUpdate () {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        rigidbody.velocity = new Vector2(moveDirection*maxSpeed, rigidbody.velocity.y);
		if(grounded){
			doubleJump = false;
		}
        if (moveDirection > 0.0f && !facingRight) {
            Flip();
        }
        else if (moveDirection < 0.0f && facingRight) {
            Flip();
        }
	}

    void Update() {
        moveDirection = Input.GetAxis("Horizontal");
        if((grounded || !doubleJump) && Input.GetButtonDown("Jump")){
            rigidbody.AddForce(new Vector2(0, jumpSpeed));
			if(!doubleJump && !grounded){
				doubleJump = true; 
			}
        }
		if(Input.GetButtonDown("Fire1")){
			Attack();
		}
    }

    void Flip() {
        facingRight = !facingRight;
        // 围绕Y轴转180°，相对于世界坐标
        transform.Rotate(Vector3.up, 180.0f, Space.World);
    }

	void Attack(){
		clone = Instantiate(swordPrefab, swordSpawn.position, swordSpawn.rotation) as Rigidbody;
		clone.AddForce(swordSpawn.transform.right * swordSpeed);
	}
	
}
