using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] Button _playButton;
    [SerializeField] Button _quitButton;
    private int _currentSceneIndex;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (_playButton)
        {
            _playButton.onClick.AddListener(LoadNextScene);
        }

        if (_quitButton)
        {
            _quitButton.onClick.AddListener(QuitGame);
        }
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(_currentSceneIndex + 1);
    }

    private void LoadPrevScene()
    {
        SceneManager.LoadScene(_currentSceneIndex - 1);
    }
    private void QuitGame()
    {
        Application.Quit();
    }
}