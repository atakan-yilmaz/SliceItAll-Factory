using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 50f;
    public float jumpForce = 5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //high
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            //Mouse angle
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 targetDir = hit.point - transform.position;
                targetDir.y = 0f; // y ekseni etrafýnda dönmemesi için sýfýrla
                targetDir.x = 0f; // x ekseni etrafýnda dönmemesi için sýfýrla
                Quaternion targetRotation = Quaternion.LookRotation(targetDir);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }

    void FixedUpdate()
    {
        // Knife forward moving
        Vector3 moveDirection = transform.forward * moveSpeed * Time.deltaTime;
        moveDirection.y = 0;
        rb.MovePosition(transform.position + moveDirection);
    }
}