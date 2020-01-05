using UnityEngine;

public class SharedValues : MonoBehaviour
{
    public float speedInc;
    public float speedPerionInc;
    public float maxSpeed;

    public static int score { get; private set; } = 0;
    public static float distance { get; private set; } = 0;
    public static float speed { get; private set; } = 1;

    public static float halfWidth { get; private set; }
    public static float halfHeight { get; private set; }

    private float timer = 0;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > speedPerionInc)
        {
            speed += speedInc;

            if (speed > maxSpeed)
                speed = maxSpeed;

            timer = 0;
        }
    }

    public static void AddScore(int value)
    {
        score += value;
    }

    public static void AddDistance()
    {
        distance += speed * Time.deltaTime;
    }

    public static void ResetAllValues()
    {
        score = 0;
        distance = 0;
        speed = 1;
    }

    public static void SetCameraSize(float newWidth, float newHeight)
    {
        SharedValues.halfWidth = newWidth;
        SharedValues.halfHeight = newHeight;
    }
}
