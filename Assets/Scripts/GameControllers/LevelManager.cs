using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
	public static event Action<int> OnScoreChanged;
	public static event Action<int> OnBestScoreChanged;
	public static event Action<int> OnCoinsChanged;
	public static event Action<int> OnTotalCoinsChanged;


	private int currentScore;
	private int bestScore;
	private int coinsEarn;
	private int totalCoins;

	private void OnEnable()
	{
		ScoreHelper.OnScoreAdds += AddPointsToScore;
		ScoreHelper.OnCoinsAdd += AddCoins;
	}
	private void OnDisable()
	{
		ScoreHelper.OnScoreAdds -= AddPointsToScore;
		ScoreHelper.OnCoinsAdd -= AddCoins;
	}
	private void Start()
	{
		ResetScores();
	}
	private void ResetScores()
	{
		StartCoroutine(ResetScoreWithDelay());
	}

	private IEnumerator ResetScoreWithDelay()
	{
		yield return new WaitForSeconds(0.3f);
		currentScore = 0;
		coinsEarn = 0;
	}
	public void AddPointsToScore(int value)
	{
		currentScore += value;
		OnScoreChanged?.Invoke(currentScore);
		CheckNewRecord();
	}
	private void CheckNewRecord()
	{
		//Check score in json
		OnBestScoreChanged?.Invoke(currentScore);
	}
	public void AddCoins(int value)
	{
		coinsEarn += value;
		totalCoins += value;
		OnCoinsChanged?.Invoke(coinsEarn);
		ChangeTotalCoins();
	}
	private void ChangeTotalCoins()
	{
		//Check total coins in json
		OnTotalCoinsChanged?.Invoke(totalCoins);
	}
}
