using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public GameObject Knife;
    Vector3 distance;

    private void Start()
    {
        distance = transform.position - Knife.transform.position;
    }

    private void Update()
    {
        transform.position = Knife.transform.position + distance;
    }
}