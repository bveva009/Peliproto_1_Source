using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speeeen : MonoBehaviour
{

    public float RotateSpeed = 10f;

    void Update()
    {
        transform.Rotate(Vector3.up * RotateSpeed * Time.deltaTime);
    }
}
