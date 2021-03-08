using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnplacedBuilding : MonoBehaviour
{
    public GameObject prefab;
    public LayerMask placeLayer;
    public LayerMask collisionLayer;
    public string cameraName;
    public Vector3 detectionCubeSize;
    public Vector3 detectionCubeOffset;
    public Material green;
    public Material red;
    

    private MeshRenderer[] meshs;
    private new Camera camera; 

    private RaycastHit hit;
    private bool canPlace;
    private Vector3 boxCastPosition;

    private void Awake()
    {
        meshs = GetAllMeshesInPrefab();
        camera = GameObject.Find(cameraName).GetComponent<Camera>();
        
        boxCastPosition = new Vector3(transform.position.x + detectionCubeOffset.x,
            transform.position.y + detectionCubeOffset.y + detectionCubeSize.y / 2,
            transform.position.z + detectionCubeOffset.y);

    }
    // Update is called once per frame
    void Update()
    {
        if (IsColliding())
        {
            AssignMaterialToAllMeshes(red);
            canPlace = false;
        }
        else
        {
            AssignMaterialToAllMeshes(green);
            canPlace = true;
        }

        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 5000000.0f, placeLayer))
        {
            transform.position = new Vector3(Mathf.RoundToInt(hit.point.x), Mathf.RoundToInt(hit.point.y), Mathf.RoundToInt(hit.point.z));
        }
        if (Input.GetMouseButtonDown(0) && canPlace)
        {
            Destroy(gameObject);
        }
        else if(Input.GetMouseButtonDown(1))
        {
            Destroy(gameObject);
        }
    }
    private bool IsColliding()
    {
        Collider[] collisions = Physics.OverlapBox(boxCastPosition + transform.position,
            detectionCubeSize/2,
            Quaternion.identity,
            collisionLayer);
        if (collisions.Length > 0) return true;
        else return false;       
    }
    private void AssignMaterialToAllMeshes(Material newMaterial)
    {
        foreach (MeshRenderer mesh in meshs)        
            mesh.material = newMaterial;
        
    }
    private MeshRenderer[] GetAllMeshesInPrefab()
    {
         return GetComponentsInChildren<MeshRenderer>(true);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(new Vector3(transform.position.x + detectionCubeOffset.x,
            transform.position.y + detectionCubeOffset.y + detectionCubeSize.y / 2,
            transform.position.z + detectionCubeOffset.z), detectionCubeSize);
    }
}
