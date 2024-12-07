using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothSpeed = 10f;

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + target.forward * offset.z + target.up * offset.y;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime * 3);
        transform.position = smoothedPosition;

        transform.LookAt(target.position);
    }
}
