using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public bool inRotate = true;

    private void Start()
    {
        GetComponent<Collider>().enabled = false;
        StartCoroutine(CollEnabler());
    }
    private void Update()
    {
        if (inRotate == true)
        {
            transform.Rotate(Vector3.forward * 40f * Time.deltaTime);
        }        
    }
    IEnumerator CollEnabler()
    {
        yield return new WaitForSeconds(.5f);
        GetComponent<Collider>().enabled = true;        
    }
}
