using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BInstructions : MonoBehaviour
{
    public GameObject  BatteryInstructions;

    // Start is called before the first frame update
    void Start()
    {
        BatteryInstructions.SetActive(false);
    }

    //Update is called once per frame
    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            BatteryInstructions.SetActive(true);
            StartCoroutine("Wait");
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
        BatteryInstructions.SetActive(false);
        Destroy(gameObject);

    }


}
