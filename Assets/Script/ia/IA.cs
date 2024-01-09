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

    [SerializeField]
    private Sprite[] sprites;

    
    private Camera camera;

    private Vector3 randomDirection = new Vector3();

    private bool isAtDestination = false;

    private float timer;

    private float timeToStop;



    
    private void Awake()
    {
        timeToStop = randomStopTime();
        timer = Time.time;
        searchDestination();
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        int random = Random.Range(0, sprites.Length - 1);
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[random];
    }

    // Start is called before the first frame update
    void Start()
    {
        

        //ScreenCapture.CaptureScreenshot("toto");
    }

    // Update is called once per frame
    void Update()
    {
        moveSystem();
        var n  = camera.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(n);
    }


    private void searchDestination(){
        
        timeToStop = randomStopTime();
        randomDirection = Random.insideUnitSphere * 10;
        
    }

    private void moveSystem(){
    
        if(navMeshAgent.remainingDistance < 0.5f){
            //Debug.Log(navMeshAgent.remainingDistance);
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
        navMeshAgent.ResetPath();
        navMeshAgent.SetDestination(randomDirection+ gameObject.transform.position);
        
    }
    

    private float randomStopTime(){
        return Random.Range(0f, 10f);
    }
}
