//
// Created by Stefan Kramreither
// 250747762
// skramrei@uwo.ca
//

using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private int lives = 3;

    public GameObject firstDoor;
    private bool collidedFirstDoor = false;
    private Vector3 startFirstDoor = new Vector3(0.0f, 0.0f, 0.0f);
    private Vector3 endFirstDoor = new Vector3(0.0f, -4.0f, 0.0f);
    private float percentFirstDoor = 1;

    public GameObject secondDoor;
    private bool collidedSecondDoor = false;
    private Vector3 startSecondDoor = new Vector3(0.0f, 0.0f, 0.0f);
    private Vector3 endSecondDoor = new Vector3(0.0f, -6.0f, 0.0f);
    private float percentSecondDoor = 1;

    private float _maxSpeed = 7.0f;
    private Rigidbody _rigidbody;

    private int yellowFlowerCount = 0;
    private int blueFlowerCount = 0;
    private int pinkFlowerCount = 0;

    void Start ()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate ()
    {
        Vector3 movement = new Vector3(
            -(Input.mousePosition.x - Screen.width / 2),
            0.0f,
            -(Input.mousePosition.y - Screen.height / 2));

        if (_rigidbody.velocity.magnitude > _maxSpeed)
        {
            _rigidbody.velocity = _rigidbody.velocity.normalized * _maxSpeed;
        }

        _rigidbody.AddForce(movement * speed * Time.deltaTime);
    }

    void Update()
    {
        if (collidedFirstDoor && firstDoor.transform.position.y >= -4.0f)
        {
            firstDoor.transform.position += Vector3.Lerp(startFirstDoor, endFirstDoor, percentFirstDoor) *
                                            Time.deltaTime * 0.5f;
        }
        if (collidedSecondDoor && secondDoor.transform.position.y >= -6.0f)
        {
            secondDoor.transform.position += Vector3.Lerp(startSecondDoor, endSecondDoor, percentSecondDoor) *
                                             Time.deltaTime * 0.5f;
        }
        if(Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Yellow Flower"))
        {
            yellowFlowerCount++;
        }
        if (other.gameObject.CompareTag("Blue Flower"))
        {
            blueFlowerCount++;
        }
        if (other.gameObject.CompareTag("Pink Flower"))
        {
            pinkFlowerCount++;
        }
        if (other.gameObject.CompareTag("First Door") &&
                yellowFlowerCount == 18 &&
                blueFlowerCount == 10 &&
                pinkFlowerCount == 10)
        {
            collidedFirstDoor = true;
        }
        if (other.gameObject.CompareTag("Second Door") &&
            yellowFlowerCount == 28 &&
            blueFlowerCount == 20)
        {
            Debug.Log("here");
            collidedSecondDoor = true;
        }
        if (other.gameObject.CompareTag("Crystal"))
        {
            lives++;
            Debug.Log(lives);
        }
    }
}
