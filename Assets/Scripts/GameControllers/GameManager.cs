using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	[SerializeField] private CanvasGroup gameMenu;
	[SerializeField] private CanvasGroup gameoverMenu;
	[SerializeField] private int sceneIndex = 0;
	
   private enum GameState
	{
		Start,
		Play,
		Pause,
		Die
	}

	private void ChangeGameState(GameState state)
	{
		switch(state)
		{
			case GameState.Start:
				//SceneManager.LoadScene(sceneIndex);			
				break;
			case GameState.Play:
				Time.timeScale = 1;
				gameMenu.gameObject.SetActive(true);
				break;
			case GameState.Pause:
				Time.timeScale = 0;
				break;
			case GameState.Die:
				gameMenu.gameObject.SetActive(false);
				gameoverMenu.gameObject.SetActive(true);
				break;
		}
	}
	private void OnEnable()
	{
		ChangeGameState(GameState.Start);
	}

}
