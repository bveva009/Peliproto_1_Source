using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float movespeed = 10f;

    void Update()
    {
        transform.Translate(Vector3.forward * movespeed * Time.deltaTime);
    }
}
