using UnityEngine;
using System.Collections;

public class EndCollider : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0.0f;
        }
    }
}
