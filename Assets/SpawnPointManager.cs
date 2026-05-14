using UnityEngine;
using Unity.Netcode;
using System;
using Unity.VisualScripting;
public class SpawnPointManager : NetworkBehaviour
{
    private static int nextSpawnIndex;

    public override void OnNetworkSpawn()
    {
        if (!IsServer)
        {
            return;
        }

        GameObject[] spawnPointObjects = GameObject.FindGameObjectsWithTag("SpawnPoint");
        if (spawnPointObjects.Length == 0)
        {
            Debug.Log("no spawnpoiint detected");
            return;

        }

        Transform selectedSpawnPoint = spawnPointObjects[nextSpawnIndex].transform;
        CharacterController characterController = GetComponent<CharacterController>();
        if (characterController != null)
        {
            characterController.enabled = false;

        }
        transform.position = selectedSpawnPoint.position;
        transform.rotation = selectedSpawnPoint.rotation;

        if(characterController != null)
        {
            characterController.enabled = true;

        }
        nextSpawnIndex++;
        if(nextSpawnIndex >= spawnPointObjects.Length)
        {
            nextSpawnIndex = 0;
        }
    }

}
