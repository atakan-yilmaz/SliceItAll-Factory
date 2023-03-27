using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public Transform target; // Takip edilecek hedef
    public float smoothSpeed = 0.125f; // Hedef takibi için pürüzsüzleþtirme deðeri
    public Vector3 offset; // Kameranýn hedefe göre konumu

    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset; // Hedefin konumuna offset deðeri eklenir
        desiredPosition.y = transform.position.y; // Kameranýn y pozisyonu, baþlangýçta belirtilen y pozisyonunda sabit kalýr
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // Kameranýn konumunu pürüzsüz bir þekilde güncellemek için Lerp fonksiyonu kullanýlýr
        transform.position = smoothedPosition; // Kameranýn konumu güncellenir
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