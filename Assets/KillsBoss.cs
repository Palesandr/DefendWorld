using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
//using TMPro;

public class KillsBoss : MonoBehaviour
{
    public TextMeshProUGUI textKills;



    void Update()
    {
        textKills.text = GameManagers.countEnemy.ToString() + " �� " + SpawnBoss.afterSpawnBoss.ToString();
    }
}
