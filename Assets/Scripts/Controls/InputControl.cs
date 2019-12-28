using UnityEngine;

public class InputControl : MonoBehaviour, IHorizontalControl, IJumpControl
{
    public bool MoveLeft { get; private set; }
    public bool MoveRight { get; private set; }
    public bool Jump { get; private set; }

    private void Update()
    {
        Reset();
        CheckLeft();
        CheckRight();
        CheckJump();
    }

    private void Reset()
    {
        MoveLeft = false;
        MoveRight = false;
        Jump = false;
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

    private void CheckJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump = true;
        }
        else
        {
            Jump = false;
        }
    }
}
