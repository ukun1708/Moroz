using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Print : MonoBehaviour
{
    Color color;
    private void Start()
    {
        color = GetComponent<SpriteRenderer>().color;
        Destroy(gameObject, 5f);
    }
    void Update()
    {
        color = new Color(color.r, color.g, color.b, Mathf.MoveTowards(color.a, 0f, Time.deltaTime / 5f));
        GetComponent<SpriteRenderer>().color = color;
    }
}
