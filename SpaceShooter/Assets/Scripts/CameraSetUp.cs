using UnityEngine;

public class CameraSetUp : MonoBehaviour
{
    public GameObject boundary;

    private float halfWidth;
    private float halfHeight;

    private void Start()
    {
        Camera camera = Camera.main;

        halfHeight = camera.orthographicSize;
        halfWidth = camera.aspect * halfHeight;

        SharedValues.SetCameraSize(halfWidth, halfHeight);

        boundary.transform.localScale = new Vector3(
            SharedValues.halfWidth * 2,
            SharedValues.halfHeight *2,
            20
        );
    }
}
