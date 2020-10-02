using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class pick_drop : MonoBehaviour {
    public Transform dest,player,cam;
    public float range = 10f;
    public Rigidbody rb;
    public Collider coll;

    public float dropUpwordforce, dropforwardforce;

    public bool eqipped;
    public static bool full;

    RaycastHit hit;

    public Text txt;
    GameObject currentitem;

    // Update is called once per frame

    private void Start()
    {
        if (!eqipped)
        {
            rb.isKinematic = false;
            coll.isTrigger = false;
        }

        if (eqipped)
        {
            rb.isKinematic = true;
            coll.isTrigger = true;
            full = true;
        }
    }


    void Update()
    {
        if (!eqipped && Input.GetKeyDown(KeyCode.E) && !full)
        {
            pickup();
        }

        if (eqipped && Input.GetKeyDown(KeyCode.R))
        {
            drop();
        }
    }

    private void pickup()
    {
  
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            if (hit.transform.tag == "cangrab")
            {
                eqipped = true;
                full = true;
                currentitem = hit.transform.gameObject;

                hit.transform.GetComponent<Rigidbody>().isKinematic = true;
                hit.transform.GetComponent<Collider>().isTrigger = true;

                hit.transform.SetParent(dest);
                hit.transform.position = dest.position;
                StartCoroutine(Type(currentitem.name));
                
            }
        }
    }
    
    private void drop()
    {
        eqipped = false;
        full = false;

        currentitem.transform.GetComponent<Rigidbody>().isKinematic = false;
        currentitem.transform.GetComponent<Collider>().isTrigger = false;

        currentitem.transform.SetParent(null);

        currentitem.transform.GetComponent<Rigidbody>().AddForce(cam.forward * dropforwardforce, ForceMode.Impulse);
        currentitem.transform.GetComponent<Rigidbody>().AddForce(cam.up * dropUpwordforce, ForceMode.Impulse);

        currentitem = null;
    }

    IEnumerator Type(string sentence)
    { 
        txt.text = "";
        foreach (char letter in sentence)
        {
            txt.text += letter;
            yield return null;
        }
        yield return new WaitForSeconds(1f);

        txt.text = "";
    }
    }

