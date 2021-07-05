using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    [SerializeField] private EnemysList enemysList;
    [SerializeField] private Transform activeEnemyPosition;
    [SerializeField] private Transform[] sleepingPositions;
    [Header("RandomConfig")]
    [SerializeField] private int chanceToActive = 50;
    [SerializeField] private int chanceToFull = 50;

    private enum StepState
	{
        Clean,
        Sleeping,
        Normal,
        Horned
	}
    
    private void CreateEnemy(StepState state)
	{
        switch (state)
        {
            case StepState.Clean:

                break;
            case StepState.Sleeping:
                Instantiate(enemysList.NoHeadEnemy, sleepingPositions[SelectedPosition()].position, Quaternion.identity);
                break;
            case StepState.Normal:
                Instantiate(enemysList.NormalEnemy, activeEnemyPosition.position, Quaternion.identity);
                break;
            case StepState.Horned:
                Instantiate(enemysList.HornedEnemy, activeEnemyPosition.position, Quaternion.identity);
                break;
        }	
	}
    private int SelectedPosition()
	{
        var randomNumber = Random.Range(0, sleepingPositions.Length - 1);
        return randomNumber;
        
	}
	private void Start()
	{
        SelectStepState();
    }
	private void SelectStepState()
	{
        var currentChance = Random.Range(0, 100);
        if(currentChance<chanceToActive)
		{
            if(currentChance<chanceToFull)
			{
                CreateEnemy(StepState.Clean);
			}
            else
			{
                CreateEnemy(StepState.Sleeping);
			}
		}
        else
		{
            var randomNumber = Random.Range(0, 1);
            if(randomNumber == 0)
			{
                CreateEnemy(StepState.Normal);
            }
            else
			{
                CreateEnemy(StepState.Horned);
            }
		}
        
	}
    

}
