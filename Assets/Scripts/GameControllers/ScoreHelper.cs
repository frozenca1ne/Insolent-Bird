using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class ScoreHelper 
{
    public static event Action<int> OnScoreAdds;
    public static event Action<int> OnCoinsAdd;

    private int currentScoreEarn;
    private int currentCoinsEarn;

    public int CurrentScoreEarn
    {
        get => currentScoreEarn;
        set
        {
            currentScoreEarn += value;
            OnScoreAdds?.Invoke(currentScoreEarn);
        }
    }

    public int CurrentCoinsEarn
    {
        get => currentCoinsEarn;
        set
        {
            currentCoinsEarn += value;
            OnCoinsAdd?.Invoke(currentCoinsEarn);
        }
    }
}
