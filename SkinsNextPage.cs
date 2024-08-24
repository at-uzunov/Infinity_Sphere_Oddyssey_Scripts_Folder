using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SkinsNextPage : MonoBehaviour
{
    public SharedValues sharedValues;
    public void onNextPage()
    {
        Vector3 rotate = sharedValues.cam.transform.eulerAngles;
        if (sharedValues != null & sharedValues.next_max_int < 1)
        {
            sharedValues.next_max_int = 1;
            sharedValues.previous_max_int = 0;
            sharedValues.prev_count = 0;
            sharedValues.next_count += 1;
            sharedValues.RotateCamera(60);
            if (rotate == new Vector3(0, 300, 0))
            {
                sharedValues.RotateCamera(0);
            }
            else if(rotate == new Vector3(0,0,0))
            {
                sharedValues.RotateCamera(60);
            }
        }
        else
        {
            Debug.Log("SharedValuesScript not assigned.");
        }
    }

    public void OnPreviousPage()
    {
        Vector3 rotate = sharedValues.cam.transform.eulerAngles;
        if (sharedValues != null & sharedValues.previous_max_int < 1) 
        {
            sharedValues.next_max_int = 0;
            sharedValues.previous_max_int = 1;
            sharedValues.prev_count += 1;
            sharedValues.next_count = 0;
            if(rotate == new Vector3(0, 0, 0)) {
                sharedValues.RotateCamera(300);
            }
            else if(rotate == new Vector3(0, 60, 0))
            {
                sharedValues.RotateCamera(0);
            }
        }
        else
        {
            Debug.Log("SharedValuesScript not assigned.");
        }
    }
}
