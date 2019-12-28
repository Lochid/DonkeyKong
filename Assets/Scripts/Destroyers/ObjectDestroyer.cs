
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ObjectDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var obj = collision.GetComponent<Destroyable>();
        if (obj)
        {
            Destroy(obj.gameObject);
        }
    }
}