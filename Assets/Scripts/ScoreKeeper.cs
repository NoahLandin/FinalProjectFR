using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    public int scoreValue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore()
    {
        scoreValue += 5;
        scoreText.text = "Score:" +scoreValue.ToString();
    }
}
