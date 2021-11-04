using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunScript : MonoBehaviour
{
    public LineRenderer ShotLine;
    public Camera PlayerCam;
    public Transform barrelPos;
    public GameObject Bullet;
    [SerializeField]
    private float bulletVelocity;
    [SerializeField]
    private float shotDelay;
    private float currDelay;
    private float inputSave = 0f;
    [SerializeField]
    private float gunRange;
    [SerializeField]
    private float gunDamage = 1f;
    public float GunDamage { get { return gunDamage; } }

    void Start()
    {
        ShotLine = GetComponent<LineRenderer>();
        ShotLine.enabled = false;
    }

    void Update()
    {
        Shooting();
    }

    private void Shooting()
    {
        if (Input.GetButtonDown("Fire1"))
            inputSave = 0.2f;
        if (inputSave > 0)
            inputSave -= Time.deltaTime;

        if (currDelay <= 0 && Input.GetButton("Fire1") || inputSave >= 0)
        {
            //Instantiate(Bullet, barrelPos.position, Quaternion.identity);
            //Bullet.transform.position += transform.forward * bulletVelocity * Time.deltaTime;

            Vector3 rayCastOrigin = PlayerCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.5f));
            RaycastHit hitTarget;
            ShotLine.SetPosition(0, barrelPos.position);

            if (Physics.Raycast(rayCastOrigin, PlayerCam.transform.forward, out hitTarget, gunRange))
            {
                ShotLine.SetPosition(1, hitTarget.point);
            }
            else
                ShotLine.SetPosition(1, rayCastOrigin + (PlayerCam.transform.forward * gunRange));
            currDelay = shotDelay;
            StartCoroutine("ShootVFX");
        }

        if (currDelay > 0)
            currDelay -= Time.deltaTime;
    }

    private IEnumerator ShootVFX()
    {
        ShotLine.enabled = true;
        yield return new WaitForSeconds(0.5f);
        ShotLine.enabled = false;
    }
}
