using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour {

    private static EnemyManager s_instance = null;
    public static EnemyManager Instance
    {
        get
        {
            return s_instance;
        }
    }
    private void Awake()
    {
        if (s_instance != null) Debug.Log("EnemyManager already exists.");
        s_instance = this;
    }
    private void OnDestroy()
    {
        if (s_instance == this) s_instance = null;
    }

    public Transform EnemyParent;
    public Transform[] SpawnPoints;
    public Transform[] PatrolPointsRoom1;
    public Transform[] PatrolPointsRoom2;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddEnemy(int AddToRoom)
    {
        Transform t = Instantiate(Resources.Load<Transform>("Enemy/Enemy"),SpawnPoints[AddToRoom].position,Quaternion.identity,EnemyParent.transform);
        t.GetComponent<EnemyPatrol>().points = GetPatrolPoint(AddToRoom);
    }

    Transform[] GetPatrolPoint(int index)
    {
        if(index == 0)
        {
            return PatrolPointsRoom1;
        }
        else if(index == 1)
        {
            return PatrolPointsRoom2;
        }

        return PatrolPointsRoom1;
    }
}
