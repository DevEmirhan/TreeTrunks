using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawDestroy : MonoBehaviour
{
    public GameObject sawFx;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Tree")
        {
            Instantiate(sawFx, transform.position, transform.rotation);
            
            Destroy(gameObject);
           
            
            
        }
    }

}

