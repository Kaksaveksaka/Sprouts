using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knob : MonoBehaviour
{
    //public static string k;
    public static bool connected = false,collided = false,_destroy=false, connected2=false;
    int i = 1;
   
    [HideInInspector]

    public static GameObject jor;
    // Start is called before the first frame update
    void Start()
    {
        jor = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Fire1"))
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
    
        Debug.Log("col");
        if (i > 3)
        { _destroy = true; }
        else if (collision.gameObject != line.los)
            
        {
           
            collided = true;
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
         
            if (i <= 3)

            {
                
                //k = collision.transform.tag; // for dot

                connected = true;
              //  connected2 = true; // for dot

            }
            
       }
        
        i++;
    }
    private void OnCollisionExit2D(Collision2D kh)
    {
      
        i--;
    }
}
