using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimStateController : MonoBehaviour
{
    Animator animator;
    int isMovingHash;
    [SerializeField] ThirdPersonMovement _playerMovement;

    private void Start()
    {
        animator = GetComponent<Animator>();
        isMovingHash = Animator.StringToHash("isMoving");
    }

    private void Update()
    {
        bool isMoving = animator.GetBool(isMovingHash);
        bool forwardPressed = Input.GetKey("w");
        bool leftPressed = Input.GetKey("a");
        bool rightPressed = Input.GetKey("d");
        bool backPressed = Input.GetKey("s");

        if (!isMoving && (forwardPressed || leftPressed || rightPressed || backPressed))
        {
            Debug.Log("I LIKE TO MOVE IT MOVE IT");
            animator.SetBool(isMovingHash, true);
        }
        if (isMoving && !forwardPressed && !leftPressed && !rightPressed && !backPressed)
        {
            animator.SetBool(isMovingHash, false);
            Debug.Log("RED LIGHT");
        }


        if (Input.GetKey("c"))
        {
            Debug.Log("GET DOWN MR PRESIDENT");
            animator.SetBool("isCrouched", true);
            _playerMovement.enabled = false;
            
        }
        if (!Input.GetKey("c"))
        {
            Debug.Log("Whew. Close one");
            animator.SetBool("isCrouched", false);
            _playerMovement.enabled = true;
        }
    }
}
