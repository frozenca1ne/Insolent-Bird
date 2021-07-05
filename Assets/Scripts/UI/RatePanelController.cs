using UnityEngine;
using UnityEngine.UI;

public class RatePanelController : MonoBehaviour
{
    [SerializeField] private Image panel;
    [SerializeField] private Button cancelButton;
    [SerializeField] private Button rateButton;

	private void OnEnable()
	{
		cancelButton.onClick.AddListener(Cancel);
		rateButton.onClick.AddListener(Rate);
	}

	private void Cancel()
	{
        panel.gameObject.SetActive(false);
	}
    private void Rate()
	{
        Debug.Log("Thank you!");
	}
}
