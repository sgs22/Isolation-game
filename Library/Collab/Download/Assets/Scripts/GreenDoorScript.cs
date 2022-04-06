using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GreenDoorScript : MonoBehaviour
{

    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))

        {
            

            anim.SetBool("character_nearby", true);
            // collider.gameObject.SetActive(false);


            SceneManager.LoadScene("LevelGreen");


        }

    }
}
