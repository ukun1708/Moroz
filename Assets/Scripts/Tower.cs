using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tower : MonoBehaviour
{
    [SerializeField]
    GameObject block;
    int blockCount = 1;

    void AddBlock()
    {
        var currentBlock = Instantiate(block, transform.position, transform.rotation);

        currentBlock.transform.localScale = Vector3.zero;

        Vector3 lastBlock = transform.GetChild(transform.childCount - 1).transform.position;

        currentBlock.transform.SetParent(transform);

        currentBlock.transform.DOScale(block.transform.localScale, .5f).SetEase(Ease.OutBack);

        Vector3 pos = new Vector3(lastBlock.x, lastBlock.y + block.transform.localScale.y, lastBlock.z);

        currentBlock.transform.position = pos;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Coin>())
        {
            Destroy(other.gameObject);
            UIManager.instance.ChangeCoinUIPlus();
            SoundManager.instance.PlaySound(SoundManager.AudioType.coin, 0.8f, Random.Range(0.95f, 1.1f), false);
            VfxManager.instance.PlayVFX(VfxManager.VfxType.explosion, other.transform.position);
            AddBlock();
        }
    }
}
