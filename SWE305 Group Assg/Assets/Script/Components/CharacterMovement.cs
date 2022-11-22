using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : CharacterComponents
{
    [SerializeField] private float walkSpeed = 6f;

    public float MoveSpeed { get; set; }

    private readonly int movingParamaterUp = Animator.StringToHash("MovingUp");
    private readonly int movingParamaterDown = Animator.StringToHash("MovingDown");
    private readonly int movingParamaterLeft = Animator.StringToHash("MovingLeft");
    private readonly int movingParamaterRight = Animator.StringToHash("MovingRight");

    protected override void Start()
    {
        base.Start(); 
        MoveSpeed = walkSpeed;		       
    } 

    protected override void HandleAbility()
    {
        base.HandleAbility();
        MoveCharacter(); 
        UpdateAnimations();	       
    } 

    private void MoveCharacter()
    {
        Vector2 movement = new Vector2(x: horizontalInput, y: verticalInput);         
        Vector2 movementNormalized = movement.normalized;   
        Vector2 movementSpeed = movementNormalized * MoveSpeed;
        controller.SetMovement(movementSpeed);
    }

    private void UpdateAnimations()
    {
        if(horizontalInput > 0.1f)
        {
            if (character.CharacterAnimator != null)
            {
                character.CharacterAnimator.SetBool(movingParamaterRight, true);
            }
        }else if(horizontalInput < 0.1f)
        {
            if (character.CharacterAnimator != null)
            {
                character.CharacterAnimator.SetBool(movingParamaterLeft, true);
            }
        }else if(verticalInput > 0.1f)
        {
            if (character.CharacterAnimator != null)
            {
                character.CharacterAnimator.SetBool(movingParamaterUp, true);
            }
        }else if(verticalInput < 0.1f)
        {
            if (character.CharacterAnimator != null)
            {
                character.CharacterAnimator.SetBool(movingParamaterDown, true);character.CharacterAnimator.SetBool(movingParamaterUp, true);
            }
        }else
        {
            if (character.CharacterAnimator != null)
            {
                character.CharacterAnimator.SetBool(movingParamaterRight, false);
                character.CharacterAnimator.SetBool(movingParamaterLeft, false);
                character.CharacterAnimator.SetBool(movingParamaterUp, false);
                character.CharacterAnimator.SetBool(movingParamaterDown, false);
            }
        }
    }

    public void ResetSpeed()
    {
        MoveSpeed = walkSpeed;
    }
}
