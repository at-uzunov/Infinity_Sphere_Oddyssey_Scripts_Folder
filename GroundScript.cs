using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    GameObject rbD;
    public Rigidbody Obj1, Obj2;
    public Rigidbody Obj3;
    public GameObject object2, StarGate, object1,Coins,Square;
    public GameObject TestObstacle, TestObstacle2;
    public GameObject Shield;
    public float spawnDistance = 5f, spawnHeight = 1f, spawnRate = 2f;
    public int xSpawnRange = 4;
    private float spawnTimer = 0f;
    private GameObject player;
    private float rotationCenterOffset = 60f;
    private Transform rotationCenter;
    private List<Transform> rotationCenters = new List<Transform>();
    void Start()
    {
        /* transform.position = new Vector3(0, 1, 10*Time.deltaTime); */
        rbD = GameObject.Find("Ground");
    }
    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            if (player == null)
            {
                // Player not found yet, return and try again in the next frame
                return;
            }
        }
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnRate)
        {
            int y = Random.Range(1,4);
            if(y ==2)
            {
                SpawnTestObstacle1();
                SpawnTestObstacle2();
                for (int i = 0; i < 20; i++)
                {
                    SpawnObjects2();
                }
                SpawnObjects1();
                SpawnCoins();

                /* Don't activate */
                /*  SpawnSquare(); */
            }
            else
            {
                SpawnObjects1();
                for(int i = 0; i < 20; i++)
                {
                   SpawnObjects2();
                }
                SpawnCoins();
                SpawnStarGate();
            }
            SpawnShield();
            spawnTimer = 0f;
        }
        CheckObjectPosition();
        List<Transform> validRotationCenters = new List<Transform>(); // Temporary list to store valid rotation centers

        foreach (Transform rotationCenter in rotationCenters)
        {
            if (rotationCenter != null) // Check if the rotation center is not destroyed
            {
                Vector3 currentRotation = rotationCenter.localRotation.eulerAngles;
                currentRotation.y += rotationCenterOffset * Time.deltaTime;
                rotationCenter.localRotation = Quaternion.Euler(currentRotation);

                validRotationCenters.Add(rotationCenter); // Add the valid rotation center to the temporary list
            }
        }

        rotationCenters = validRotationCenters;
        Obj1.position = transform.position + new Vector3(20f, 0f, -10f);
        Obj2.position = transform.position + new Vector3(20f, 0f, -10f);
        Obj3.position = transform.position + new Vector3(20f,0,-10f);
    }

    void SpawnObjects1()
    {
        int yRandom1 = Mathf.RoundToInt(Random.Range(1, 4f));
        Vector3 spawnPosition1 = rbD.transform.position + new Vector3(0, yRandom1, spawnDistance);
        GameObject spawnedObject1 = Instantiate(object1, spawnPosition1, Quaternion.identity);
        spawnedObject1.tag = "CloneObject"; // Assign a unique tag to the clone object
        Rigidbody spawnedObject2Rb = spawnedObject1.GetComponent<Rigidbody>();
        spawnedObject2Rb.constraints = RigidbodyConstraints.FreezeAll;
        BoxCollider collider1 = spawnedObject1.AddComponent<BoxCollider>();
        collider1.size = new Vector3(10f, 10f, 1f); // Set the size of the collider
        collider1.isTrigger = true; // Set the collider as a trigger
    }
    void SpawnObjects2()
    {
        int yRandom2 = Mathf.RoundToInt(Random.Range(1, 4f));
        int randomXOffset2 = Random.Range(-xSpawnRange, xSpawnRange+1);
        Vector3 spawnPosition2 = rbD.transform.position + new Vector3(randomXOffset2, yRandom2, -spawnDistance);
        GameObject spawnedObject2 = Instantiate(object2, spawnPosition2, Quaternion.identity);
        spawnedObject2.tag = "CloneObject"; // Assign a unique tag to the clone object
        Rigidbody spawnedObject2Rb = spawnedObject2.GetComponent<Rigidbody>();
        spawnedObject2Rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    void SpawnStarGate(){
        int GateRandom = Random.Range(1,5);
            if(GateRandom == 2){
            Vector3 spawnposition = rbD.transform.position + new Vector3(0,5,spawnDistance + 14);
            GameObject StarGateClone = Instantiate(StarGate,spawnposition,Quaternion.identity);
            StarGateClone.transform.Rotate(new Vector3(-90,0,0));
            Transform childTransform = StarGateClone.transform.GetChild(2);
            Transform grandChildTransform = childTransform.GetChild(0);
            Transform circleChild = StarGateClone.transform.GetChild(1);
            circleChild.tag = "CloneObject";
            childTransform.tag = "CloneObject";
            grandChildTransform.tag = "CloneObject";
            StarGateClone.tag = "CloneObject";
            Rigidbody StargatedCloneRB = StarGateClone.GetComponent<Rigidbody>();
            StargatedCloneRB.constraints = RigidbodyConstraints.FreezePosition;
            /*  BoxCollider StarCollider = StarGateClone.AddComponent<BoxCollider>(); */ 
            Transform rotationCenter = StarGateClone.transform.Find("RotationCenter"); // Get the rotation center
            rotationCenters.Add(rotationCenter); // Add the rotation center to the list
            /* StarCollider.isTrigger = true; */
        }
    }
    void SpawnCoins(){
        for(int i =0;i<5;i++)
        {
            float zRandom = Random.Range(1, 8);
            int yRandom = Random.Range(0, 3);
            int yAxis = (yRandom == 1) ? 1 : 3; // Simplified the if-else statements using the ternary operator
            int randomXOffset3 = Random.Range(-xSpawnRange, xSpawnRange + 1);
            Vector3 spawnPosition2 = rbD.transform.position + new Vector3(randomXOffset3, yAxis, spawnDistance + zRandom);
            GameObject spawnedCoins = Instantiate(Coins, spawnPosition2, Quaternion.identity);
            spawnedCoins.transform.Rotate(new Vector3(-90, 0, 0));
            spawnedCoins.tag = "Coins";
            Rigidbody spawnedCoinsRB = spawnedCoins.GetComponent<Rigidbody>();
            spawnedCoinsRB.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
    void SpawnSquare(){
        int SquareRandom = Random.Range(1, 5);
        if (SquareRandom == 2)
        {
            Vector3 spawnPosition = rbD.transform.position + new Vector3(0, -2, spawnDistance+15);
            GameObject spawnedSquare = Instantiate(Square, spawnPosition, Quaternion.identity);
            spawnedSquare.tag = "CloneObject";
            Rigidbody SpawnedSquareRB = spawnedSquare.GetComponent<Rigidbody>();
            SpawnedSquareRB.constraints = RigidbodyConstraints.FreezePosition;
        }
    }

    void SpawnTestObstacle1()
    {
        Vector3 spawnPosition = rbD.transform.position + new Vector3(1, 4, spawnDistance-10);
        int random_row = Random.Range(1, 3);
        GameObject obstacle = Instantiate(TestObstacle, spawnPosition, Quaternion.identity);
        if (random_row == 2)
        {
            obstacle.transform.Rotate(new Vector3(0, 0, 180));
            obstacle.transform.position = rbD.transform.position + new Vector3(-1,2,spawnDistance-10); 
        }
        obstacle.tag = "CloneObject";

    }

    void SpawnTestObstacle2()
    {
        int rnd = Random.Range(-8, 2);
        int random_row = Random.Range(1, 3);
        Vector3 spawnPosition = rbD.transform.position + new Vector3(rnd, 3, spawnDistance);
        GameObject obstacle = Instantiate(TestObstacle2, spawnPosition, Quaternion.identity);
        if (random_row == 2)
        {
            obstacle.transform.Rotate(new Vector3(0, 0, 90));
            obstacle.transform.position = rbD.transform.position + new Vector3(0, 0, +9);
        }
        obstacle.tag = "CloneObject";

    }
    void SpawnShield()
    {
        int rnd = Random.Range(1, 8);
        /*if(rnd == 2)
        { */
            float zRandom = Random.Range(1, 8);
            int yRandom = Random.Range(0, 4);
            int yAxis = (yRandom == 1) ? 1 : 4; // Simplified the if-else statements using the ternary operator
            int randomXOffset3 = Random.Range(-xSpawnRange, xSpawnRange + 1);
            Vector3 spawnPosition2 = rbD.transform.position + new Vector3(randomXOffset3, yAxis, spawnDistance + zRandom);
            GameObject spawnedShield = Instantiate(Shield, spawnPosition2, Quaternion.identity);
            spawnedShield.tag = "ShieldClone";
        /*}*/

    }
    void CheckObjectPosition()
    {

        float playerZPosition = player.transform.position.z;
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("CloneObject");
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coins");
        GameObject[] final = obstacles.Concat(coins).ToArray();
        foreach (GameObject obstacle in final)
        {
            if (obstacle.transform.position.z < playerZPosition - 10f)
            {
                Destroy(obstacle);
            }
        }
    }
}