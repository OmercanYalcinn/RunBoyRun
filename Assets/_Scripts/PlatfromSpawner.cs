using UnityEngine;

public class PlatfromSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] platformPrefabs;  // array to hold platform types
    public Transform playerTransform;   // Reference ro player position
    [SerializeField] private Vector3 nextSpawnPoint;    // Position to spawn the next platform
    [SerializeField] private float platformLength = 25;     //The ground is (25,1,5)

    void Start(){
        nextSpawnPoint = transform.position;
    }

    void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player"))
        {
            Debug.Log("Trigger Happend");
            SpawnPoint();    
        }
    }

    private void SpawnPoint(){
        // To select randomly one of the platform prefabs
        int platformIndex = Random.Range(0, platformPrefabs.Length); // For now with the two types of platforms, 1/2
        GameObject newPlatform = Instantiate(platformPrefabs[platformIndex], nextSpawnPoint, Quaternion.identity);

        //now update the next spawn point
        nextSpawnPoint.x += platformLength;
        Destroy(transform.parent.gameObject, 5f);

    }

}
