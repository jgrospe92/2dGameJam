using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrol : MonoBehaviour
{


    public bool mustPatrol;
    


    // Control enemy movement
    public float walkSpeed;

    public Rigidbody2D rigidBody;
    [SerializeField] private GameObject groundObject;
    [SerializeField] private bool isGrounded;
    [SerializeField] private LayerMask layers;

    [SerializeField] GameObject otherEnemy;

    [Header("RayCast parameter")]
    [SerializeField] private float maxRayDistance;
    // Start is called before the first frame update
    void Start()
    {
        mustPatrol = true;
        isGrounded = true;

    }

    private void GroundCheck()
    {
        isGrounded = Physics2D.Raycast(groundObject.transform.position, Vector2.down, maxRayDistance, layers);
        
    }
    // Update is called once per frame
    void Update()
    {
        GroundCheck();
        if (!isGrounded)
        {
            flip();
        }
    }

    private void FixedUpdate()
    {

        if (mustPatrol && isGrounded)
        {
            Patrol();
        }

    }

    void Patrol()
    {
        if(transform.rotation.y == -1)
        {
            rigidBody.velocity = new Vector2(-walkSpeed * Time.fixedDeltaTime, 0);
        }
        else
        {
            rigidBody.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, 0);
        }

    }

    void flip()
    {
        transform.rotation = Quaternion.Euler(0, 180, 0) * transform.rotation;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(groundObject.transform.position, Vector2.down * maxRayDistance);
    }
}
