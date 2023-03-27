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

        gravity = 0;

        if (FindObjectOfType<PanelManager>().isPlay == true)
        {
            groundLevel = 0f;
        }

    }

    void Update()
    {
        if (FindObjectOfType<PanelManager>().isPlay == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                transform.DOMove(transform.position + Vector3.up + Vector3.forward * moveSpeed, 0.4f);

                //Rotation
                transform.DORotate(new Vector3(360, 0, 0), 0.4f, RotateMode.WorldAxisAdd);

                velocity = Vector3.zero;
                gravity = -9.81f;
            }
            else
            {

                if (transform.position.y > groundLevel)
                {
                    if (transform.position.y > groundLevel && transform.position.y <= groundLevel + 0.1f)
                    {
                        // Karakter x2 tagli objeye dokundu�unda h�z�n� s�f�rlayarak d��me hareketini durdur
                        velocity = Vector3.zero;
                    }
                    else
                    {
                        velocity.y += gravity * fallSpeed * Time.deltaTime;
                    }

                  

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "x2")
        {
            Debug.Log("De�di x2");
            // x2 tagine sahip objeye �arp�ld�
            moveSpeed = 0; // karakterin ileri hareketini durdur
            FindObjectOfType<PanelManager>().isPlay = false;
            gravity = 0; // karakterin d���� h�z�n� s�f�rla
        }
        else if (other.gameObject.tag == "x3")
        {
            Debug.Log("De�di x3");
            moveSpeed = 0;
            FindObjectOfType<PanelManager>().isPlay = false;
            gravity = 0;
        }
        else if (other.gameObject.tag == "x4")
        {
            Debug.Log("De�di x4");
            moveSpeed = 0;
            FindObjectOfType<PanelManager>().isPlay = false;
            gravity = 0;
        }
        else if (other.gameObject.tag == "x6")
        {
            Debug.Log("De�di x6");
            moveSpeed = 0;
            FindObjectOfType<PanelManager>().isPlay = false;
            gravity = 0;
        }
        else if (other.gameObject.tag == "x10")
        {
            Debug.Log("De�di x10");
            moveSpeed = 0;
            FindObjectOfType<PanelManager>().isPlay = false;
            gravity = 0;
        }
        else if (other.gameObject.tag == "x50")
        {
            Debug.Log("De�di x50");
            moveSpeed = 0;
            FindObjectOfType<PanelManager>().isPlay = false;
            gravity = 0;
        }
        else if (other.gameObject.tag == "x1")
        {
            Debug.Log("De�di x1");
            moveSpeed = 0;
            FindObjectOfType<PanelManager>().isPlay = false;
            gravity = 0;
        }
    }




}