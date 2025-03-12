using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
	#region Fields
	[SerializeField] Button _startGameButton;
	[SerializeField] Button _exitGameButton;
	[SerializeField] Button _settingsGameButton;
	[SerializeField] UISettings _settingsPanel;
	#endregion

	#region Unity Callbacks
	// Start is called before the first frame update
	void Start()
    {
		_startGameButton.onClick.AddListener(StartGame);
		_exitGameButton.onClick.AddListener(ExitGame);
		_settingsGameButton.onClick.AddListener(OpenSettings);
    }
	#endregion

	#region Private Methods
	private void ExitGame()
	{
		Application.Quit();
	}

	private void StartGame()
	{
		SceneManager.LoadScene("GameScene");
	}
	private void OpenSettings()
	{
		_settingsPanel.gameObject.SetActive(true);
		gameObject.SetActive(false);
	}
	#endregion
}
