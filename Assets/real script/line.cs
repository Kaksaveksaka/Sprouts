using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class line : MonoBehaviour
{
    public GameObject dot1;
    public GameObject ob;
    public LayerMask layerMask;
    bool change = true;
    public float MinimumDistance = 0.55f;
    public static float minimum;
    private Vector3 worldPosition;
    // int i=0;
    string tug;
    int rp = 0;
    GameObject mos;
    private GameObject dos;
    GameObject pos;
    public static GameObject los;
    // Vector3 kin = new Vector3(0, 0, 0);
    private void Start()
    {
        minimum = MinimumDistance;
        pos = ob;

        ob.GetComponent<DistanceJoint2D>().autoConfigureConnectedAnchor = false;

    }
    void Update()
    {
        worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit2D hitData = Physics2D.Raycast(new Vector2(worldPosition.x, worldPosition.y), Vector2.zero, 0, layerMask);

        float distance = Vector3.Distance(new Vector3(pos.transform.position.x, pos.transform.position.y, 0), new Vector3(worldPosition.x, worldPosition.y, 0));

        //  Debug.Log(distance);



        if (hitData && Input.GetButton("Fire1") && distance >= MinimumDistance)
        {
            worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPosition.z = Camera.main.nearClipPlane;

            spawnit();
        }

        else if (knob.connected == false && Input.GetButtonUp("Fire1") || knob._destroy == true)
        {
            Destroy(mos);
            pos = ob;
            rp = 0;
            knob._destroy = false;
          


        }
        else if (knob.collided == true)
        {
            DestroyImmediate(pos.transform.GetChild(0).gameObject);
            knob.collided = false;

            if (knob.connected == true)
            {
                // DestroyImmediate(pos.transform.GetChild(0).gameObject);
                pos.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;

                pos = ob;

                if (!dot.onre)
                { knob.connected = false;
                    dot.tno++;
                }
                mos = null;
                rp = 0;
                shift();
                
            }
        }


        
    }

    void spawnit()
    {
        dos = (GameObject)Instantiate(dot1, worldPosition, ob.transform.rotation);

        /*    i++;
            string n = i.ToString();
            tug = "hu"+n;*/
        Debug.Log(tug);

        dos.GetComponent<DistanceJoint2D>().connectedBody = pos.GetComponent<Rigidbody2D>();
        if (rp != 0)
        {
            pos.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            pos.transform.GetChild(0).gameObject.SetActive(false);
            dos.transform.parent = mos.transform;
            pos = dos;

        }
        else
        {



            mos = dos;
            // mos.transform.parent = knob.jor.transform;
            pos = dos;
            los = mos;
            Debug.Log("2");
            //  ob.transform.GetChild(0).gameObject.SetActive(false);
        }


        rp++;
        color();
    }
    void shift()
    { if (change == false)
        {
            change = true;
        }
        else if (change== true)
        {
            change = false;
        }
    }
    void color()
    { 
        if (change)
            pos.transform.GetChild(3).gameObject.SetActive(true);
        else
            pos.transform.GetChild(4).gameObject.SetActive(true);


    }
}