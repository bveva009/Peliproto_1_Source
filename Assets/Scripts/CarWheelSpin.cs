using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarWheelSpin : MonoBehaviour
{

    public float RotateSpeed = -360f;

    void Update()
    {
        transform.Rotate(Vector3.right * RotateSpeed * Time.deltaTime);
    }
}
