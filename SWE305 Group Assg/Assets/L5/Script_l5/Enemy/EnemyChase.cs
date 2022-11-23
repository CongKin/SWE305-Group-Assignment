using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public GameObject player;
    public float speed; 
    public float distanceBetween;

    private Rigidbody2D rigidBody2D;
    private bool facingLeft = true;
    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player)
        {
            distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - transform.position; 
            //direction.Normalize();
            //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; 

            if (distance < distanceBetween)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.fixedDeltaTime);
                
                //transform.rotation = Quaternion.Euler(Vector3.forward * angle);
                if(this.transform.position.x > player.transform.position.x && !facingLeft)
                {
                    Flip ();
                }
                else if(this.transform.position.x < player.transform.position.x && facingLeft)
                {
                    Flip ();
                }
                
            }
        }
    }

    private void Flip()
    {
        facingLeft =! facingLeft;
        Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
    }
}
