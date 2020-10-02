using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour {
    public Transform cam,dest;

    public float range = 10f;

    public Animator anim;

	
	// Update is called once per frame
	void Update () {
        if (transform.parent == dest && Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if(Physics.Raycast(cam.position,cam.forward,out hit, range))
            {
                if(hit.transform.name == "door_store")
                {
                    Destroy(gameObject);
                    FindObjectOfType<door>().alreadyOpened = true;
                    Open();

                }
            }
        }
	}

    public void Open()
    {
        if (anim.GetBool("lol2") == true)
        {
            anim.SetBool("lol2", false);
        }
        else
        {
            anim.SetBool("lol2", true);
        }
    }
}
