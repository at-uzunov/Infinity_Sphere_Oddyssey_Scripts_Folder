using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharedValues : MonoBehaviour
{
    public Canvas canvas1;
    public Canvas canvas2;
    public Canvas canvas3;
    public Camera cam;
    public int next_count = 0;
    public int prev_count = 0;
    public int next_max_int = 0;
    public int previous_max_int = 0;

    private void Update()
    {
        if(cam.transform.eulerAngles == new Vector3(0,0,0)){
            next_max_int = 0;
            previous_max_int = 0;
            canvas1.gameObject.SetActive(true);
            canvas2.gameObject.SetActive(false);
            canvas3.gameObject.SetActive(false);
            canvas1.enabled = true;
            canvas2.enabled = false;
            canvas3.enabled = false;
        }
        else if (cam.transform.eulerAngles == new Vector3(0, 300, 0))
        {
            canvas1.gameObject.SetActive(false);
            canvas2.gameObject.SetActive(true);
            canvas3.gameObject.SetActive(false);
            canvas1.enabled = false;
            canvas2.enabled = true;
            canvas3.enabled = false;

        }
        else if (cam.transform.eulerAngles == new Vector3(0, 60, 0))
        {
            canvas1.gameObject.SetActive(false);
            canvas2.gameObject.SetActive(false);
            canvas3.gameObject.SetActive(true);
            canvas1.enabled = false;
            canvas2.enabled = false;
            canvas3.enabled = true;

        }
    }

    public void RotateCamera(int angle)
    {
        if (cam != null)
        {
            cam.transform.eulerAngles = new Vector3(0, angle, 0);
        }
        else
        {
            Debug.Log("Insert camera");
        }
    }
}
