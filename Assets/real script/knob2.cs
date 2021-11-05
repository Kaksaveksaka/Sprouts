using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knob2 : MonoBehaviour
{
    //public static string k;

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
        { knob._destroy = true; }
        else if (collision.gameObject != line.los)

        {

            knob.collided = true;
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);

            if (i <= 3)

            {
               // dot.tno++; // for dot
                dot.k = collision.transform.tag; // for dot
                dot.ii=1;
                knob.connected = true;
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
