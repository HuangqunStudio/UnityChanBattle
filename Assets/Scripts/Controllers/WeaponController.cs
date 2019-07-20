using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;

public class WeaponController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyController script = other.GetComponentInParent<EnemyController>();

        if (script) {
            script.OnDamaged();
            GetComponent<CapsuleCollider>().enabled = false;
        }
    }
}
