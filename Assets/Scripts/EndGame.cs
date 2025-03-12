using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGame : MonoBehaviour
{
	#region Propierties
	public event Action OnJetpackSoundOff;
	#endregion

	#region Fields
	[SerializeField] private GameObject _finishPanel;
	[SerializeField] private TextMeshProUGUI _scoreText;
	#endregion

	#region Unity CallBacks
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			OnJetpackSoundOff?.Invoke();
			_finishPanel.SetActive(true);

			AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();
			foreach (AudioSource audio in allAudioSources)
			{
				audio.Stop();
			}
			float timer = Time.time / 60;
			int time = (int)timer;
			Time.timeScale = 0;
			_scoreText.text = "Time Score : " + time.ToString();
		}
	}
	#endregion
}
