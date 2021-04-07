using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movingEnemy();
    }
    private void movingEnemy()
    {
        transform.Translate(Vector3.down * _speed*Time.deltaTime);
        if(transform.position.y <= -5.5)
        {
            transform.position = new Vector3(Random.Range(-9.5f,9.5f),7.0f,0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if enemy hits player
        //damage player
        // destroy us
        if (other.tag == "Player")
        {



            // damage Player -lives system
            PlayerMovement player = other.transform.GetComponent<PlayerMovement>();
            if (player != null)
            {

                player.damagePlayer();

            }
            Destroy(this.gameObject);
        }
        // if other is laser
        // destroy laser
        // Destroy us
        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);

        }
    }

}
