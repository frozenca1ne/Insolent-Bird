using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EndGamePanel : MonoBehaviour
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button birdUpgradeButton;
    [SerializeField] private Button rateButton;
    [SerializeField] private Button homeButton;
    [SerializeField] private Button shareButton;

    [SerializeField] private Image textImage;
    [SerializeField] private GridLayoutGroup buttonsGroup;

    [SerializeField] private float moveOffset = 540f;
    [SerializeField] private float moveDelay = 0.5f;
    [SerializeField] private float moveRate = 0.8f;

	private void Start()
	{
        ShowMenu();
	}

	private void ShowMenu()
	{
        Sequence moveSequence = DOTween.Sequence();
        moveSequence.Append(textImage.transform.DOMoveX(moveOffset, moveDelay))
            .AppendInterval(moveRate)
            .Append(restartButton.transform.DOMoveX(moveOffset, moveDelay))
            .AppendInterval(moveRate)
            .Append(buttonsGroup.transform.DOMoveX(moveOffset, moveDelay));
	}
}
