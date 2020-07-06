using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    //public GameObject treePrefab;
    //public int treeLength = 8;
    public bool isPoppedUp = false;
    private Animator treeAnimator;
    public ParticleSystem poppingOut,trunkDestroy;
    

    void Start()
    {
        treeAnimator = gameObject.GetComponent<Animator>();
        // TREE GENERATOR IF THERE IS A NECESSARY
        //for (int i = 0; i < treeLength; i++)
        //{
        //    Instantiate(treePrefab, new Vector3( 0f, i * 1.8f, 0f), Quaternion.Euler(0f,15f*i,0f));
        //}
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


}
