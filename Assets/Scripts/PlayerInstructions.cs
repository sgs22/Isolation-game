using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstructions : MonoBehaviour
{
    public GameObject Instructions;

    // Start is called before the first frame update
    void Start()
    {
        Instructions.SetActive(true);
    }

     //Update is called once per frame
    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            Instructions.SetActive(true);
            StartCoroutine("Wait");
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(6);
     
        Instructions.SetActive(false);
        Destroy(gameObject);

    }


}
