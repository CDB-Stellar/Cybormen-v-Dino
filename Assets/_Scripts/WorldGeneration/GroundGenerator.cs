using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    public float tileOffset;
    public GameObject[] groundTypes;

    WorldTextureGenerator textureGenerator;
    void Awake()
    {
        textureGenerator = GetComponent<WorldTextureGenerator>();
    }
    private void Start()
    {
        GenerateGround();
    }
    private void GenerateGround()
    {
        Texture2D worldTexture = textureGenerator.GenerateTexture();

        int width = worldTexture.width;
        int height = worldTexture.height;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                float pixelValue = worldTexture.GetPixel(x, y).r; // color not important as they are all the value
                GroundType ground;

                if (pixelValue == 0.0f) ground = GroundType.Rocky;
                else if (pixelValue == 1f) ground = GroundType.Forrest;
                else ground = GroundType.Field;


                Vector3 placePostion = new Vector3(x * tileOffset - width * tileOffset / 2, 0f, y * tileOffset - height * tileOffset / 2);

                PlaceGroundTile(placePostion, ground);
            }
        }
    }
    private void PlaceGroundTile(Vector3 position, GroundType groundType)
    {
        switch (groundType)
        {
            default:
            case GroundType.Field:
                Instantiate(groundTypes[0], position, Quaternion.identity);
                break;
            case GroundType.Forrest:
                Instantiate(groundTypes[1], position, Quaternion.identity);
                break;
            case GroundType.Rocky:
                Instantiate(groundTypes[2], position, Quaternion.identity);
                break;            
        }
    }   
}
