using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private bool canMove = true;
    [SerializeField] private bool playerCamera = true;

    private Character playableCharacter;

    private void Start()
    {
        playableCharacter = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
        GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>().enabled = canMove;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().enabled = playerCamera;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioListener>().enabled = playerCamera;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ReviveCharacter();
        }
    }

    private void ReviveCharacter()
    {
        if (playableCharacter.GetComponent<Health>().CurrentHealth <= 0)
        {
            playableCharacter.GetComponent<Health>().Revive();
            playableCharacter.transform.position = spawnPosition.position;
        }
    }
}
