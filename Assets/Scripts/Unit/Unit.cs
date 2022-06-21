using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private Animator animator;
    [SerializeField] private float rotationSpeed = 10f;

    private Vector3 targetPosition;

    private void Awake()
    {
        targetPosition = transform.position;
    }

    private void Update()
    {
        float closeEnough = 0.01f;
        if (Vector3.Distance(targetPosition, transform.position) > closeEnough)
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
            // to make the player face the direction could also use Quarterion or eulerAngles
            //transform.forward = Vector3.Lerp(transform.position, moveDirection, Time.deltaTime * rotationSpeed);

            Quaternion rotation = Quaternion.LookRotation(moveDirection);
            Quaternion current = transform.localRotation;
            transform.localRotation = Quaternion.Slerp(current, rotation, Time.deltaTime * rotationSpeed);

            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }

    public void Move(Vector3 pTargetPosition)
    {
        this.targetPosition = pTargetPosition;
    }
}
