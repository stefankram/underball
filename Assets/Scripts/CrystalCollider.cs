using UnityEngine;
using System.Collections;

public class CrystalCollider : MonoBehaviour
{
    public GameObject crystal;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            crystal.SetActive(false);
        }
    }
}
