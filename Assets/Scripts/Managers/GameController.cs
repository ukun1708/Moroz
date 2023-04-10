using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    #region Singleton
    public static GameController instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    public GameObject player;
    public float playerMoveSpeed;

    public Animator animator;

    public DynamicJoystick joystick;

    public Collider[] limiters;

    public GameObject backpack;

    public GameObject targetZone;

    private void Update()
    {
        player.GetComponent<Player>().MovementPlayer(joystick, animator, playerMoveSpeed);

        ClickVerification();
    }

    void ClickVerification()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AnimationManager.instance.StopAttack();
        }
        if (Input.GetMouseButtonUp(0))
        {
            TargetManager.instance.FindClosestTarget();
        }
    }
}
