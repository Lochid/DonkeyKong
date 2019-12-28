using UnityEngine;

[RequireComponent(typeof(ITimeAdapter))]
public class ElevatorGenerator : MonoBehaviour
{
    [SerializeField]
    private  ElevatorMotion elevator;

    [SerializeField]
    private  float timeOffset;

    private  float currentTime = 0;
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
