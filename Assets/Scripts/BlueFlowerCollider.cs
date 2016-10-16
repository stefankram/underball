using UnityEngine;
using System.Collections;

public class BlueFlowerCollider : MonoBehaviour
{
    public GameObject flower;

    private bool collided;
    private Vector3 start;
    private Vector3 end;
    private float percent;
    private float flowerY;
    private BoxCollider _boxCollider;

    void Start()
    {
        collided = false;
        start = new Vector3(0.0f, 0.0f, 0.0f);
        end = new Vector3(0.0f, 0.4f, 0.0f);
        percent = 2;
        flowerY = flower.transform.position.y;
        _boxCollider = GetComponent<BoxCollider>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !collided)
        {
            Physics.IgnoreCollision(_boxCollider, other);
            collided = true;
        }
    }

    void Update()
    {
        if (collided && flower.transform.position.y <= flowerY + 0.4f)
        {
            flower.transform.position += Vector3.Lerp(start, end, percent) * Time.deltaTime * 4;
        }
    }
}
