using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;

    GameObject currentFloor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(moveSpeed*Time.deltaTime, 0, 0);
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(-moveSpeed*Time.deltaTime, 0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Normal")
        {
            Debug.Log(other.contacts[0].normal);
            Debug.Log(other.contacts[1].normal);
            Debug.Log("撞到第一種階梯");
            currentFloor = other.gameObject;
        }else if(other.gameObject.tag == "Nails")
        {
            Debug.Log(other.contacts[0].normal);
            Debug.Log(other.contacts[1].normal);
            Debug.Log("撞到第二種階梯");
            currentFloor = other.gameObject;
        }
        else if(other.gameObject.tag == "Ceiling")
        {
            Debug.Log("撞到天花板");
            currentFloor.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "DeathLine")
        {
            Debug.Log("你輸了");
        }
    }
}
