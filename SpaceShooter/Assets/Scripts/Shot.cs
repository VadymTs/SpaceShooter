using UnityEngine;

public class Shot : MonoBehaviour
{
    public float speed;
    
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        rb.velocity = transform.forward * speed;
    }
}
