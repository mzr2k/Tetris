using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Button playButton;
    public Button scoreHistoryButton;

    // Start is called before the first frame update
    void Start()
    {
        // Add listeners to buttons
        playButton.onClick.AddListener(OnPlayButtonClicked);
        scoreHistoryButton.onClick.AddListener(OnScoreHistoryButtonClicked);

    }

    public void OnPlayButtonClicked()
    {
        // Load the game scene
        SceneManager.LoadScene("Tetris"); // Replace with your game scene name
    }

    public void OnScoreHistoryButtonClicked()
    {
        // Load the score history scene
        SceneManager.LoadScene("ScoreHistoryScene"); // Replace with your score history scene name
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
