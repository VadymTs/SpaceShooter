using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject[] asteroids;
    public GameObject player;
    public UIController uiController;

    [Tooltip("Initial delay before the asteroids wave")]
    public float startWait;

    [Tooltip("Delay before each individual asteroid")]
    public float spawnWait;

    [Tooltip("Delay between waves")]
    public float waveWait;

    [Tooltip("The number of asteroids in the wave")]
    public float asteroidCount;

    private bool isStarted = false;

    void Start()
    {
        // Show Start Menu
        uiController.ShowPanel(0);
    }

    void Update()
    {
        if (isStarted)
        {
            // Increment distance value
            SharedValues.AddDistance();
        }
    }

    public void StartGame()
    {
        isStarted = true;

        // Reset distance, score & speed
        SharedValues.ResetAllValues();

        // Show HUD
        uiController.ShowPanel(1);

        // Adding player to scene
        Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);

        // Start spawn asteroids
        StartCoroutine(SpawnWaves());
    }

    public void PauseGame()
    {
        Time.timeScale = 0;

        // Show Pause Menu
        uiController.ShowPanel(2);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        uiController.ShowPanel(1);
    }

    public void OnPlayerDied()
    {
        isStarted = false;

        // Show Restart Menu & Deleting all asteroids
        uiController.ShowPanel(3);
        uiController.PrintScore();

        // Stop spawning asteroids and delete the remaining
        StopAllCoroutines();
        DestroyAsteroids();
    }

    private void DestroyAsteroids()
    {
        GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");

        foreach (GameObject tmp in asteroids)
        {
            Destroy(tmp);
        }
    }


    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        
        while (isStarted)
        {
            for (int i = 0; i < asteroidCount; i++)
            {
                Vector3 position = new Vector3(
                    Random.Range(-SharedValues.halfWidth, SharedValues.halfWidth),
                    0,
                    SharedValues.halfHeight * 2
                );

                int asteroidType = Random.Range(0, asteroids.Length);
                Instantiate(asteroids[asteroidType], position, Quaternion.identity);

                yield return new WaitForSeconds(spawnWait);
            }

            yield return new WaitForSeconds(waveWait);
        }

    }
}