using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;

    private Vector3 targetPosition;

    private void Update()
    {
        float closeEnough = 0.01f;
        if (Vector3.Distance(targetPosition, transform.position) > closeEnough)
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Move(MouseWorld.GetPosition());
        }


    }

    private void Move(Vector3 pTargetPosition)
    {
        this.targetPosition = pTargetPosition;
    }
}
