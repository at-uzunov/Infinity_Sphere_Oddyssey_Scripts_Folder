using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rorations : MonoBehaviour
{
    public int left_side;
    public int horizontal_speed;
    public int forwards_speed = 300;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(forwards_speed * Time.deltaTime, horizontal_speed * Time.deltaTime, left_side * Time.deltaTime);
    }
}
