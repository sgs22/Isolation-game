using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour
{

    void Update()
    {
        transform.Rotate(new Vector2(15, 0) * Time.deltaTime);
    }
}