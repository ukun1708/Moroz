using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CoinTakeManager : MonoBehaviour
{
    #region Singleton
    public static CoinTakeManager instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    [SerializeField]
    float durationMoveLog = .5f;

    public int maxItems = 8;
    public int backpackItems = 0;

    [SerializeField]
    int maxItemsColumn = 4;
    [SerializeField]
    private float jumpPower;
    [SerializeField]
    private int numJumpsm;
    [SerializeField]
    private float jumpDuration;

    public void Collect(Coin coin)
    {
        coin.GetComponent<Collider>().enabled = false;
        coin.transform.SetParent(GameController.instance.backpack.transform);

        int currentCountItems = backpackItems;

        if (currentCountItems < 1)
        {
            backpackItems++;

            coin.transform.DOLocalJump(Vector3.zero, jumpPower, numJumpsm, jumpDuration).OnComplete(EffectCoin);
            coin.transform.DOLocalRotate(new Vector3(0f, 0f, 0f), durationMoveLog).SetEase(Ease.InOutBack);
        }
        if (currentCountItems > 0)
        {
            var scale = .25f;
            var pos = new Vector3(0f, currentCountItems * scale - currentCountItems / maxItemsColumn * scale * maxItemsColumn, -currentCountItems / maxItemsColumn * scale * 3.25f);
            //var pos = new Vector3(Random.Range(-scale, scale), Random.Range(-scale, scale), -currentCountItems / maxItemsColumn * 0.25f);
            
            backpackItems++;

            coin.transform.DOLocalJump(pos, jumpPower, numJumpsm, jumpDuration).OnComplete(EffectCoin);
            coin.transform.DOLocalRotate(new Vector3(0f, 0f, 0f), durationMoveLog).SetEase(Ease.InOutBack);
        }
    }
    void EffectCoin()
    {
        SoundManager.instance.PlaySound(SoundManager.AudioType.coin, 0.8f, Random.Range(0.95f, 1.1f), false);        
    }
    public void PumpingCoin(Vector3 targetPos)
    {

        StartCoroutine(Pumping(targetPos));

    }
    IEnumerator Pumping(Vector3 targetPos)
    {
        if (GameController.instance.backpack.transform.childCount > 0)
        {
            var coin = GameController.instance.backpack.transform.GetChild(GameController.instance.backpack.transform.childCount - 1).gameObject;
            coin.transform.parent = null;

            backpackItems--;

            Physics.IgnoreCollision(coin.GetComponent<Collider>(), GameController.instance.targetZone.GetComponent<Collider>(), true);

            coin.GetComponent<MeshCollider>().enabled = true;
            
            //UIManager.instance.ChangeTreeUIMinus();

            coin.transform.DOLocalJump(targetPos, jumpPower, numJumpsm, jumpDuration);

            coin.transform.DOLocalRotate(new Vector3(0f, 0f, 90f), durationMoveLog).SetEase(Ease.InOutBack);

            yield return new WaitForSeconds(0.1f);

            StartCoroutine(Pumping(targetPos));
        }
    }
}
