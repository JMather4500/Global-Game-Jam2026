using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class pickup : MonoBehaviour
{
    public float increase;
    [SerializeField] PlayerController playerController;

    private void OnTriggerEnter2D(Collider2D collision)

    {
        


        if (collision.tag == "Player")
        {

            playerController.moveSpeed += increase;

            Destroy(gameObject);



        }
    }
}
