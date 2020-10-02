using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class code : MonoBehaviour {

    public GameObject img;
    public Transform cam;
    public float range;
    public Text txt;
    public string Code;

    public Animator anim;

    private float firstnum;
    private float secondnum;
    private float thirdnum;
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
            {
                if(hit.transform.name == "code")
                {
                    img.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                    anim.SetBool("lol",true);

                }
            }
        }
        if(thirdnum != 0)
        {
            string codeEntered = "";
            codeEntered = firstnum.ToString() + secondnum.ToString() + thirdnum.ToString();
            if (codeEntered == Code)
            {
                txt.text = "Code Accepted!";
                
                StartCoroutine(Close());
                
            }
            else
            {
                txt.text = "Access Denied!";
                StartCoroutine(Reset());
            }
        }
	}

    public void OnKeyClick(float num)
    {
        if(firstnum == 0)
        {
            firstnum = num;
            txt.text = firstnum.ToString();
        }
        else
        {
            if(secondnum == 0)
            {
                secondnum = num;
                txt.text = firstnum.ToString() + secondnum.ToString();
            }
            else
            {
                thirdnum = num;
                txt.text = thirdnum.ToString();

            }
        }        
    }

    IEnumerator Close()
    {
        yield return new WaitForSeconds(1f);
        anim.SetBool("lol", false);
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(1f);
        txt.text = "Enter Code...";
        
    }
}
