using UnityEngine;

public class SplitScreen : MonoBehaviour
{
    public Camera player1Camera;
    public Camera player2Camera;
    public float splitScreenRatio = 0.5f; // Ratio of the screen for player 1

    void Start()
    {
        AdjustCameras();
    }

    void AdjustCameras()
    {
        if (player1Camera != null && player2Camera != null)
        {
            // Set player 1 camera viewport
            player1Camera.rect = new Rect(0f, 0f, splitScreenRatio, 1f);

            // Set player 2 camera viewport
            player2Camera.rect = new Rect(splitScreenRatio, 0f, 1f - splitScreenRatio, 1f);
        }
        else
        {
            Debug.LogError("Player cameras are not assigned!");
        }
    }
}