using UnityEngine;

public class Parallax : MonoBehaviour
{

    public float speedMultiplyer = .1f;
    public float startPosition;

    private float length;

    void Start()
    {
        length = transform.localScale.y;
    }

    void Update()
    {
        float offset = transform.localPosition.y + Time.deltaTime 
            * speedMultiplyer * SharedValues.speed;

        transform.localPosition = new Vector3(
            0, offset, transform.localPosition.z
        );

        if (transform.localPosition.y < (startPosition - length))
        {
            transform.localPosition = new Vector3(
                0, startPosition + (length * 2), transform.localPosition.z
            );
        }
    }
}
