using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{

    [SerializeField] private bool isPlaceable;
    [SerializeField] private Tower towerPrefab;
    
    
    public bool IsPlaceable{get{return isPlaceable;}}
    
    
    
    
    
    
    private void OnMouseDown()
    {
        if (isPlaceable)
        {
            bool isPlaced = towerPrefab.CreateTower(towerPrefab,transform.position);
            isPlaceable = !isPlaced;


        }   
        
    }
    
    
    
}
