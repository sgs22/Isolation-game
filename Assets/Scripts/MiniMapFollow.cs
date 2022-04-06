using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapFollow : MonoBehaviour
{
    public Transform Target;
    // Start is called before the first frame update
    void Update()

    {
        transform.position = new Vector3(Target.position.x, Target.position.y, Target.position.z);
    }

   
}
