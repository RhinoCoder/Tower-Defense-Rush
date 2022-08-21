using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocater : MonoBehaviour
{

    [SerializeField] private Transform weapon;
    [SerializeField] private float towerRange = 15f;
    [SerializeField] private ParticleSystem projectileParticles;
    
    private Transform target;
    
    

     
    private void Update()
    {
        FindClosestTarget();
        AimWeapon();        
    }

    private void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach (var enemy in enemies)
        {
            float targetDist = Vector3.Distance(transform.position, enemy.transform.position);

            if (targetDist < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDist;
            }

        }


        target = closestTarget;
    }

    private void AimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position,target.position);
        weapon.transform.LookAt(target.transform);
        
        if (target && targetDistance < towerRange)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }

    }

    private void Attack(bool isActive)
    {
        var emissionModule = projectileParticles.emission;
        emissionModule.enabled = isActive;
        
    }
}
