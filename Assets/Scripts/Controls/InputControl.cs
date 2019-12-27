using UnityEngine;

public class InputControl : MonoBehaviour, IWalkControl
{
    public bool WalkLeft { get; private set; }
    public bool WalkRight { get; private set; }

    // Update is called once per frame
    private void Update()
    {
        Reset();
        CheckLeft();
        CheckRight();
    }

    private void Reset()
    {
        WalkLeft = false;
        WalkRight = false;
    }

    private void CheckLeft()
    {
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            WalkLeft = true;
        }
    }

    private void CheckRight()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            WalkRight = true;
        }
    }
}
