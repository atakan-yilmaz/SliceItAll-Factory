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

    public float gravity = -9.81f; // yer çekimi kuvveti
    public float fallSpeed = 1f; // düþüþ hýzý
    public float damping = 0.5f; // kamera damping deðeri

    private Vector3 velocity; // düþüþ hýzýný tutacak deðiþken

    private float groundLevel; // objenin yere olan mesafesini hesaplamak için
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
                // yerçekimi kuvvetinin etkisi altýnda objeyi hareket ettir
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