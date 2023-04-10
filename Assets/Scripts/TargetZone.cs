using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Tower>())
        {
            TargetManager.instance.targets.Add(other.gameObject);
        }
        if (other.TryGetComponent(out Coin coin))
        {
            if (CoinTakeManager.instance.backpackItems != CoinTakeManager.instance.maxItems)
            {
                coin.inRotate = false;

                CoinManager.instance.currentCoinCount--;

                CoinTakeManager.instance.Collect(coin);
            }
            else
            {
                print("MaxItem");
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Tower>())
        {
            TargetManager.instance.targets.Remove(other.gameObject);
        }
    }
}
