using System;
using UnityEngine;

[RequireComponent(typeof(PJMovement))]
[RequireComponent(typeof(SlingshotManager))]
public class LeftJoyconInput : MonoBehaviour
{
    //joycon map
    const string LeftShoulder = "L L Shoulder";
    const string RightShoulder = "L R Shoulder";

    const string downArrow = "L down arrow"; 
    const string leftArrow = "L left arrow";
    const string rightArrow = "L right arrow";
    const string upArrow = "L up arrow";

    const string leftJoyconX = "JoyconLX";
    const string leftJoyconY = "JoyconLY";

    //button actions
    const string holdSlingshot = RightShoulder;
    const string fireSlingshot = rightArrow;

    private PJMovement pjboyMovement;
    private SlingshotManager slingshot;

    void Start()
    {
        pjboyMovement = GetComponent<PJMovement>();
        slingshot = GetComponent<SlingshotManager>();
    }

    void Update ()
    {
        TestInput();
        GetJoystickInput();
        CheckIfSlingshotIsBeingHeld();
        CheckIfFiringSlingshot();
	}

    private void GetJoystickInput()
    {
        Vector2 directionToMove = new Vector2(Input.GetAxis(leftJoyconX), Input.GetAxis(leftJoyconY));
        pjboyMovement.AttemptMove(directionToMove);
    }

    private void CheckIfSlingshotIsBeingHeld()
    {
        if (Input.GetButton(holdSlingshot))
        {
            slingshot.Held();
        }
        else if (Input.GetButtonUp(holdSlingshot))
        {
            slingshot.Released();
        }
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
