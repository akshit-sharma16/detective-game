using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class door : MonoBehaviour {

    public Transform key,dest,cam;
    public float range = 10f;

    public Text text;

    public bool alreadyOpened;

    public Animator anim;

	// Update is called once per frame
	void Update ()
    {   
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.position, cam.forward, out hit, range))
            {

                if(hit.transform.name == "door1")
                {
                    StopAllCoroutines();
                    StartCoroutine(Type("This Door is Locked"));
                    return;
                }


                if (hit.transform.tag == "door" && alreadyOpened == false)
                {
                    if(key.transform.parent != dest)
                    {
                        StopAllCoroutines();
                        StartCoroutine(Type("This Door is Locked"));
                    }
                    
                }

                if (hit.transform.tag == "door" && alreadyOpened == true)
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
        }
    }

    IEnumerator Type(string sentence)
    {
        text.text = "";
        foreach  (char letter in sentence)
        {
            text.text += letter;
            yield return null;
        }
        yield return new WaitForSeconds(1f);

        text.text = "";
    }
}
