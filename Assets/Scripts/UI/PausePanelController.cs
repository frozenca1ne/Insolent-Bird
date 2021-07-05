using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausePanelController : MonoBehaviour
{
	[SerializeField] private Button homeButton;
	[SerializeField] private Button returnButton;
	[Header("Sound")]
	[SerializeField] private Image soundButtonImage;
	[SerializeField] private Sprite soundOn;
	[SerializeField] private Sprite soundOff;
	[SerializeField] private AudioController audioController;
	[SerializeField] private Button soundButton;
	[Header("Panels")]
	[SerializeField] private CanvasGroup pausePanel;
	[SerializeField] private CanvasGroup homePanel;
	[SerializeField] private CanvasGroup gamePanel;

	private bool isSoundOn;

	private void OnEnable()
	{
		returnButton.onClick.AddListener(ReturnToGame);
		homeButton.onClick.AddListener(BackHome);
		returnButton.onClick.AddListener(ReturnToGame);
	}
	private void Start()
	{
		isSoundOn = homePanel.GetComponent<StartMenuController>().IsSoundOn;
	}
	private void ReturnToGame()
	{
		Time.timeScale = 1;
		pausePanel.gameObject.SetActive(false);
	}
	private void BackHome()
	{
		pausePanel.gameObject.SetActive(false);
		gamePanel.gameObject.SetActive(false);
		homePanel.gameObject.SetActive(true);
	}
	private void ChangeVolume()
	{
		if (isSoundOn)
		{
			audioController.MuteSound(false);
		}
		else
		{
			audioController.MuteSound(true);
		}
		ChangeSoundButtonImage();
	}
	private void ChangeSoundButtonImage()
	{
		isSoundOn = isSoundOn != true;
		soundButtonImage.sprite = isSoundOn == true ? soundOn : soundOff;
	}


}
