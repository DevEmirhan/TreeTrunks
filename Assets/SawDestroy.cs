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
        //IF Tree; just break the saw;
        if(collision.gameObject.tag == "Tree")
        {
            Instantiate(sawFx, transform.position, transform.rotation);
            Destroy(gameObject);
            
        }
        //IF Finish; Make the Camera Controller passes to Winning Sequence;
        if(collision.gameObject.tag == "Finish")
        {
            Instantiate(sawFx, transform.position, transform.rotation);
            CameraController.Instance.canShoot = false;
            CameraController.Instance.treeCollapsed = true;
            CameraController.Instance.isAnimateOver = false; 
            Destroy(gameObject);
        }
    }
}
            
            


           

