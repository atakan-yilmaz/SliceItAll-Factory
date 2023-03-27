using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public Transform target; // Takip edilecek hedef
    public float smoothSpeed = 0.125f; // Hedef takibi i�in p�r�zs�zle�tirme de�eri
    public Vector3 offset; // Kameran�n hedefe g�re konumu

    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset; // Hedefin konumuna offset de�eri eklenir
        desiredPosition.y = transform.position.y; // Kameran�n y pozisyonu, ba�lang��ta belirtilen y pozisyonunda sabit kal�r
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // Kameran�n konumunu p�r�zs�z bir �ekilde g�ncellemek i�in Lerp fonksiyonu kullan�l�r
        transform.position = smoothedPosition; // Kameran�n konumu g�ncellenir
    }



    //public GameObject Knife;
    //Vector3 distance;

    //private void Start()
    //{
    //    distance = transform.position - Knife.transform.position;
    //}

    //private void Update()
    //{
    //    transform.position = Knife.transform.position + distance;
    //}
}