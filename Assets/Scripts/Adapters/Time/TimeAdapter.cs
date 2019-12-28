using UnityEngine;

public class TimeAdapter : MonoBehaviour, ITimeAdapter
{
    public float deltaTime => Time.deltaTime;
}
