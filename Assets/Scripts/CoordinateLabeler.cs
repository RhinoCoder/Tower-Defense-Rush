using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



[ExecuteAlways] 
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{

    [SerializeField] private Color defaultColor = Color.white;
    [SerializeField] private Color blockedColor = Color.grey;
    
    private TextMeshPro label;
    private Vector2Int coordinates = new Vector2Int();
    private WayPoint wayPoint;
    
    
    
    private void Awake()
    {
        wayPoint = GetComponentInParent<WayPoint>();
        label = GetComponent<TextMeshPro>();
        label.enabled = false;
        DisplayCoordinates();
    }

    private void Update()
    {

        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
             

        }

        SetLabelColor();
        ToggleLabels();

    }

    private void SetLabelColor()
    {
        if (wayPoint.IsPlaceable)
        {
            label.color = defaultColor;
        }
        else
        {
            label.color = blockedColor;
        }
        
    }

    private void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z/ UnityEditor.EditorSnapSettings.move.z);
        label.text = $"{coordinates.x},{coordinates.y}";
    }

    private void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }

    private void ToggleLabels()
    {

        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }
}
