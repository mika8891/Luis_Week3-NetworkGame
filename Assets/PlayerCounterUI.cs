using UnityEngine;
using Unity.Netcode;
using TMPro;


public class PlayerCounterUI : MonoBehaviour
{
    public TMP_Text playerCounterText;

    void Update()
    {
      if (NetworkManager.Singleton == null) return;
      int count = NetworkManager.Singleton.ConnectedClients.Count;
      playerCounterText.text = "Players: " + count;   
    }
}
