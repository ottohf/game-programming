using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFSM : MonoBehaviour
{
    public enum EnemyState { ChasePlayer, ChaseBase }
    public EnemyState currentState;
    public Sight sightSensor;
    private Transform baseTransform;
    private NavMeshAgent agent;
    public GameObject bullet;
    public float fireRate;
    public float lastShootTime;

    void Awake()
    {
        agent = GetComponentInParent<NavMeshAgent>();
        currentState = EnemyState.ChaseBase;
        baseTransform = GameObject.Find("BaseDamagePoint").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == EnemyState.ChasePlayer)
        {
            ChasePlayer();
        }
        else
        {
            ChaseBase();
        }
    }

    void ChasePlayer()
    {
        if (sightSensor.detectedObject == null)
        {
            currentState = EnemyState.ChaseBase;
            return;
        }
        agent.isStopped = false;

        agent.SetDestination(sightSensor.detectedObject.transform.position);
        Shoot();
    }

    void ChaseBase()
    {
        
        if (sightSensor.detectedObject != null){
            currentState = EnemyState.ChasePlayer;

            return;
        }
        agent.isStopped = false;
        // More flexible navmesh positioning
        NavMeshHit hit;
        if (NavMesh.SamplePosition(baseTransform.position, out hit, 1.0f, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
        else
        {
            Debug.LogError("Base position is not on the NavMesh");
        }
        Shoot();
    }

    void Shoot()
    {
        if (Time.time - lastShootTime > fireRate)
        {
            lastShootTime = Time.time;

            Instantiate(bullet, transform.position, transform.rotation);
        }
    }
   
}
