using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class EnemyFollowPath : MonoBehaviour
{

    public EndOfPathInstruction endOfPathInstruction;
    public float movementSpeed = 5f;

    private PathCreator path;
    public GameObject[] enemy_obj;
    public GameObject enemy;

    [HideInInspector]
    public float distanceTravelled;

    private Vector3 newPos;

    void Awake()
    {
        path = GameObject.FindGameObjectWithTag("Path").GetComponent<PathCreator>();        //Initializes path
        distanceTravelled = FindObjectOfType<Spawner>().distanceTravelled;
        GameObject temp= Instantiate(enemy_obj[Random.Range(0, enemy_obj.Length)], transform.position, Quaternion.identity);
        temp.transform.parent = enemy.transform;
        Move();     //Makes the enemy follow the path
    }

    void Update()
    {
        Move();     //Makes the enemy follow the path
    }
    
    public void Move()
    {
        distanceTravelled += movementSpeed * Time.deltaTime;
        newPos = path.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
        transform.position = newPos;
        transform.rotation = path.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
        transform.Rotate(Vector3.forward, 90f);
    }
}
