using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float fireRate = 0.2f;
    public Transform firingPoint;
    public GameObject bulletPreFab;

    float reloadTime;

    PlayerMovement pm;

    private void Start()
    {
        pm = gameObject.GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) && reloadTime < Time.time)
        {
            Shoot();
            reloadTime = Time.time + fireRate;
        } 
    }

    // shoot methid
    void Shoot()
    {
        float angle = pm.isFacingRIght ? 0f : 180f;
        Instantiate(bulletPreFab, firingPoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
     
    }
}
