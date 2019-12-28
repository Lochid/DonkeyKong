using UnityEngine;

[RequireComponent(typeof(IInputAdapter))]
public class InputControl : MonoBehaviour, IHorizontalControl, IJumpControl
{
    public bool MoveLeft { get; private set; }
    public bool MoveRight { get; private set; }
    public bool Jump { get; private set; }

    private IInputAdapter input;

    private void Start()
    {
        input = GetComponent<IInputAdapter>();
    }

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
        if (input.GetAxisRaw(AxisRawType.Horizontal) < 0)
        {
            MoveLeft = true;
        }
    }

    private void CheckRight()
    {
        if (input.GetAxisRaw(AxisRawType.Horizontal) > 0)
        {
            MoveRight = true;
        }
    }

    private void CheckJump()
    {
        if (input.GetKeyDown(KeyCode.Space))
        {
            Jump = true;
        }
        else if(input.GetKeyUp(KeyCode.Space))
        {
            Jump = false;
        }
    }
}
