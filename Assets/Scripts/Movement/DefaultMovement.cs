using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DefaultMovement : IMoveable
{
    private float movementSpeed = 5f;
    private float rotationSpeed = 180f;
    [Inject]
    private Rigidbody rigidbody;
    [Inject (Id ="movementTransform")]
    private Transform transform;

    public void Move(Vector3 direction)
    {
        UpdatePosition(direction);
    }

    public void RotateRight(float strength)
    {
        transform.RotateAround(transform.position, Vector3.up, strength * rotationSpeed * Time.deltaTime);
    }

    private void UpdatePosition(Vector3 direction)
    {
        Vector3 localDirection = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0) * direction;
        rigidbody.MovePosition(transform.position + localDirection * Time.fixedDeltaTime * movementSpeed);
    }
}
