﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //ref: Code like Me https://www.youtube.com/channel/UCU9YE0hMnTt6TozuyVKicHA

    private float forwardInput;
    private float rightInput;

    public CameraController cameraController;
    public PlayerMovement playerMovement;

    private Vector3 velocity;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (getVelocity() > 1)
            {
                playerMovement.SetMovementMode(MovementMode.Running);
            }
            else
            {
                playerMovement.SetMovementMode(MovementMode.Walking);
            }
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            playerMovement.SetMovementMode(MovementMode.NarutoRun);
        }
        else
        {
            playerMovement.SetMovementMode(MovementMode.Walking);
        }
    }

    public void AddMovementInput(float forward, float right)    // update movement inputs
    {
        forwardInput = forward;
        rightInput = right;

        Vector3 camFwd = cameraController.transform.forward;
        Vector3 camRight = cameraController.transform.right;

        Vector3 translation = forward * cameraController.transform.forward;
        translation += right * cameraController.transform.right;
        translation.y = 0;

        if (translation.magnitude > 0)
        {
            velocity = translation;
        }
        else
        {
            velocity = Vector3.zero;
        }
        playerMovement.Velocity = translation;

    }

    public float getVelocity()
    {
        return playerMovement.Velocity.magnitude;
    }

    public void ToggleRun()
    {
        if (playerMovement.GetMovementMode() != MovementMode.Running)
        {
            playerMovement.SetMovementMode(MovementMode.Running);
        }
        else
        {
            playerMovement.SetMovementMode(MovementMode.Walking);
        }
    }

}
