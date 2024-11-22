using UnityEngine;

public class PlatfromSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] platformPrefabs;  // array to hold platform types
    public Transform platformPrefabTransform;   // Reference to player position
    [SerializeField] private Vector3 nextSpawnPoint;    // Position to spawn the next platform
    [SerializeField] private float platformLength = 25;     //The ground is (25,1,5)
    [SerializeField] private bool isSpawning = false;

    void Start(){
        nextSpawnPoint = Vector3.zero;    // Vector3.zero form
    }

    void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player") && !isSpawning)
        {
            isSpawning = true;
            Debug.Log("Trigger Happend");
            SpawnPoint();
            isSpawning = false;
        }
    }

    private void SpawnPoint(){
        // To select randomly one of the platform prefabs
        int platformIndex = Random.Range(0, platformPrefabs.Length); // For now with the two types of platforms, 1/2
        
        //now update the next spawn point, negative is working because the camera angle at the beggining is act like that way LOL 
        nextSpawnPoint.x -= platformLength;
        GameObject newPlatform = Instantiate(platformPrefabs[platformIndex], nextSpawnPoint, Quaternion.identity);
        
        PlatfromSpawner spawner = newPlatform.GetComponentInChildren<PlatfromSpawner>();
        if (spawner != null && !spawner.enabled)
        {
            spawner.enabled = true;
        }

        Destroy(transform.parent.gameObject, 5f);
    }
}