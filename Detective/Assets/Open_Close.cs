using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_Close : MonoBehaviour {
    public float range = 10f;
    public Animator anim;
	
	// Update is called once per frame
	void Update () {

        
    }

    void OnMouseDown()
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
