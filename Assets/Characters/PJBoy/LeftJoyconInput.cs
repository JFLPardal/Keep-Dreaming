﻿using System;
using UnityEngine;

[RequireComponent(typeof(PJMovement))]
[RequireComponent(typeof(SlingshotManager))]
public class LeftJoyconInput : MonoBehaviour
{
    // joycon map
    const string LeftShoulder = "L L Shoulder";
    const string RightShoulder = "L R Shoulder";

    const string downArrow = "L down arrow"; 
    const string leftArrow = "L left arrow";
    const string rightArrow = "L right arrow";
    const string upArrow = "L up arrow";

    const string leftJoyconX = "JoyconLX";
    const string leftJoyconY = "JoyconLY";
    
    // button actions
    const string holdSlingshot = rightArrow;
    const string fireSlingshot = RightShoulder;
    
    // animator
    const string X_INPUT = "DirX";
    const string Y_INPUT = "DirY";
    const string BOOL_IS_WALKING = "isWalking";

    private PJMovement pjboyMovement;
    private SlingshotManager slingshot;

    void Start()
    {
        pjboyMovement = GetComponent<PJMovement>();
        slingshot = GetComponent<SlingshotManager>();
    }

    void Update ()
    {
        //TestInput();
        GetJoystickInput();
        CheckIfSlingshotIsBeingHeld();
        CheckIfFiringSlingshot();
	}

    private void GetJoystickInput()
    {
        float xInput = Input.GetAxis(leftJoyconX);
        float yInput = Input.GetAxis(leftJoyconY);

        Vector2 directionToMove = new Vector2(xInput, yInput);
        pjboyMovement.AttemptMove(directionToMove);

        Animator animator = GetComponent<Animator>();

        animator.SetFloat(X_INPUT, xInput);
        animator.SetFloat(Y_INPUT, yInput);

        animator.SetBool(BOOL_IS_WALKING, directionToMove.magnitude > 0);
    }

    private void CheckIfSlingshotIsBeingHeld()
    {
        if (Input.GetButton(holdSlingshot))
        {
            pjboyMovement.StopMoving();
            Vector2 slingshotDirection = GetSlingshotDirection();
            slingshot.Held(slingshotDirection);
        }
        else if (Input.GetButtonUp(holdSlingshot))
        {
            slingshot.Released();
        }
    }

    private Vector2 GetSlingshotDirection()
    {
        Vector2 directionToMove = new Vector2(Input.GetAxisRaw(leftJoyconX), Input.GetAxisRaw(leftJoyconY)).normalized;
        return directionToMove;
    }

    private void CheckIfFiringSlingshot()
    {
        if(Input.GetButtonDown(fireSlingshot))
        {
            slingshot.AttemptFireSlingshot();
        }
    }

    private void TestInput()
    {
        if (Input.GetButtonDown(LeftShoulder))
            print(LeftShoulder + " pressed");
        if (Input.GetButtonDown(RightShoulder))
            print(RightShoulder + " pressed");
        if (Input.GetButtonDown(downArrow))
            print(downArrow + " pressed");
        if (Input.GetButtonDown(rightArrow))
            print(rightArrow + " pressed");
        if (Input.GetButtonDown(leftArrow))
            print(leftArrow + " pressed");
        if (Input.GetButtonDown(upArrow))
            print(upArrow + " pressed");
    }
}
