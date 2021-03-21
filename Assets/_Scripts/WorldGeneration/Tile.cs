using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public List<GameObject> resourceNodes;
    [Range(0f, 100f)]
    public List<float> resourceSpawnThreshold;

    // Start is called before the first frame update
    void Start()
    {       
        //check if near the centre
        if (!(transform.position.x <= 4 && transform.position.x >= -4 && transform.position.z <= 4 && transform.position.z >= -4))
        {
            float random;
            //Debug.Log(random);
            for (int i = 0; i < resourceSpawnThreshold.Count; i++)
            {
                random = Random.Range(0, 100f);
                if (random < resourceSpawnThreshold[i])
                {

                    Quaternion rotation = Random.rotation;

                    
                    Vector3 translation = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));

                    Instantiate(resourceNodes[i], transform.position + translation, new Quaternion(0f, rotation.y, 0f, rotation.w), transform);
                    break;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
