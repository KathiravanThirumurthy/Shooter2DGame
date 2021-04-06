using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        // to get the position
        //
        Debug.Log(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(xInput , yInput , 0);
        transform.Translate(direction * _speed * Time.deltaTime);
        if(transform.position.y >= 0)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }else if(transform.position.y <= -3.9)
        {
            transform.position = new Vector3(transform.position.x, -3.9f, transform.position.z);
        }

        if(transform.position.x >= 10.0)
        {
            transform.position = new Vector3(-10.0f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x <= -10.0)
        {
            transform.position = new Vector3(10.0f, transform.position.y, transform.position.z);
        }
    }
}
