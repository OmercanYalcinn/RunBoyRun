using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public GameObject gameHeading;
    public GameObject playButton;
    public GameObject optionsButton;
    public GameObject audioSetting;
    public GameObject languageSetting;
    public GameObject replayButton;
    public GameObject scoreText;

    private UIState ui_state;
    private PlayerMovement _playerMovement;
    private enum UIState { 
        MainMenu, 
        InGame, 
        GameOver, 
        Options 
    }

    void Start()
    {
        Time.timeScale = 0;     // Freez the GAME here
        _playerMovement = FindObjectOfType<PlayerMovement>();      // Find the PlayerMovement Script
        // The game is starting the the welcome page that contains Play, Options button selections
        SetUIState(UIState.MainMenu);
    }

    // Centralized method to control UI visibility based on state
    void SetUIState(UIState state)
    {
        ui_state = state;

        // Toggle UI elements based on the current state
        gameHeading.SetActive(state == UIState.MainMenu);
        playButton.SetActive(state == UIState.MainMenu);
        optionsButton.SetActive(state == UIState.MainMenu);
        audioSetting.SetActive(state == UIState.Options);
        languageSetting.SetActive(state == UIState.Options);
        replayButton.SetActive(state == UIState.GameOver);
        scoreText.SetActive(state == UIState.InGame);
    
        // Freeze game for all states except active gameplay
        if (state == UIState.InGame)
        {
            Time.timeScale = 1; // Resume game during active gameplay
            _playerMovement.StartMovement(); // Enable player movement
        }
        else
        {
            Time.timeScale = 0; // Freeze game for Main Menu, Options, and Game Over
            _playerMovement.StopMovement();
        }
    }

    // Method for starting the game
    public void OnPlayButtonClicked()
    {
        Time.timeScale = 1;
        SetUIState(UIState.InGame);
    }

    // Method for opening the options menu
    public void OnOptionsButtonClicked()
    {
        SetUIState(UIState.Options);
    }

    // Method for returning to main menu from options
    public void OnBackToMenuFromOptions()
    {
        SetUIState(UIState.MainMenu);
    }

    // Method for replaying the game after Game Over
    public void OnReplayButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Show the Replay Button when the player dies
    public void PlayerDied()
    {
        SetUIState(UIState.GameOver);
    }

}