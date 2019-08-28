using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroy : MonoBehaviour
{
    public GameObject platformDestructionPoint;
    public GameObject nama;
    // Start is called before the first frame update
    void Start()
    {
        platformDestructionPoint = GameObject.Find ("PlatformDestructionPoint");    
    }
    

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < platformDestructionPoint.transform.position.x)
        {
            //Destroy(gameObject);
            // if (gameObject.name=="MASTER") 
            //     gameObject.SetActive(false);
            // else
            //     Destroy(gameObject);

            gameObject.SetActive(false);
        }
    }

    
}
