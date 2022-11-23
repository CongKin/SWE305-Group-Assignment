using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{

    Gun[] guns;
    float moveSpeed = 5;
    bool moveUp;
    bool moveDown;
    bool moveLeft;
    bool moveRight;

    bool shoot;
    
    // Start is called before the first frame update
    void Start()
    {
        guns = transform.GetComponentsInChildren<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
        moveUp = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        moveDown = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
        moveLeft = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
        moveRight = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);

        shoot = Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.LeftShift);
        if (shoot)
        {
            shoot = false;
            foreach(Gun gun in guns)
            {
                gun.Shoot();
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;
        float moveAmount = moveSpeed * Time.fixedDeltaTime; 
        Vector2 move = Vector2.zero;

        if (moveUp)
        {
            move.y += moveAmount;
        }

        if (moveDown)
        {
            move.y -= moveAmount;
        }

        if (moveLeft)
        {
            move.x -= moveAmount;
        }

        if (moveRight)
        {
            move.x += moveAmount;
        }

        float moveMagnitude = Mathf.Sqrt(move.x * move.x + move.y * move.y);
        if (moveMagnitude > moveAmount)
        {
            float ratio = moveAmount / moveMagnitude;
            move *= ratio;
        }
        pos += move;
        if (pos.x <= -8f)
        {
            pos.x = -8f;
        }

        if (pos.x >= 8f)
        {
            pos.x = 8f;
        }

        if (pos.y <= -4)
        {
            pos.y = -4;
        }

        if (pos.y >= 4)
        {
            pos.y = 4;
        }

        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destructable destructable = collision.GetComponent<Destructable>();
        if (destructable != null)
        {
            Destroy(gameObject);
        }
    }
}
