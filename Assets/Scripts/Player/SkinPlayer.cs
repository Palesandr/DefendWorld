using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinPlayer : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] scins;

    private void Start()
    {
        int scinsID = PlayerPrefs.GetInt("skinsID");

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = scins[scinsID];
    }
}
