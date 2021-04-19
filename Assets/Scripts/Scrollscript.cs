using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrollscript : MonoBehaviour
{
   /* [SerializeField]
    private float scrollSpeed = 0.1f;*/
    //Renderer rend;
    Material material;
    private Vector2 offset;
    [SerializeField]
    private float xVelocity, yVelocity;
    // Start is called before the first frame update
    void Awake()
    {
        material = GetComponent<Renderer>().material;
    }
    void Start()
    {
        // rend = GetComponent<Renderer>();
        offset = new Vector2(xVelocity, yVelocity);
    }

    // Update is called once per frame
    void Update()
    {
        /* float offset = Time.time * scrollSpeed;
         rend.material.SetTextureOffset("_MainTex", new Vector2(0,offset));*/
        material.mainTextureOffset -= offset * Time.deltaTime;
    }
}
