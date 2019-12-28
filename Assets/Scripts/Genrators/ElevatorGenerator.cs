using UnityEngine;

[RequireComponent(typeof(ITimeAdapter))]
public class ElevatorGenerator : MonoBehaviour
{
    [SerializeField]
    private RiseMotion elevator = null;

    [SerializeField]
    private float timeOffset = 0;

    private float currentTime = 0;
    private ITimeAdapter timeAdapter;

    private void Start()
    {
        timeAdapter = GetComponent<ITimeAdapter>();
    }

    private void Update()
    {
        currentTime += timeAdapter.deltaTime;

        if (currentTime >= timeOffset)
        {
            currentTime = 0;

            Instantiate(elevator, transform.position, Quaternion.identity);
        }
    }
}
