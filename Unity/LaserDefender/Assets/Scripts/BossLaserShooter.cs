using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLaserShooter : MonoBehaviour
{
    [SerializeField] private GameObject impactEffect;
    [SerializeField] private List<Transform> firePoints;
    [SerializeField] private LineRenderer lineRendererPrefab;
    private List<LineRenderer> lasers = new List<LineRenderer>();
    private float maximumLaserLenght = 7.5f;
    private float shootTime = 5f;
    private float timeBeforeDestoyImpactEffect = 0.3f;
    private float laserDamage;
    private bool isBossStillShoot = true;

    private void Start()
    {
        laserDamage = lineRendererPrefab.GetComponent<DamageMaker>().GetDamage();
        for (int i = 0; i < firePoints.Count; i++)
        {
            Vector3 position = firePoints[i].position;
            LineRenderer instance = Instantiate(lineRendererPrefab, position, Quaternion.identity, transform);
            lasers.Add(instance);
        }
    }

    private void Update()
    {
        if (shootTime > 0)
        {
            Shoot();
            shootTime -= Time.deltaTime;
        }
        else if(isBossStillShoot)
        {
            StopLasers();
        }
    }

    private void Shoot()
    {
        for (int i = 0; i < lasers.Count; i++)
        {
            Vector3 laserPointPosition = firePoints[i].position;
            LineRenderer currentLaser = lasers[i];
            RaycastHit2D hitInfo = Physics2D.Raycast(laserPointPosition, firePoints[i].up);
            if (hitInfo)
            {
                currentLaser.SetPosition(0, laserPointPosition);
                currentLaser.SetPosition(1, hitInfo.point);
                StartCoroutine(PlayImpactEffect(hitInfo.point));
                hitInfo.transform.GetComponent<Health>().TakeDamage(laserDamage);
            }
            else
            {
                currentLaser.SetPosition(0, laserPointPosition);
                currentLaser.SetPosition(1, laserPointPosition + firePoints[i].up * maximumLaserLenght);
            }
        }
    }

    private void StopLasers()
    { 
        foreach (LineRenderer laser in lasers)
        {
            Destroy(laser);
        }
        isBossStillShoot = false;
    }

    private IEnumerator PlayImpactEffect(Vector3 position)
    {
        GameObject instance = Instantiate(impactEffect, position, Quaternion.identity);
        yield return new WaitForSeconds(timeBeforeDestoyImpactEffect);
        Destroy(instance.gameObject);
    }

    public bool IsBossStillShoot()
    {
        return isBossStillShoot;
    }
}

