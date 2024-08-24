using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject player;
    public GameObject ground;
    public GameObject SideWall1, SideWall2;
    int screen_width = Screen.width/2;
    int screen_height = Screen.height/7;
    public int speed_increment = 2;
    public int forward_speed = 3;
    public int side_speed = 3;
    public int vertical_speed = 2;
    public int set_max_height = 2;
    public int set_min_height = 1;
    public GameObject shield;
    int shield_status;
    bool is_active = false;
    Transform childTransform;


    public GameObject VirtualCameraGameobject;
    public CinemaMachineSetup machine;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Shields", 0);
        /*PlayerPrefs.SetInt("Coins", 100);*/
        machine = VirtualCameraGameobject.GetComponent<CinemaMachineSetup>();
        machine.objects[machine.skin_select].transform.position = new Vector3(0, 1, 0);
        machine.objects[machine.skin_select].tag = "Player";
        machine.objects[machine.skin_select].AddComponent<Collisions>();
        machine.objects[machine.skin_select].AddComponent<Rigidbody>();
        machine.objects[machine.skin_select].GetComponent<Rigidbody>().useGravity = false;
        machine.objects[machine.skin_select].GetComponent<Rigidbody>().isKinematic = true;
        machine.objects[machine.skin_select].AddComponent<SphereCollider>();
        try
        {
            childTransform = machine.objects[machine.skin_select].transform.GetChild(0);
        }
        catch
        {
            Debug.Log("No Child");
        }
        // Add your script to the child object
        if (childTransform != null)
        {
            childTransform.gameObject.AddComponent<Rorations>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        machine.objects[machine.skin_select].transform.Translate(new Vector3(0, 0, forward_speed) * speed_increment * Time.deltaTime);
        ground.transform.Translate(new Vector3(0, 0, forward_speed) * speed_increment * Time.deltaTime);
        SideWall1.transform.Translate(new Vector3(0, 0, forward_speed) * speed_increment * Time.deltaTime);
        SideWall2.transform.Translate(new Vector3(0, 0, forward_speed) * speed_increment * Time.deltaTime);
        shield_status = PlayerPrefs.GetInt("Shields");
        if (shield_status == 1 && is_active == false)
        {
            GameObject shieldInstance = Instantiate(shield, machine.objects[machine.skin_select].transform);
            shieldInstance.tag = "PlayerShield";
            shieldInstance.transform.position = machine.objects[machine.skin_select].transform.position + new Vector3(0,1,0);
            is_active = true;
        }
        if(shield_status == 0)
        {
            GameObject destroy = GameObject.FindGameObjectWithTag("PlayerShield");
            Destroy(destroy);
            is_active = false;
        }
        if (Input.GetMouseButton(0))
        {

            Vector3 mouse_click = Input.mousePosition;
            /*Debug.Log(mouse_click);*/
            if ( (mouse_click[0] < screen_width) & (mouse_click[1] < screen_height) )
            {
                if (machine.objects[machine.skin_select].transform.position.y > set_min_height)
                {
                    machine.objects[machine.skin_select].transform.Translate(new Vector3(-side_speed, -vertical_speed, 0) * speed_increment * Time.deltaTime);
                }
                else
                {
                    machine.objects[machine.skin_select].transform.Translate(new Vector3(-side_speed, 0, 0) * speed_increment * Time.deltaTime);
                }
            }
            else if ( (mouse_click[0] > screen_width) & (mouse_click[1] < screen_height) )
            {
                if (machine.objects[machine.skin_select].transform.position.y > set_min_height)
                {
                    machine.objects[machine.skin_select].transform.Translate(new Vector3(side_speed, -vertical_speed, 0) * speed_increment * Time.deltaTime);
                }
                else
                {
                    machine.objects[machine.skin_select].transform.Translate(new Vector3(side_speed, 0, 0) * speed_increment * Time.deltaTime);
                }
            } 
            else if ( (mouse_click[0] < screen_width) & (mouse_click[1] > screen_height) )
            {
                if(machine.objects[machine.skin_select].transform.position.y <= set_max_height)
                {
                    machine.objects[machine.skin_select].transform.Translate(new Vector3(-side_speed, vertical_speed, 0) * speed_increment * Time.deltaTime);
                }
                else {
                    machine.objects[machine.skin_select].transform.Translate(new Vector3(-side_speed, 0, 0) * speed_increment * Time.deltaTime);
                }
            }
            else if ( (mouse_click[0] > screen_width) & (mouse_click[1] > screen_height) )
            {
                if (machine.objects[machine.skin_select].transform.position.y <= set_max_height)
                {
                    machine.objects[machine.skin_select].transform.Translate(new Vector3(side_speed, vertical_speed, 0) * speed_increment * Time.deltaTime);
                }
                else
                {
                    machine.objects[machine.skin_select].transform.Translate(new Vector3(side_speed, 0, 0) * speed_increment * Time.deltaTime);
                }
            }
        }
    }
}
