using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Variables publicas
    public PlayerMovement playerMovement;
    public CameraMovement cameraMovement;
    public Interactor interactor;
    public PlayerAnimations animations;
    
    // Variables privadas
    private bool isDead = false;


    // Singleton
    public static Player Instance { get; private set; }

    private void Awake()
    {
        // Verificacion de Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        Application.targetFrameRate = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            cameraMovement.Rotation();
            interactor.Interaction();
        }
        else
        {
            cameraMovement.LookAtTarget();
        }
        
    }

    private void FixedUpdate()
    {
        if (!isDead)
        {
            playerMovement.Movement();
            animations.CheckSpeed();
        }
        
    }

    public void IsDead()
    {
        isDead = true;
    }
}
