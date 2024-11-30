using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
    // Reference to the Image component
    private Image image;

    // Speed of color change
    public float colorChangeSpeed = 1f;

    private void Start()
    {
        image = GetComponent<Image>();
    }
    void Update()
    {
        // Calculate color change amount based on time
        float colorChangeAmount = Mathf.Sin(Time.time * colorChangeSpeed);

        // Convert color change amount to a value between 0 and 1
        float t = Mathf.InverseLerp(-1f, 1f, colorChangeAmount);

        // Interpolate between white and yellow based on the color change amount
        Color lerpedColor = Color.Lerp(Color.white, Color.yellow, t);

        // Apply the new color to the Image component's color property
        image.color = lerpedColor;
    }
}
