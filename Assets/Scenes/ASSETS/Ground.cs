using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public float _speed;
    public float _start;
    public float _end;  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = new Vector2(transform.position.x - _speed * Time.deltaTime, transform.position.y);
        if(transform.position.x <= _end)
        {
            if (gameObject.CompareTag("Obstacle"))
            {
                Destroy(gameObject);
            }
            else
            {
                transform.position = new Vector2(_start, transform.position.y);
            }
            
        }
    }
}
