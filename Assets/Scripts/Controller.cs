using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float Acceleration = 5f, MaxTurn = 45f, Deceleration = 5f, SharpDeceleration = 25f, RotationSmooth = 5f, CharMobility = 5f;
    public float gravity = -9.81f, JumpHeight = 3f;
    public Vector3 velocity;
    public CharacterController Control;
    public bool isGrounded;
    public Transform GroundCheck;
    public float GroundDistance = 0.4f;
    public LayerMask Ground;

    public float XBounds = 10f;
    public float ZBounds = 10f;

    GameController gameController;
    public GameObject Explosion;
    public AudioSource ExplosionSound;

    private void Awake()
    {
        gameController = GameObject.FindObjectOfType<GameController>();
        ExplosionSound = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        float keyHorizontal = Input.GetAxis("Horizontal") * MaxTurn;
        Quaternion totalRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0, keyHorizontal, 0), Time.deltaTime * RotationSmooth);
        transform.rotation = totalRotation;

        isGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, Ground);

        velocity.y += gravity * Time.deltaTime;
        velocity.y = Mathf.Clamp(velocity.y, -25f, 15f);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(JumpHeight * -2f * gravity);
        }
        if (isGrounded && velocity.y < 0f)
        {
            velocity.y = -1f;
        }

        velocity.x = transform.rotation.y * CharMobility;

        float keyVertical = Input.GetAxis("Vertical") * Acceleration;
        velocity.z = keyVertical;
        if (Input.GetButton("Fire1"))
        {
            velocity.z = -SharpDeceleration;
        }
        if (keyVertical == 0)
        {
            if (transform.position.z > 1)
            {
                velocity.z -= transform.position.z * Deceleration;
            }
            else if (transform.position.z < -1)
            {
                velocity.z -= transform.position.z * Deceleration;
            }
        }

        Control.Move(velocity * Time.deltaTime);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -XBounds, XBounds), transform.position.y, Mathf.Clamp(transform.position.z, -ZBounds, ZBounds));
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Window") && Input.GetButton("Fire1"))
        {
            Debug.Log("HULK SMASH");
            GameObject explosion = Instantiate(Explosion, other.transform.parent.position, Quaternion.identity);
            ExplosionSound.Play();
            Destroy(explosion, 3.9f);
            Destroy(other.transform.parent.gameObject);
            gameController.UpdateScore();
        }
    }
}
