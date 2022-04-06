using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTrigger: MonoBehaviour
{
    public GameObject KeyInstructions;

    // Start is called before the first frame update
    void Start()
    {
        KeyInstructions.SetActive(false);
    }

    //Update is called once per frame
    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            KeyInstructions.SetActive(true);
            StartCoroutine("Wait");
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
        KeyInstructions.SetActive(false);
        Destroy(gameObject);

    }


}
