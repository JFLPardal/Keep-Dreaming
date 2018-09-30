using System;
using UnityEngine;

public class RightJoyconInput : MonoBehaviour
{
    // joycon map
    const string LeftShoulder = "R L Shoulder";
    const string RightShoulder = "R R Shoulder";

    const string XButton = "R X Button";
    const string YButton = "R Y Button";
    const string BButton = "R B Button";
    const string AButton = "R A Button";

    const string rightJoyconX = "JoyconRX";
    const string rightJoyconY = "JoyconRY";
    
    // button actions
    const string pushEnemy = XButton;
    
    // animator
    const string X_INPUT = "DirX";
    const string Y_INPUT = "DirY";

    private StuMovement stuMovement;
    private StuPush stuPush;

    void Start()
    {
        GetStuComponents();
    }

    void Update()
    {
        //TestInputs();
        GetJoystickInput();
        CheckIfTryingToPush();
    }

    private void GetJoystickInput()
    {
        float xInput = Input.GetAxis(rightJoyconX);
        float yInput = Input.GetAxis(rightJoyconY);
        
        Vector2 translateAmount = new Vector2(xInput, yInput);
        stuMovement.Move(translateAmount);

        Animator animator = GetComponent<Animator>();
        animator.SetFloat(X_INPUT, xInput);
        animator.SetFloat(Y_INPUT, yInput);
    }
    
    private void CheckIfTryingToPush()
    {
        if (Input.GetButtonDown(pushEnemy))
        {
            stuPush.AttemptingToPush();
        }
    }

    private void GetStuComponents()
    {
        stuMovement = GetComponent<StuMovement>();
        stuPush = GetComponent<StuPush>();
    }

    private void TestInputs()
    {
        if (Input.GetButtonDown(LeftShoulder))
            print(LeftShoulder + " pressed");
        if (Input.GetButtonDown(RightShoulder))
            print(RightShoulder + " pressed");
        if (Input.GetButtonDown(BButton))
            print(BButton + " pressed");
        if (Input.GetButtonDown(AButton))
            print(AButton + " pressed");
        if (Input.GetButtonDown(XButton))
            print(XButton + " pressed");
        if (Input.GetButtonDown(YButton))
            print(YButton + " pressed");
    }
    
}
