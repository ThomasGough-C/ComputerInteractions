using UnityEngine;

public class ComputerInteractions : MonoBehaviour
{
    [Header("References")]
    // Reference to the CameraSwitcher that handles switching between cameras.
    public CameraSwitcher cameraSwitcher;
    
    [Header("Interaction Settings")]
    public KeyCode interactKey = KeyCode.E; // The key to interact.
    private bool playerInRange = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Player in range. Press " + interactKey + " to access the computer.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("Player left the computer area.");
        }
    }

    void Update()
{
    if (playerInRange && Input.GetKeyDown(interactKey))
    {
        if (cameraSwitcher != null)
        {
            cameraSwitcher.SwitchCamera(transform); // Pass THIS cube’s position for overhead view
        }
        else
        {
            Debug.LogWarning("CameraSwitcher not set!");
        }
    }
}

}
