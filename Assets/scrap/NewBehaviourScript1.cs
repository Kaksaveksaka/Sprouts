using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript1 : MonoBehaviour
   
{
    public GameObject red;
    public GameObject blue;
    // Start is called before the first frame update
    void Start()
    {
        red.GetComponent<FixedJoint2D>().autoConfigureConnectedAnchor = false;
        red.GetComponent<FixedJoint2D>().connectedBody = blue.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
