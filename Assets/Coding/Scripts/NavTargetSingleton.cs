using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavTargetSingleton
{

    static NavTargetSingleton instance;
    GameObject[] mPossibleTargets;

    NavTargetSingleton()
    {
        mPossibleTargets = GameObject.FindGameObjectsWithTag("NavTarget");
    }

    public static NavTargetSingleton getInstance()
    {
        if (instance == null)
        {
            instance = new NavTargetSingleton();
        }
        return instance;
    }

    public Transform getRandomTarget()
    {
        return mPossibleTargets[Random.Range(0, mPossibleTargets.Length)].transform;
    }
}
