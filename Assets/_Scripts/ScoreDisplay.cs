using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI  scoreText;
    private ScoreManager scoreManager;

    void Start(){
        scoreText.text = "Score: 0";
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    void Update()
    {
        UpdateTheScoreText();
    }

    void UpdateTheScoreText(){
        if (scoreManager != null && scoreText != null)
            scoreText.text = "Score: " + Mathf.FloorToInt(scoreManager.score).ToString();
    }
}
