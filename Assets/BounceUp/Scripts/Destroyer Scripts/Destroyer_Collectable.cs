using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer_Collectable : MonoBehaviour
{
    // UnityMethods
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            Destroy(other.gameObject);
        }
    }
}
