using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dot : MonoBehaviour
{ public static int tno=1;     
    string ta;
   public static int ii=1;
    int job; 
    public static GameObject re;
    LayerMask lr;
    public LayerMask layerMask;
    private Vector3 worldPosition;
    bool del = false;
    public static bool onre=false;
    public GameObject _knob;
    public GameObject _kno;
    public static string k;
    private void Awake()
    {    
         ta = tno.ToString();   
    }
    // Start is called before the first frame update
    void Start()
    {
        _kno = this.gameObject;
        this.gameObject.transform.tag = "tag"+ta;
        
       
    }

    // Update is called once per frame
    void Update()
    {
       
        if (k == "tag" + ta)
        {

            del = true;
        }
        if (Input.GetButtonDown("Fire1")&&onre==true&& this.gameObject.transform.tag == re.transform.tag)
        { 
            re.transform.GetChild(2).gameObject.SetActive(false);
            


          
        }
        if (Input.GetButtonUp("Fire1") && onre == true&& this.gameObject.transform.tag == re.transform.tag)
        {
            Debug.Log("hmi");
            if (knob.connected)
            {
                Debug.Log("vchffb");
                onre = false;
                 k = re.transform.tag;
                knob.connected = false;
                tno++;
            }
            else
                re.transform.GetChild(2).gameObject.SetActive(true);

        }
        /*if (del==false)
        {
            
            worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hitData = Physics2D.Raycast(new Vector2(worldPosition.x, worldPosition.y), Vector2.zero, 0, layerMask);
           // float distance = Vector3.Distance(new Vector3(this.transform.position.x, this.transform.position.y, 0), new Vector3(worldPosition.x, worldPosition.y, 0));

            if (hitData && Input.GetButton("Fire2"))
            {
                worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                worldPosition.z = Camera.main.nearClipPlane;
                if(ii==1)
                Instantiate(_knob, worldPosition, this.transform.rotation);
                ii++;
            }
        }*/
        if (del==false)
        {
            
            if(Input.GetButtonDown("Fire2")) 
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

                RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero,lr);
                if (hit.collider != null)
                {
                    Debug.Log(hit.collider.gameObject.name);
                    re = hit.collider.gameObject;
                    if ("tag" + ta == re.transform.tag)
                    {
                        hit.collider.gameObject.transform.GetChild(2).gameObject.SetActive(true);
                        hit.collider.gameObject.transform.GetChild(1).gameObject.SetActive(false);

                        onre = true;
                    }
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
{
        bool kg = true;
        if (collision.gameObject.tag == "knob" || collision.gameObject.tag == this.gameObject.tag || this.transform.GetComponent<Rigidbody2D>().bodyType == RigidbodyType2D.Kinematic)
        { kg = false;
            Debug.Log(job);
            if (del)
            {
                knob._destroy = true;

            }
        }
        if(kg)
        {
            Debug.Log(job);
            if (del)
            { knob._destroy = true;
                
            }



            else if (collision.gameObject != line.los)
            { this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                knob.collided = true;


            

                
                   
                    k = collision.transform.tag; // for dot
                    knob.connected = true;




                
                
            }
            else
                    k = collision.transform.tag; // for dot

           // ii++;

        }
       
    }
private void OnCollisionExit2D(Collision2D kh)
{
   // ii--;
}
}
