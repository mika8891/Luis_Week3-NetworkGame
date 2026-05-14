using UnityEngine;
using Unity.Netcode;
public class LocalPlayerCameraTarget : NetworkBehaviour
{
    public override void OnNetworkSpawn()
    {
        if (!IsOwner)
        {
            return;
        }
        TopDownCameraFollow cameraFollow = Camera.main.GetComponent<TopDownCameraFollow>();
        
        if(cameraFollow != null)
        {
            Debug.Log("camera is existing.");
            cameraFollow.SetTarget(transform);
        }
    }
}
