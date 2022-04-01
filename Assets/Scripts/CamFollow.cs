using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        base.transform.position = new Vector3(target.position.x, target.position.y, base.transform.position.z);    
    }
}
