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
    private ResourceAmounts constructionCost;
    private Transform parent;

    private void Awake()
    {
        meshs = GetAllMeshesInPrefab();
        camera = GameObject.Find(cameraName).GetComponent<Camera>();
        constructionCost = GetComponent<ResourceAmounts>();
        
        boxCastPosition = new Vector3(transform.position.x + detectionCubeOffset.x,
            transform.position.y + detectionCubeOffset.y + detectionCubeSize.y / 2,
            transform.position.z + detectionCubeOffset.y);


        parent = camera.transform.parent;
    }
    private void Start()
    {
        GameEvents.current.OnPlaceBuilding += PlaceDownBuilding;
        GameEvents.current.OnCancelBuilding += CancelUnplacedBuilding;
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

        //Ray ray = camera.ScreenPointToRay(transform.localPosition);
        //if (Physics.Raycast(ray, out hit, 5000000.0f, placeLayer))
        //{
        //    transform.position = new Vector3(Mathf.RoundToInt(hit.point.x), Mathf.RoundToInt(hit.point.y), Mathf.RoundToInt(hit.point.z));
        //}
        transform.position = new Vector3(Mathf.Round(parent.position.x), Mathf.Round(parent.position.y), Mathf.Round(parent.position.z));        
    }
    private void PlaceDownBuilding()
    {
        if (canPlace)
        {
            PlayerResourceEventArgs resourceCost = new PlayerResourceEventArgs(-constructionCost.wood, -constructionCost.stone, -constructionCost.iron, -constructionCost.electronics);
            GameEvents.current.OnIncrementResource(this, resourceCost);

            Instantiate(prefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }        
    }
    private void CancelUnplacedBuilding()
    {
        Destroy(gameObject);
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
        Gizmos.color = Color.red;
        Gizmos.DrawRay(camera.ScreenPointToRay(new Vector3(0f, 0f, 1f)));
    }
    private void OnDestroy()
    {
        GameEvents.current.OnPlaceBuilding -= PlaceDownBuilding;
        GameEvents.current.OnCancelBuilding -= CancelUnplacedBuilding;
    }
}
