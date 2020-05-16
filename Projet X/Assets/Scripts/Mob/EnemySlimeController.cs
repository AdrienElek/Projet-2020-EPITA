using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    Wander,
    
    Follow,
    
    Die,
}
public class EnemySlimeController : MonoBehaviour
{
    
    public GameObject player;
    public EnemyState currState = EnemyState.Wander;

    public float speed;

    private bool chooseDir = false;
    
    public float range;

    private bool IsAlive = true;

    private Vector3 randomDir;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (currState == EnemyState.Wander)
        {
            Wander();

        }
        else if (currState == EnemyState.Follow)
        {
            Follow();

        }
        else if (currState == EnemyState.Die)
        {
            
        }
        else if (PlayerInRange(range))
        {
            currState = EnemyState.Follow;

        }
        else
        {
            currState = EnemyState.Wander;
        }
        
    }
    private bool PlayerInRange(float range)
    {
        return Vector3.Distance(transform.position, player.transform.position) < range;
    }


    private IEnumerator ChooseDirection()
    {
        chooseDir = true;
        yield return new WaitForSeconds(Random.Range(1f,10f));
        randomDir = new Vector3(0, 0, Random.Range(0,360));
        Quaternion nextRota = Quaternion.Euler(randomDir);
        transform.rotation = Quaternion.Lerp(transform.rotation, nextRota, Random.Range(0.5f, 3f));
        chooseDir = false;
    }

    void Wander()
    {
        if (chooseDir)
        {
            
        }
        else
        {
            StartCoroutine(ChooseDirection());
        }

        transform.position = transform.position - transform.right * speed * Time.deltaTime;
        
        if (PlayerInRange(range))
        {
            currState = EnemyState.Follow;

        }
    }

    void Follow()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
    
    
}
