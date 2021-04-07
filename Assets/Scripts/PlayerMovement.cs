using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed = 6.0f;
    [SerializeField]
    private GameObject _laser;
    [SerializeField]
    private float fireRate = 0.2f;
    private float nextFire = 0.0f;
    
    private int _lives = 3;
    // Start is called before the first frame update
    void Start()
    {
        // to get the position
       
    }

    // Update is called once per frame
    void Update()
    {
       
        movementPlayer();
        shooting();
        
    }
    private void movementPlayer()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(xInput, yInput, 0);
        transform.Translate(direction * _speed * Time.deltaTime);
        if (transform.position.y >= 0)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
        else if (transform.position.y <= -3.9)
        {
            transform.position = new Vector3(transform.position.x, -3.9f, transform.position.z);
        }

        if (transform.position.x >= 10.0)
        {
            transform.position = new Vector3(-10.0f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x <= -10.0)
        {
            transform.position = new Vector3(10.0f, transform.position.y, transform.position.z);
        }
    }
    private void shooting()
    {
        if(Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(_laser,transform.position+new Vector3(0,0.5f,0),Quaternion.identity);
        }
    }

    public void damagePlayer()
    {
        Debug.Log("_lives before subtract: " + _lives);
        _lives--;
        Debug.Log("_lives after subtract: " + _lives);

        // check if dead
        // destroy us
        if (_lives < 1)
        {
            Destroy(this.gameObject);
        }

    }


}
