using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountEnemy : MonoBehaviour
{
    public int countEnemy = 1;
    public static CountEnemy instance;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PlusCount(int countValue)
    {
        countEnemy++;
       // Debug.Log(countEnemy);
    }

    public void MinusCount(int countValue)
    {
        countEnemy--;
        //Debug.Log(countEnemy);
    }
}
