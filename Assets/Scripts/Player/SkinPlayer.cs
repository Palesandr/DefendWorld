using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using YG;

public class SkinPlayer : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] scins;

    private void Start()
    {
        int scinsID = PlayerPrefs.GetInt("skinsID");

        //int scinsID = YandexGame.savesData.skinID;

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = scins[scinsID];
    }
}
