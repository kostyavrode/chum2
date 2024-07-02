using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject[] uiPanels;
    [SerializeField] private TMP_Text moneyBar;
    [SerializeField] private TMP_Text scoreBar;
    [SerializeField] private TMP_Text bestScoreBar;
    private GameManager gameManager;
    private GameInfoHandler gameInfoHandler;
    private void Start()
    {
        gameInfoHandler = ServiceLocator.GetService<GameInfoHandler>();
        gameManager= ServiceLocator.GetService<GameManager>();
        ShowMoney();
        GameManager.onGameStateChange += CheckGameState;
    }
    private void OnDisable()
    {
        
    }
    private void CheckGameState(GameState state)
    {
        switch (state)
        {
            case GameState.OFF:
                break;
            case GameState.PLAYING:
                break;
            case GameState.PAUSED:
                break;
            case GameState.FINISHED:
                bestScoreBar.text = gameInfoHandler.GetBestScore().ToString();
                uiPanels[4].SetActive(true);
                uiPanels[3].SetActive(false);
                break;
            case GameState.END:
                break;
        }
    }
    public void ShowMoney()
    {
        moneyBar.text = gameInfoHandler.GetMoney().ToString();
    }
    public void ShowScore()
    {
        scoreBar.text= gameInfoHandler.GetScore().ToString();
    }
    public void ShowBestScore()
    {
        bestScoreBar.text=gameInfoHandler.GetBestScore().ToString();
    }
    public void StartButton()
    {
        ServiceLocator.GetService<GameManager>().StartGame();
    }
    public void PauseButton()
    {
        ServiceLocator.GetService<GameManager>().PauseGame();
    }
    public void ContinueButton()
    {
        gameManager.StartGame();
    }
    public void EndGameButton()
    {
        ServiceLocator.GetService<GameManager>().EndGame();
    }
    public void SoundOnButton()
    {
        ServiceLocator.GetService<AudioManager>().ChangeSoundState(SoundState.ON);
    }
    public void SoundOffButton()
    {
        ServiceLocator.GetService<AudioManager>().ChangeSoundState(SoundState.OFF);
    }
    public void VibroOnButton()
    {
        ServiceLocator.GetService<VibrationManager>().ChangeVibroState(VibroState.ON);
    }
    public void VibroOffButton()
    {
        ServiceLocator.GetService<VibrationManager>().ChangeVibroState(VibroState.OFF);
    }
}
