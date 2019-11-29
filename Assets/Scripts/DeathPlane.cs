using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlane : MonoBehaviour
{
    GameController gameController;

    private void Awake()
    {
        gameController = GameObject.FindObjectOfType<GameController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        Debug.Log("Life Lost");
        gameController.UpdateLives();
    }
}
