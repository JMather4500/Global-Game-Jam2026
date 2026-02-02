using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    public float detectionRange = 1f;
    public GameObject target;
    public float distanceToTarget = 5f;
    public Vector3 viewingAngle;
    private bool canSeePlayer = false;
    public LayerMask layerMask;

    void Awake()
    {
        target = GameObject.FindWithTag("Player");

    }

    void Update()
    {
        distanceToTarget = Vector2.Distance(transform.position, target.transform.position);
        canSeePlayer = CheckCanSeePlayer(distanceToTarget);
        Debug.Log("Can see player = " + canSeePlayer);
        if (canSeePlayer)
        {
            viewingAngle = target.transform.position - transform.position;

            RaycastHit2D hit2D = Physics2D.Raycast(transform.position, target.transform.position);
            if (hit2D)
            {
                Debug.DrawRay(transform.position, viewingAngle, Color.green);
                Debug.Log("Hit");
            }
        }
    }


    public bool CheckCanSeePlayer(float distanceToTarget)
    {
        if (distanceToTarget > detectionRange)
        {
            return false;
        }
        else if (distanceToTarget < detectionRange)
        {
            return true;
        }
        else { return false; }
    }
}
