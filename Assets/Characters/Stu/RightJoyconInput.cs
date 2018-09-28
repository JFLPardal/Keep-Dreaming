using UnityEngine;

public class RightJoyconInput : MonoBehaviour
{
    const string LeftShoulder = "R L Shoulder";
    const string RightShoulder = "R R Shoulder";

    const string XButton = "R X Button";
    const string YButton = "R Y Button";
    const string BButton = "R B Button";
    const string AButton = "R A Button";

    const string rightJoyconX = "JoyconRX";
    const string rightJoyconY = "JoyconRY";

    private StuMovement stuMovement;

    void Start()
    {
        stuMovement = GetComponent<StuMovement>();    
    }

    void Update()
    {
        TestInputs();
        GetJoystickInput();
    }

    private void GetJoystickInput()
    {
        Vector2 translateAmount = new Vector2(Input.GetAxis(rightJoyconX), Input.GetAxis(rightJoyconY));
        stuMovement.Move(translateAmount);
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
