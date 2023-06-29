using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 300;
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float slowSpeed = 10f;
    [SerializeField] float normalSpeed = 20f;
    [SerializeField] float fastSpeed = 30f;
    void Start()
    {
        
    }
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0,0,-steerAmount);
        transform.Translate(0,moveAmount,0);
    }
    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Driver trigger enter");
        if (other.tag == "SpeedUp"){
            Debug.Log("Speed Up!");
            moveSpeed = fastSpeed;
            
        } else if (other.tag == "SlowDown"){
            Debug.Log("Slow Down!");
            moveSpeed = slowSpeed;
        }
    }
    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Ouch! Return to normal speed!");
        moveSpeed = normalSpeed;
    }
}
