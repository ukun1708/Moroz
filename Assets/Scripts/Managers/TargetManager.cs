using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    #region Singleton
    public static TargetManager instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    Tween rotateTween;

    [SerializeField]
    float durationRotateToTarget = .5f;

    public GameObject target;

    public List<GameObject> targets = new List<GameObject>();

    public void FindClosestTarget()
    {
        Transform finder = GameController.instance.player.transform;

        float closestDistance = Mathf.Infinity;

        GameObject currentTarget = null;

        foreach (var item in targets)
        {
            float currentDistance;

            Vector3 playerPos = new Vector3(finder.position.x, finder.position.y + 1f, finder.position.z + 0.5f);
            currentDistance = Vector3.Distance(playerPos, item.transform.position);
            if (currentDistance < closestDistance)
            {
                closestDistance = currentDistance;
                currentTarget = item;
            }
        }
        if (currentTarget != null)
        {
            target = currentTarget;

            Vector3 dir = target.transform.position - finder.position;
            Quaternion toRotation = Quaternion.LookRotation(dir);

            Vector3 rotate = new Vector3(finder.transform.eulerAngles.x, toRotation.eulerAngles.y, finder.transform.eulerAngles.z);

            if (target.GetComponent<Tower>())
            {
                rotateTween = finder.DORotate(rotate, durationRotateToTarget).SetEase(Ease.Linear).OnComplete(Pumping);
            }
        }
    }
    
    public void Pumping()
    {
        var pos = new Vector3(target.transform.position.x, target.transform.position.y + 1f, target.transform.position.z);
        CoinTakeManager.instance.PumpingCoin(pos);
    }
}
