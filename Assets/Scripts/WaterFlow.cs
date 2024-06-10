using UnityEngine;

public class WaterFlow : MonoBehaviour
{
    public float scrollSpeedX = 0.1f; // Speed of the water flow in the X direction
    public float scrollSpeedY = 0.1f; // Speed of the water flow in the Y direction

    private Renderer rend;
    private Vector2 savedOffset;

    void Start()
    {
        // Get the Renderer component attached to the GameObject
        rend = GetComponent<Renderer>();
        // Save the initial offset value
        savedOffset = rend.material.GetTextureOffset("_MainTex");
    }

    void Update()
    {
        // Calculate the new offset value based on the time and scroll speed
        float offsetX = Mathf.Repeat(Time.time * scrollSpeedX, 1);
        float offsetY = Mathf.Repeat(Time.time * scrollSpeedY, 1);

        // Apply the new offset value to the material
        Vector2 newOffset = new Vector2(savedOffset.x + offsetX, savedOffset.y + offsetY);
        rend.material.SetTextureOffset("_MainTex", newOffset);
    }
}
