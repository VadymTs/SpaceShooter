using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public GameObject shot;
    public Transform spawnPoint;
    public float speed;
    public float roll;
    public float reloadTime;

    private GameController gameController;
    private UIController uiController;
    private Rigidbody rb;
    private float nextFire;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        gameController = FindObjectOfType<GameController>();
        uiController   = FindObjectOfType<UIController>();

        // Set cooldown time
        uiController.SetCooldown(reloadTime);
    }

    void Update()
    {
        if (Input.touchCount > 0 && Time.time > nextFire)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                // Prevent fire when touched over UI
                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)){

                    // Calculate next fire time
                    nextFire = Time.time + reloadTime;

                    // 
                    uiController.ResetCooldown();

                    // Create new shot
                    Instantiate(shot, spawnPoint.position, Quaternion.identity);
                }
            }
        }
    }

    void FixedUpdate()
    {
        float movement = Input.acceleration.x;

        rb.velocity = new Vector3(movement * speed, 0, 0);
        rb.position = new Vector3(
            Mathf.Clamp(
                rb.position.x,
                -SharedValues.halfWidth,
                SharedValues.halfWidth
                ), 0, 0);

        rb.rotation = Quaternion.Euler(0, 0, rb.velocity.x * -roll);
    }

    void OnDestroy()
    {
        gameController.OnPlayerDied();
    }
}
