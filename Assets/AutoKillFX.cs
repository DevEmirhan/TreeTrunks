using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoKillFX : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, GetComponent<ParticleSystem>().main.duration);
        Debug.Log("yea yea");
    }

    // Update is called once per frame

}
