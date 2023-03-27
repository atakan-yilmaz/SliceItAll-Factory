using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
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

    private TextManager scoreManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        gravity = 0;

        if (FindObjectOfType<PanelManager>().isPlay == true)
        {
            groundLevel = 0f;
        }

        scoreManager = FindObjectOfType<TextManager>();
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

                Collider[] hitColliders = Physics.OverlapSphere(transform.position, 1f); //1f yerine baþka bir yarýçap deðeri de kullanýlabilir.
                
                foreach (Collider hitCollider in hitColliders)
                {
                    if (hitCollider.gameObject.CompareTag("x2"))
                    {
                        Debug.Log("Deðdi x2");
                        moveSpeed = 0; 
                        scoreManager.score *= 2;
                        gravity = 0;
                        FindObjectOfType<PanelManager>().isPlay = false;
                        FindObjectOfType<PanelManager>().finishPanel.SetActive(true);
                        break;
                    }
                    else if (hitCollider.gameObject.CompareTag("x3"))
                    {
                        Debug.Log("Deðdi x3");
                        moveSpeed = 0;
                        FindObjectOfType<PanelManager>().isPlay = false;
                        scoreManager.score *= 3;
                        gravity = 0;
                        FindObjectOfType<PanelManager>().finishPanel.SetActive(true);
                        break;
                    }
                    else if (hitCollider.gameObject.CompareTag("x4"))
                    {
                        Debug.Log("Deðdi x4");
                        moveSpeed = 0;
                        FindObjectOfType<PanelManager>().isPlay = false;
                        scoreManager.score *= 4;
                        gravity = 0;
                        FindObjectOfType<PanelManager>().finishPanel.SetActive(true);
                        break;
                    }
                    else if (hitCollider.gameObject.CompareTag("x6"))
                    {
                        Debug.Log("Deðdi x6");
                        moveSpeed = 0;
                        FindObjectOfType<PanelManager>().isPlay = false;
                        scoreManager.score *= 6;
                        gravity = 0;
                        FindObjectOfType<PanelManager>().finishPanel.SetActive(true);
                        break;
                    }
                    else if (hitCollider.gameObject.CompareTag("x10"))
                    {
                        Debug.Log("Deðdi x10");
                        moveSpeed = 0;
                        FindObjectOfType<PanelManager>().isPlay = false;
                        scoreManager.score *= 10;
                        gravity = 0;
                        FindObjectOfType<PanelManager>().finishPanel.SetActive(true);
                        break;
                    }
                    else if (hitCollider.gameObject.CompareTag("x50"))
                    {
                        Debug.Log("Deðdi x50");
                        moveSpeed = 0;
                        FindObjectOfType<PanelManager>().isPlay = false;
                        scoreManager.score *= 50;
                        gravity = 0;
                        FindObjectOfType<PanelManager>().finishPanel.SetActive(true);
                        break;
                    }
                    else if (hitCollider.gameObject.CompareTag("x1"))
                    {
                        Debug.Log("Deðdi x1");
                        moveSpeed = 0;
                        scoreManager.score *= 1;
                        FindObjectOfType<PanelManager>().isPlay = false;
                        gravity = 0;
                        FindObjectOfType<PanelManager>().finishPanel.SetActive(true);
                        break;
                    }
                }

            }
            else
            {

                if (transform.position.y > groundLevel)
                {
                    if (transform.position.y > groundLevel && transform.position.y <= groundLevel + 0.1f)
                    {
                        // Karakter x2 tagli objeye dokunduðunda hýzýný sýfýrlayarak düþme hareketini durdur
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
        if (other.gameObject.tag == "Floor")
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}






