using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : Singleton<CameraController>
{
   
    public GameObject sawPrefab;
    public float throwForce = 40f;
    public float speed = 2f;
    private float normalSpeed;
    public bool canShoot = false;
    public bool treeCollapsed = false;
    public bool isAnimateOver = false;
    private int currentTreeNumber;
    public List<Transform> CameraPositions;
    public List<Tree> TreesOnLevel;


    private void Start()
    {
        normalSpeed = speed;   
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot && !treeCollapsed)
        {
            ThrowSaw();
        }
        

        if (GameManager.Instance.gameState == GameState.Play && !isAnimateOver)
        {
            if (treeCollapsed)
            {
                if(currentTreeNumber < TreesOnLevel.Count)
                {
                    currentTreeNumber++;
                }
                
                treeCollapsed = false;
            }
            if(currentTreeNumber != TreesOnLevel.Count)
            {
                if(Vector3.Distance(transform.position, CameraPositions[currentTreeNumber].position) >= 5)
                {
                    speed = normalSpeed * 2.5f;
                }
                else 
                {
                    speed = normalSpeed;
                }
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, CameraPositions[currentTreeNumber].position, step);
                TreesOnLevel[currentTreeNumber].PoppedUpTree();
                if (Vector3.Distance(transform.position, CameraPositions[currentTreeNumber].position) < 0.001)
                {
                    canShoot = true;
                    isAnimateOver = true;
                }
            }
            else
            {
                canShoot = false; ;
                GameManager.Instance.gameState = GameState.Win;
                
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
