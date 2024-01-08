using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class IA : MonoBehaviour
{

    [SerializeField]
    private GameObject ia;

    [SerializeField]
    private NavMeshAgent navMeshAgent;

    private Vector3 randomDirection = new Vector3();

    private bool isAtDestination = false;

    private float timer;

    private float timeToStop;

    // Start is called before the first frame update
    void Start()
    {
        timeToStop = randomStopTime();
        timer = Time.time;
        searchDestination();
    }

    // Update is called once per frame
    void Update()
    {
        moveSystem();
        
    }


    private void searchDestination(){
        timeToStop = randomStopTime();
        randomDirection = Random.insideUnitSphere * 10;
    }

    private void moveSystem(){
    if(navMeshAgent.remainingDistance < 0.5f){

            if(!isAtDestination){
                isAtDestination = true;
                timer = Time.time;
            }else{
                
                //7seconde et 10 seconde
                if(Time.time > timer + timeToStop){
                    isAtDestination = false;
                    searchDestination();
                }
            }
            
            
        }
        navMeshAgent.destination = randomDirection;
    }

    private float randomStopTime(){
        return Random.Range(3f, 10f);
    }
}
