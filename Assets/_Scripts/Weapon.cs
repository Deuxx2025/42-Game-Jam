using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;


public class Weapon : MonoBehaviour
{
    public Camera playerCamera;
    public List<GameObject>bulletPool;
    public Transform gunMuzzle;
    public GameObject bulletPrefab;
    public float bulletVelocity = 30;
    public float delay = 3;
    public float spreadIntensity;

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            FireWeapon();
        }
    }

    private void FireWeapon()
    {
        Vector3 shootingDirection = CalculateDirectionAndSpread().normalized;
        for (int i = 0; i < bulletPool.Count; i++)
        {
            if (bulletPool[i].activeSelf == false)
            {
                bulletPool[i].transform.position = gunMuzzle.position;
                bulletPool[i].SetActive(true);
                bulletPool[i].transform.forward = shootingDirection;
                bulletPool[i].GetComponent<Rigidbody>().AddForce(shootingDirection * bulletVelocity, ForceMode.Impulse);
                StartCoroutine(DeactivateBulletAfterTime(delay, bulletPool[i]));
                break ;
            }
        }
    }

    public Vector3 CalculateDirectionAndSpread()
    {
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(100);
        }

        Vector3 direction = targetPoint - gunMuzzle.position;

        float x = UnityEngine.Random.Range(spreadIntensity, spreadIntensity);
        float y = UnityEngine.Random.Range(spreadIntensity, spreadIntensity);

        return direction + new Vector3(x, y, 0);
    }

    public IEnumerator DeactivateBulletAfterTime(float seconds, GameObject bullet)
    {
        yield return new WaitForSeconds(seconds);
        bullet.SetActive(false);
    }
}
