using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class KnifeController : MonoBehaviour
{
    public float moveSpeed = 5f;  
    public float jumpForce = 5f;
    public float smoothFactor = 1.0f;

    private Rigidbody rb;

    public float gravity = -9.81f; // yer �ekimi kuvveti
    public float fallSpeed = 1f; // d���� h�z�
    public float damping = 0.5f; // kamera damping de�eri

    private Vector3 velocity; // d���� h�z�n� tutacak de�i�ken

    private float groundLevel; // objenin yere olan mesafesini hesaplamak i�in
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        groundLevel = transform.position.y;
        
        

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            transform.DOMove(transform.position + Vector3.up + Vector3.forward*moveSpeed, 0.4f);

            //Rotation
            transform.DORotate(new Vector3(360, 0, 0), 0.8f, RotateMode.WorldAxisAdd);

            velocity = Vector3.zero;
        }
        else
        {
            

            if (transform.position.y > groundLevel)
            {
                // yer�ekimi kuvvetinin etkisi alt�nda objeyi hareket ettir
                velocity.y += gravity * fallSpeed * Time.deltaTime;

                //gravitational force
                transform.position += velocity;

                // update camera position
                Vector3 cameraPosition = Camera.main.transform.position;
                cameraPosition.y = transform.position.y + damping;
                Camera.main.transform.position = cameraPosition;
            }
        }

    }
   


   
}