using UnityEngine;

[RequireComponent(typeof(ITransformAdapter))]
public class ObjectGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject obj = null;

    [SerializeField]
    private float timeOffset = 1;

    private ITransformAdapter transformAdapter;

    private void Start()
    {
        transformAdapter = GetComponent<ITransformAdapter>();
        InvokeRepeating("GenerateObject", 0.1f, timeOffset);
    }
    
    private void GenerateObject()
    {
        Instantiate(obj, transformAdapter.position, Quaternion.identity);
    }
}
