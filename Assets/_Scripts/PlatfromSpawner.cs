using UnityEngine;

public class PlatfromSpawner : MonoBehaviour
{   
    [Header("Platform Prefabs")]
    public GameObject[] platformPrefabs; // Array to store platform prefabs
    public Transform currentPlatform;    // Reference to the current platform

    [Header("Spawn Settings")]
    public float platformSpacing = 5f;  // Distance between platforms along the X-axis
    private Vector3 nextSpawnPosition;   // Position to spawn the next platform

    private void Start()
    {
        // Initialize the next spawn position
        if (currentPlatform != null)
        {
            nextSpawnPosition = currentPlatform.position + new Vector3(-platformSpacing, 0, 0);
        }
        else
        {
            Debug.LogError("Current Platform is not assigned in the Inspector.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the trigger zone has been hit
        if (other.gameObject.CompareTag("Player"))
        {
            SpawnPlatformMethod();
            DestroyPrevPlatform();
            UpdatePlatformPosition();
        }
    }

    private void SpawnPlatformMethod()
    {
        if (platformPrefabs.Length > 0)
        {
            // Choose a random platform prefab
            int randomIndex = Random.Range(0, platformPrefabs.Length);

            // Instantiate the new platform
            Instantiate(platformPrefabs[randomIndex], nextSpawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogError("No platform prefabs assigned in the Inspector.");
        }
    }

    private void DestroyPrevPlatform()
    {
        // Destroy the previous platform after 5 seconds
        if (currentPlatform != null)
        {
            Destroy(currentPlatform.gameObject, 5f);
        }
        else
        {
            Debug.LogWarning("No previous platform to destroy.");
        }
    }

    private void UpdatePlatformPosition()
    {
        // Update the next spawn position
        nextSpawnPosition += new Vector3(-platformSpacing, 0, 0);
    }

}