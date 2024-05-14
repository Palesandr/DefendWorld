using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAnimation : MonoBehaviour
{
    public Animator anim;
    public float xp;
    public int _levelUp;

    public int levelUp
    {
        get { return _levelUp; }
        set { _levelUp = value; }
    }

    public void LevelUp()
    {

        xp++;

        //Debug.Log(xp);

        if (xp == 10)
        {
            levelUp++;
            xp = 0;
            anim.SetBool("isBonus", true);
            AudioManager.instance.Play("UpdateCompleteGun");
        }
        else
        {
            anim.SetBool("isBonus", false);
        }
    }
}
