using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    // Start is called before the first frame update

    public int respawnTime = 10;

    private void OnCollisionEnter()
    {
        this.GetComponent<CapsuleCollider>().enabled = false;
        this.GetComponent<MeshRenderer>().enabled = false;

        Invoke("RespawnItem", respawnTime);
    }

    void RespawnItem()
    {
        this.GetComponent<CapsuleCollider>().enabled = true;
        this.GetComponent<MeshRenderer>().enabled = true;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
