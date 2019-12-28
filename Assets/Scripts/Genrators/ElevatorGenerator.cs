using UnityEngine;

public class ElevatorGenerator : MonoBehaviour
{
    [SerializeField]
    private  ElevatorMotion elevator;

    [SerializeField]
    private  float timeOffset;

    private  float currentTime = 0;

    private void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= timeOffset)
        {
            currentTime = 0;

            Instantiate(elevator, transform.position, Quaternion.identity);
        }
    }
}
