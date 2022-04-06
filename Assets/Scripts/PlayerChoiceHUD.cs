using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerChoiceHUD : MonoBehaviour
{
    public GameObject PlayerHUD;
    public Button Button;
    public GameObject Player;
    public GameObject MainCamera;
    // Start is called before the first frame update
    void Start()
    {
        PlayerHUD.SetActive(false);
        //Button.SetActive(false);
    }

    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            PlayerHUD.SetActive(true);
            Button.enabled = true;

            Player.GetComponent<Camera_Control>().enabled = false;
            MainCamera.GetComponent<Camera_Control>().enabled = false;
            Player.GetComponent<characterController>().enabled = false;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            //StartCoroutine("Wait");

        }
       
    }
    /*IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
        PlayerHUD.SetActive(false);
        Destroy(gameObject);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Player.GetComponent<Camera_Control>().enabled = true;
        MainCamera.GetComponent<Camera_Control>().enabled = true;
        Player.GetComponent<characterController>().enabled = true;

    }*/

   public void RidHUD()
    {
        PlayerHUD.SetActive(false);
        Button.enabled = false;
        Destroy(gameObject);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Player.GetComponent<Camera_Control>().enabled = true;
        MainCamera.GetComponent<Camera_Control>().enabled = true;
        Player.GetComponent<characterController>().enabled = true;
    }



}

