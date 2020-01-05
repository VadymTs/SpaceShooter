using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject asteroidExplosion;
    public GameObject playerExplosion;
    public int destroyPoint;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary") return;

        Instantiate(asteroidExplosion, transform.position, transform.rotation);

        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
        }

        if(other.tag == "Shot")
        {
            SharedValues.AddScore(destroyPoint);
        }

        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
