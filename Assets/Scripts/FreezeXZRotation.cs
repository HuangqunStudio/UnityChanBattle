using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeXZRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    void LateUpdate()
    {
        transform.rotation = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);
    }
}
