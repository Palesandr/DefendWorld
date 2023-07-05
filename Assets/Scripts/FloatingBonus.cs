using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingBonus : MonoBehaviour
{
    public Sprite[] spriteShield = new Sprite[4];
    public SpriteRenderer spriteRenderer;
    public static FloatingBonus instance;



    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
