using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CoinManager : MonoBehaviour
{
    #region Singleton
    public static CoinManager instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion
    [SerializeField]
    int coinMaxCount;

    public int currentCoinCount;

    [SerializeField]
    GameObject coin;

    [SerializeField]
    float posX, posZ;

    bool ready = true;
    
    void Update()
    {
        if (ready == true)
        {
            ready = false;

            if (currentCoinCount < coinMaxCount)
            {
                StartCoroutine(CreateCoins());
            }
        }
    }

    IEnumerator CreateCoins()
    {
        Vector3 pos = new Vector3(Random.Range(-posX, posX), 0f, Random.Range(-posZ, posZ));
        var currentCoin = Instantiate(coin, pos, Quaternion.Euler(Vector3.left * 90f));

        currentCoinCount++;

        currentCoin.transform.localScale = Vector3.zero;

        currentCoin.transform.DOScale(Vector3.one, .5f).SetEase(Ease.OutBack);

        var movePos = new Vector3(currentCoin.transform.position.x, currentCoin.transform.position.y + 1f, currentCoin.transform.position.z);

        currentCoin.transform.DOMove(movePos, .5f).SetEase(Ease.OutBack);

        yield return new WaitForSeconds(Random.Range(0.5f, 1f));

        ready = true;
    }
}
