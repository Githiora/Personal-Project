using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float speed = 5.0f;
    private float zBoundary = -6.2f;
    private Rigidbody objectRb;

    // Start is called before the first frame update
    void Start()
    {
        objectRb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        objectRb.AddForce(Vector3.forward * -speed);

        if(objectRb.transform.position.z < zBoundary)
        {
            Destroy(gameObject);
        }

    }
}
