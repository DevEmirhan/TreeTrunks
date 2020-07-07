using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    //For Tree Generator
    //public GameObject treePrefab;
    //public int treeLength = 8;
    //private List<GameObject> trunks;

    public bool isPoppedUp = false;
    private Animator treeAnimator;
    public Animator CollapseFlash;
    public ParticleSystem poppingOut,trunkDestroy;
    public float reduceAmmount = 2f;
    

    void Start()
    {
        treeAnimator = gameObject.GetComponent<Animator>();

        //TREE GENERATOR IF THERE IS A NECESSARY
        //for (int i = 0; i < treeLength; i++)
        //{
        //    GameObject tmp = Instantiate(treePrefab, new Vector3(transform.position.x, transform.position.y + i * 1.8f, transform.position.z)
        //        , Quaternion.Euler(0f, 15f * i, 0f));
        //    trunks.Add(tmp);

        //}
        //float tall = trunks[treeLength].transform.position.y - trunks[0].transform.position.y;
        //gameObject.transform.position = new Vector3(transform.position.x, transform.position.y - tall, transform.position.z);

    }

    
    void Update()
    {
        
    }
    public void PoppedUpTree()
    {
        treeAnimator.SetTrigger("Pop");
        poppingOut.Play();
        isPoppedUp = true;

    }
    public void DestroyOneTrunk()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            treeAnimator.enabled = false;
            transform.position = new Vector3(transform.position.x, transform.position.y - reduceAmmount, transform.position.z);
            CollapseFlash.SetTrigger("Collapse");
            trunkDestroy.Play();
            Debug.Log("Collapsed");
        }
    }

}
