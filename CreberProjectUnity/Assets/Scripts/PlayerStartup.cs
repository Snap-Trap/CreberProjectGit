using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartup : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public PlayerCamera playerCamera;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerCamera = GetComponent<PlayerCamera>();

        playerMovement.SetActive(false);
    }
}
