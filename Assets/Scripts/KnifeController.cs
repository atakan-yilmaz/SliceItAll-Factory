using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeController : MonoBehaviour
{
    //[Header("Jump Forth")]
    //[SerializeField] private Vector3 _jumpForthForce;
    //[SerializeField] private Vector3 _spinForthTorque;
    //[Header("Jump Back")]
    //[SerializeField] private Vector3 _jumpBackForce;
    //[SerializeField] private Vector3 _spinBackTorque;

    //private Rigidbody _rigidbody;

    //private void Awake()
    //{
    //    _rigidbody = GetComponent<Rigidbody>();
    //}

    //private void OnEnable()
    //{
    //    InputController.OnTap += OnTapHandler;
    //}

    //private void OnDisable()
    //{
    //    InputController.OnTap -= OnTapHandler;
    //}

    //private void FixedUpdate()
    //{
    //    _rigidbody.inertiaTensorRotation = Quaternion.identity;
    //}

    //public void JumpBack()
    //{
    //    Jump(-1);
    //    Spin(-1);
    //}

    //private void OnTapHandler()
    //{
    //    _rigidbody.isKinematic = false;
    //    Jump();
    //    Spin();
    //}

    //private void Jump(int direction = 1)
    //{
    //    Vector3 jumpForce = direction == 1 ? _jumpForthForce : _jumpBackForce;

    //    _rigidbody.velocity = Vector3.zero;
    //    _rigidbody.AddForce(jumpForce, ForceMode.Impulse);
    //}

    //private void Spin(int direction = 1)
    //{
    //    Vector3 spinTorque = direction == 1 ? _spinForthTorque : _spinBackTorque;

    //    _rigidbody.angularVelocity = Vector3.zero;
    //    _rigidbody.AddTorque(spinTorque, ForceMode.Acceleration);
    //}

    ///////////////////////////////////////////////////////////////////////////////////////
    ///

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
            // high
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            // Mouse angle
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 targetDir = hit.point - transform.position;
                targetDir.y = 0f; // y ekseni etrafýnda dönmemesi için sýfýrla
                Quaternion targetRotation = Quaternion.LookRotation(targetDir);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }

    void FixedUpdate()
    {
        // Knife forward moving
        Vector3 moveDirection = transform.forward * moveSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + moveDirection);
    }
}