using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float runSpeed = 40f; 
    private PlayerController playerController;
    private float horizontal;
    private bool jump;

    // Start is called before the first frame update
    void Start() {
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update() {
        horizontal = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetButton("Jump")) jump = true;
    }

    private void FixedUpdate() {
        playerController.Move(horizontal * Time.fixedDeltaTime, jump);
        jump = false;
    }
}
