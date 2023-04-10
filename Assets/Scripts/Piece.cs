using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Piece : MonoBehaviour
{
    private void Start()
    {    
        Physics.IgnoreCollision(GetComponent<Collider>(), GameController.instance.player.GetComponent<Collider>(), true);

        for (int i = 0; i < GameController.instance.limiters.Length; i++)
        {
            Physics.IgnoreCollision(GetComponent<Collider>(), GameController.instance.limiters[i], true);
        }

        Invoke(nameof(Scale), Random.Range(0.5f, 1f));
    }

    void Scale()
    {
        transform.DOScale(0f, 1f).SetEase(Ease.InBack).OnComplete(DestroyPiece);
    }
    void DestroyPiece()
    {
        Destroy(gameObject);
    }
}
