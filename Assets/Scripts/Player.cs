using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{    
    float ySpeed;
    float originalStepOffset;

    CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        originalStepOffset = characterController.stepOffset;
    }
    public void MovementPlayer(DynamicJoystick joystick, Animator animator, float maximumSpeed)
    {
        float hor = joystick.Horizontal;
        float ver = joystick.Vertical;

        Vector3 movedirection = new Vector3(hor, 0f, ver);

        float inputMagnitude = Mathf.Clamp01(movedirection.magnitude);
        animator.SetFloat("Input Magnitude", inputMagnitude, 0.05f, Time.deltaTime);
        float speed = inputMagnitude * maximumSpeed;
        movedirection.Normalize();

        ySpeed += Physics.gravity.y * Time.deltaTime;

        if (characterController.isGrounded)
        {
            characterController.stepOffset = originalStepOffset;
            ySpeed = -0.5f;
        }
        else
        {
            characterController.stepOffset = 0f;
        }

        Vector3 velocity = movedirection * speed;
        velocity.y = ySpeed;

        characterController.Move(velocity * Time.deltaTime);

        if (movedirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movedirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 850 * Time.deltaTime);

            animator.SetBool("isAttack", false);
        }
    }
    public void Attack()
    {
       
    }
}
