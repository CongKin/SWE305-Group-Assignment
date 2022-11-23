using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : CharacterComponents
{
    [SerializeField] private float walkSpeed = 6f;

    // A property is a method to store / return a value. In this case, its to controls our current move speed
    public float MoveSpeed { get; set; }
    
    Vector2 movementSpeed;

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
        movementSpeed = movementNormalized * MoveSpeed;
        controller.SetMovement(movementSpeed);
    }

    private void UpdateAnimations()
    {
        character.CharacterAnimator.SetFloat("Horizontal", horizontalInput);
        character.CharacterAnimator.SetFloat("Vertical", verticalInput);
        character.CharacterAnimator.SetFloat("Speed", movementSpeed.sqrMagnitude);
    }

    public void ResetSpeed()
    {
        MoveSpeed = walkSpeed;
    }
}
