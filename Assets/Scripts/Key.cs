using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public static int KeyCount;
    public AudioClip KeyPickUp;
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Key"))
        {
            KeyCount += 1;
            collider.gameObject.SetActive(false);
            GetComponent<AudioSource>().PlayOneShot(KeyPickUp);
        }

    }
}
