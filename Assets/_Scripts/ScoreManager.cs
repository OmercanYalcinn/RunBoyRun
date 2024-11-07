using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public float score;     // variable to store score
    public float scorePerSecond = 10f;      // how much score to add per second

    void Start(){
        score = 0;
    }

    void Update(){
        TimeBasedScore();
    }
    public void TimeBasedScore(){
        score += scorePerSecond * Time.deltaTime;
        Debug.Log("Current Score: " + score);
    }

    // Collectibles or Bonuses based Score Method
    void OnTriggerEnter(Collider other){
        if (other.CompareTag("Collectible"))
        {
            score += 100;
            Destroy(other.gameObject);
        }
    }

}
