using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private float carSpeed;
    [SerializeField] private float rotationSpeed;

    private Rigidbody rb;
    private Vector3 initialPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        float rotationAmount = horizontalInput * rotationSpeed * Time.deltaTime;
        Quaternion rotation = Quaternion.Euler(0f, rotationAmount, 0f);
        rb.MoveRotation(rb.rotation * rotation);

        Vector3 moveVector = transform.forward * verticalInput * carSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + moveVector);

        CheckBounds();
    }

    private void CheckBounds()
    {
        if (transform.position.y < -5f)
        {
            transform.position = initialPosition;
        }
    }
}
