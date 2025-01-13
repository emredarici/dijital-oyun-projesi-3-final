using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameEvent hitEvent;

    private int score = 0;

    private void OnEnable()
    {
        hitEvent.OnEventRaised += UpdateScore;
    }

    private void OnDisable()
    {
        hitEvent.OnEventRaised -= UpdateScore;
    }

    private void UpdateScore()
    {
        score += 1;
        scoreText.text = "Score: " + score.ToString();
    }
}
