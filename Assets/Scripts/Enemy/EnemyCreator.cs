
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    [SerializeField] private EnemysList enemysList;
    [SerializeField] private Transform activeEnemyPosition;
    [SerializeField] private Transform[] sleepingPositions;
    [Header("RandomConfig")]
    [SerializeField] private int chanceToActive = 5;
    [SerializeField] private int chanceToFull = 6;

    private enum StepState
	{
        Clean = 1,
        Sleeping =2,
        Normal = 3,
        Horned = 4
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
        var currentChance = Random.Range(1, 4);
        CreateEnemy((StepState)currentChance);
    }
    

}
