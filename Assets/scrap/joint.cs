using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joint : MonoBehaviour
     
 
{

    private void OnCollisionEnter2D(Collision2D ion)
    {
if(ion.transform.tag=="Finish")
        { Debug.Log("boom");
        }
    }
}
