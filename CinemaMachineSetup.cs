using UnityEngine;
using Cinemachine;
using TMPro;

public class CinemaMachineSetup : MonoBehaviour
{
    public GameObject obj_to_follow;
    private CinemachineVirtualCamera _cam;
    public GameObject[] objects;
    public int skin_select;
    void Start()
    {
    }
    void Awake()
    {
        /*PlayerPrefs.SetInt("Players", skin_select);*/
        skin_select = PlayerPrefs.GetInt("Players", 0);
        obj_to_follow = objects[skin_select];
        _cam = GetComponent<CinemachineVirtualCamera>();
        _cam.Follow = obj_to_follow.transform;
        _cam.LookAt = obj_to_follow.transform;


    }
}
