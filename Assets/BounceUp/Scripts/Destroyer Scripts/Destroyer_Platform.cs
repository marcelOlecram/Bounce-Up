using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer_Platform : MonoBehaviour {
    // Unity Methods
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Platform"))
        {
            Destroy(other.gameObject);
        }
    }
}
