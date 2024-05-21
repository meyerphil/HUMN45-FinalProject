using UnityEngine;
using System.Collections;

public class PulseEffect : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Color startColor = Color.white; // Start color
    public Color endColor = Color.yellow; // End color
    public float duration = 1f;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(Pulse());
    }

    IEnumerator Pulse()
    {
        float timeElapsed = 0f;

        while (true) // Loop indefinitely for continuous pulsating effect
        {
            while (timeElapsed < duration)
            {
                timeElapsed += Time.deltaTime;

                // Calculate the current lerped color based on the time elapsed
                float t = timeElapsed / duration;
                Color lerpedColor = Color.Lerp(startColor, endColor, Mathf.PingPong(t, 1));

                // Apply the color to the sprite renderer
                spriteRenderer.color = lerpedColor;

                yield return null; // Wait for the next frame
            }

            // Swap start and end colors for the next iteration
            Color temp = startColor;
            startColor = endColor;
            endColor = temp;

            timeElapsed = 0f; // Reset time elapsed for the next iteration
        }
    }
}