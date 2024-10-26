using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float speed = 5.0f;
    private Rigidbody playerRb;
    private float zBoundTop = 6;
    private float zBoundBottom = -4.5f;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ConstrainPlayer();
    }

    // Move player based on arrow key input
    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRb.AddForce(Vector3.right * speed * horizontalInput);
        playerRb.AddForce(Vector3.forward * speed * verticalInput);

    }

    // Contrain player movement at the top and bottom
    void ConstrainPlayer()
    {
        if (transform.position.z > zBoundTop)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBoundTop);
        }

        if (transform.position.z < zBoundBottom)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBoundBottom);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Collided with enemy");
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Powerup"))
        {
            Debug.Log("Collided with Powerup");
        }
    }
}
