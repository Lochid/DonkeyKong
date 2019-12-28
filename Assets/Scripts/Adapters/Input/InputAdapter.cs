using UnityEngine;

public enum AxisRawType
{
    Horizontal
}

public class InputAdapter : MonoBehaviour, IInputAdapter
{
    public float GetAxisRaw(AxisRawType type)
    {
        switch (type)
        {
            case AxisRawType.Horizontal:
                return Input.GetAxisRaw("Horizontal");
            default:
                return 0;
        }
    }

    public bool GetKeyDown(KeyCode code)
    {
        return Input.GetKeyDown(code);
    }

    public bool GetKeyUp(KeyCode code)
    {
        return Input.GetKeyDown(code);
    }
}
