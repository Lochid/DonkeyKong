using UnityEngine;

public interface IInputAdapter
{
    float GetAxisRaw(AxisRawType type);
    bool GetKeyDown(KeyCode code);
    bool GetKeyUp(KeyCode code);
}
