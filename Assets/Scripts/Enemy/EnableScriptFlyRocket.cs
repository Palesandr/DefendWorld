using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableScriptFlyRocket : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(startfly());
    }



    IEnumerator startfly()
    {
        yield return new WaitForSeconds(0.7f);
        gameObject.GetComponent<MoveRocket>().enabled = true;
    }
}
