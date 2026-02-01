using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public float patrolDistance = 10f;  // Distance for patrolling back and forth
    public float patrolSpeed = 2f;      // Speed of patrolling

    private bool movingRight = true;     // Flag to determine movement direction
    private float startPosX;            // Starting position of the Cop
    private SpriteRenderer spriteRenderer;  // Reference to the SpriteRenderer component

    private void Start()
    {
        startPosX = transform.position.x;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Patrolling back and forth
        if (movingRight)
        {
            transform.Translate(Vector2.right * patrolSpeed * Time.deltaTime);
            if (!spriteRenderer.flipX)  // Check if sprite is not already flipped
                spriteRenderer.flipX = true;  // Flip the sprite horizontally
        }
        else
        {
            transform.Translate(Vector2.left * patrolSpeed * Time.deltaTime);
            if (spriteRenderer.flipX)  // Check if sprite is already flipped
                spriteRenderer.flipX = false;  // Flip the sprite back to its original orientation
        }

        // Checking if reached patrol distance
        if (Mathf.Abs(transform.position.x - startPosX) >= patrolDistance)
        {
            // Change direction
            movingRight = !movingRight;
        }
    }
}
