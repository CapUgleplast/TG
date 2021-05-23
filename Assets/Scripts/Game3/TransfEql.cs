using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransfEql : MonoBehaviour
{
    public Transform objectlead;
    public Transform objectfollower;
    public bool xtrans = false;
    public bool ytrans = false;
    public bool ztrans = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(xtrans == true)
        {
            objectfollower.position = new Vector3(objectlead.position.x, objectfollower.position.y, objectfollower.position.z) ;
        }
        if (ytrans == true)
        {
            objectfollower.position = new Vector3(objectfollower.position.x, objectlead.position.y, objectfollower.position.z);
        }
        if (ztrans == true)
        {
            objectfollower.position = new Vector3(objectfollower.position.x, objectfollower.position.y, objectlead.position.z);
        }
    }
}
