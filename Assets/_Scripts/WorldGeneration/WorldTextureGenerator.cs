using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTextureGenerator : MonoBehaviour
{
    public int centreSize = 10;

    public int xOffset = 0;
    public int yOffset = 0;
    public float scale = 5f;
    public int width = 100;
    public int height = 100;
    public float whiteThreshold = 0.6f;
    public float blackThreshold = 0.25f;

    public Texture2D GenerateTexture()
    {
        Texture2D newTexture = new Texture2D(width, height);

        // GENERATE A PERLIN NOISE TEXTURE
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Color colour = CalculateColour(x, y);
                newTexture.SetPixel(x, y, colour);
            }
        }

        newTexture.Apply();
        return newTexture;
    }
    private Color CalculateColour(int x, int y)
    {
        float xCoord = (float)(x + xOffset) / (width) * scale;
        float yCoord = (float)(y + yOffset) / (height) * scale;

        float sample = Mathf.PerlinNoise(xCoord, yCoord);

        if (x > width / 2 - centreSize && x < width / 2 + centreSize && y > height / 2 - centreSize && y < height / 2 + centreSize)
        {
            sample = 0.5f;
        }
        else
        {
            if (sample >= whiteThreshold)
                sample = 1f;
            else if (sample <= blackThreshold)
                sample = 0f;
            else
                sample = 0.5f;
        }
        return new Color(sample, sample, sample);
    }
}
