using UnityEngine;

public class ProximityLightIntensity : MonoBehaviour
{
    public Light myLight;               // The light to control
    public Transform player;            // Reference to the player's transform
    public float maxIntensity = 0f;     // Maximum light intensity
    public float minIntensity = 0f;     // Minimum light intensity
    public float maxDistance = 0f;     // The distance at which the light is at minIntensity
    public Color farColor = Color.green;
    public Color closeColor = Color.red;

    void Update()
    {
        if (myLight != null && player != null)
        {
            float distance = Vector3.Distance(transform.position, player.position);
            Debug.DrawLine(transform.position, player.position, Color.yellow);


            // Clamp distance to maxDistance so we don't go below minIntensity
            float t = Mathf.Clamp01(1 - (distance / maxDistance));

            // Lerp intensity based on how close the player is
            myLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, t);
            myLight.color = Color.Lerp(farColor, closeColor, t);
            // Debug.Log($"Light intensity: {myLight.intensity}");
        }
    }
}
