using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class StartMenuController : MonoBehaviour
{
    [Header("Score")]
    [SerializeField] private TMP_Text bestScoreText;
    [Header("Buttons")]
    [SerializeField] private Button upgradeButton;
    [SerializeField] private Button rateButton;
    [SerializeField] private Button infoButton;
    [Header("Rate")]
    [SerializeField] private Image ratePanel;
    [Header("Sound")]
    [SerializeField] private Button soundButton;
    [SerializeField] private Image soundButtonImage;
    [SerializeField] private Sprite soundOn;
    [SerializeField] private Sprite soundOff;
    [SerializeField] private AudioController audioController;

    private bool isSoundOn;

	public bool IsSoundOn { get => isSoundOn; set => isSoundOn = value; }

	private void Update()
	{
        StartGame();
	}
	private void OnEnable()
	{
        SetBestScore();
        IsSoundOn = true;
        //check sound settings from json

        rateButton.onClick.AddListener(ActivateRatePanel);
        soundButton.onClick.AddListener(ChangeVolume);

	}
	private void SetBestScore()
	{
        //set best score from json
	}
    private void ActivateRatePanel()
	{
        ratePanel.gameObject.SetActive(true);
	}
    private void ChangeVolume()
	{
		if (IsSoundOn)
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
        IsSoundOn = IsSoundOn != true;
        soundButtonImage.sprite = IsSoundOn == true ? soundOn : soundOff;
    }
    private void StartGame()
    {
        if (!Input.anyKey) return;
        gameObject.SetActive(false);
    }

}
