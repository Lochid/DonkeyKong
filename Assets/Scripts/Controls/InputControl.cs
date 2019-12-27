using UnityEngine;

public class InputControl : MonoBehaviour, IHorizontalControl
{
    public bool MoveLeft { get; private set; }
    public bool MoveRight { get; private set; }

    private void Update()
    {
        Reset();
        CheckLeft();
        CheckRight();
    }

    private void Reset()
    {
        MoveLeft = false;
        MoveRight = false;
    }

    private void CheckLeft()
    {
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            MoveLeft = true;
        }
    }

    private void CheckRight()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            MoveRight = true;
        }
    }
}
