using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    #region Singleton
    public static AnimationManager instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion 
    
    public void StopAttack()
    {
        GameController.instance.animator.SetBool("isAttack", false);
    }
    public void Attack()
    {
        GameController.instance.animator.SetBool("isAttack", true);
    }
}
