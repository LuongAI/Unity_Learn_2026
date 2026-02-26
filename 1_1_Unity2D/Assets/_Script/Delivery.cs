using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage = false;
    [SerializeField] float destroyDelay = 0.01f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Ối Dồi Ôi! Tôi đã đâm vào: " + collision.gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Package") && !hasPackage)
        {
            Debug.Log("Pickup package: " + collision.gameObject.name);
            hasPackage = true;
            GetComponent<ParticleSystem>().Play();
            Destroy(collision.gameObject, destroyDelay);
        }
        

        if (collision.CompareTag("Customer") && hasPackage)
        {
            Debug.Log("Deliveried Package : " + collision.gameObject.name);
            GetComponent<ParticleSystem>().Stop();
            hasPackage = false;
            Destroy(collision.gameObject, destroyDelay);
        }
           
    }
}
