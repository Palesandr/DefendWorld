using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableScriptFlyDrons : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(startfly());
    }



    IEnumerator startfly()
    {
        yield return new WaitForSeconds(1f);
        gameObject.GetComponent<MoveDrons>().enabled = true;
    }
}
