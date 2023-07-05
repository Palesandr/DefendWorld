using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusBarPlayer : MonoBehaviour
{
    public Image bonusBar;
    public Fire fire;

    public void Update()
    {
        bonusBar.fillAmount = Fire.updBullet / Fire.maxUP;
    }

}
