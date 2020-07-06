using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
   
    public GameObject sawPrefab;
    public float throwForce = 40f;
    public float speed = 2f;
    public bool canShoot = false;
    public bool isGameStarted = false;
    public List<Transform> CameraPositions;
    public List<Tree> TreesOnLevel;


    private void Start()
    {

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            ThrowSaw();
        }

        if (GameManager.Instance.gameState == GameState.Play && !isGameStarted)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, CameraPositions[0].position, step);
            TreesOnLevel[0].PoppedUpTree();
            if(Vector3.Distance(transform.position , CameraPositions[0].position)< 0.001)
            {
                canShoot = true;
                isGameStarted = true;
            }
        }
                
        //if (CameraPositions[1] != null)
        //{
        //    float step = speed * Time.deltaTime;
        //    transform.position = Vector3.MoveTowards(transform.position, CameraPositions[1].position, step);
        //    if (Vector3.Distance(transform.position, CameraPositions[1].position) < 0.001)
        //    {
                
        //        canShoot = true;
        //    }
        //}
       
    }
  public void ThrowSaw()
    {
        GameObject saw = Instantiate(sawPrefab, new Vector3(transform.position.x, transform.position.y - 7f , transform.position.z), transform.rotation);
        Rigidbody rb = saw.GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0f,.1f,1f)* throwForce, ForceMode.VelocityChange);
        
    }  
 
}
