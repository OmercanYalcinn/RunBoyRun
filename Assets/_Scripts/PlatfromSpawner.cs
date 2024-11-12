using UnityEngine;

public class PlatfromSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] platformPrefabs;  // array to hold platform types
    public Transform platformPrefabTransform;   // Reference to player position
    [SerializeField] private Vector3 nextSpawnPoint;    // Position to spawn the next platform
    [SerializeField] private float platformLength = 25;     //The ground is (25,1,5)

    void Start(){
        nextSpawnPoint = Vector3.zero;    // Vector3.zero form
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
        
        //now update the next spawn point, negative is working because the camera angle at the beggining is act like that way LOL 
        nextSpawnPoint.x -= platformLength;
        Instantiate(platformPrefabs[platformIndex], nextSpawnPoint, Quaternion.identity);

        Destroy(transform.parent.gameObject, 5f);
    }
}