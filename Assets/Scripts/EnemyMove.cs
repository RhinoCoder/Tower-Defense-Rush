using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Enemy))]
public class EnemyMove : MonoBehaviour
{
    

    [SerializeField] private List<WayPoint> path = new List<WayPoint>();
    [SerializeField] [Range(0f,5f)] private  float speed = 1.5f;

    private Enemy enemy;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }

    private void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());

    }


    private void FindPath()
    {
        
        path.Clear();
        GameObject parent = GameObject.FindGameObjectWithTag("Path");
        
        foreach (Transform child in parent.transform)
        {
            
            WayPoint wayPoint = child.GetComponent<WayPoint>();
            if (wayPoint != null)
            {
                path.Add(wayPoint);
            }
            
        }

    }

    private void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    private IEnumerator FollowPath()
    {

        foreach (WayPoint wp in path)
        {
            Vector3 startPos = transform.position;
            Vector3 endPos = wp.transform.position;
            float travelPercent = 0f;
            
            transform.LookAt(endPos);
            
            while (travelPercent < 1)
            {
                travelPercent += Time.deltaTime*speed;
                transform.position = Vector3.Lerp(startPos, endPos, travelPercent);
                yield return new WaitForEndOfFrame();
            }

        }
        
        FinishPath();        
    }
    

    private void FinishPath()
    {
        enemy.StealGold();
        gameObject.SetActive(false);
    }
    
    
}
