using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScriptLevel2 : MonoBehaviour
{

    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player") && Key.KeyCount >= 3)
        {
            Key.KeyCount = 0;

            anim.SetBool("character_nearby", true);
            // collider.gameObject.SetActive(false);


            SceneManager.LoadScene("Level_3.1");

        }

    }
}
