using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameMenuController : MonoBehaviour
{
	[Header("Score")]
	[SerializeField] private TMP_Text scoreText;
	[SerializeField] private TMP_Text bestScoreText;
	[SerializeField] private TMP_Text coinsText;
	[SerializeField] private TMP_Text totalCoinsText;
	[Header("Pause")]
	[SerializeField] private Button pauseButton;
	[SerializeField] private CanvasGroup pausePanel;

	private void OnEnable()
	{
		pauseButton.onClick.AddListener(OpenPausePanel);

		LevelManager.OnScoreChanged += ChangeScore;
		LevelManager.OnBestScoreChanged += ChangeBestScore;
		LevelManager.OnCoinsChanged += ChangeCoinsCount;
		LevelManager.OnTotalCoinsChanged += ChangeTotalCoins;
	}
	private void OnDisable()
	{
		LevelManager.OnScoreChanged -= ChangeScore;
		LevelManager.OnBestScoreChanged -= ChangeBestScore;
		LevelManager.OnCoinsChanged -= ChangeCoinsCount;
		LevelManager.OnTotalCoinsChanged -= ChangeTotalCoins;
	}
	private void OpenPausePanel()
	{
		pausePanel.gameObject.SetActive(true);
		Time.timeScale = 0;
	}
	private void ChangeScore(int value)
	{
		scoreText.text = $"{value }";
	}
	private void ChangeBestScore(int value)
	{
		bestScoreText.text = $"BEST SCORE : {value }";
	}
	private void ChangeCoinsCount(int value)
	{
		coinsText.text = $"{value }";
	}
	private void ChangeTotalCoins(int value)
	{
		totalCoinsText.text = $"TOTAL : {value }";
	}
}

