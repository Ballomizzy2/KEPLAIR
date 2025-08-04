using UnityEngine;
using System.Collections.Generic;
using SplineMesh;
using Unity.VisualScripting;


public class PathDesigner : MonoBehaviour
{
    [SerializeField][Range(0,100)]private float completion;
    [SerializeField] private GameObject pathBulb;
    [SerializeField]private Material pathCompleteMaterial, pathIncompleteMaterial;
    
    [SerializeField]
    private List<MeshRenderer> majorPathParts, minorPathParts;
    
    private Spline spline;
    
    public static List<MeshRenderer> GetAllMeshRenderers(GameObject parent)
    {
        List<MeshRenderer> result = new List<MeshRenderer>();
        CollectMeshRenderersRecursive(parent.transform, result);
        return result;
    }

    
    private static void CollectMeshRenderersRecursive(Transform parent, List<MeshRenderer> list)
    {
        MeshRenderer renderer = parent.GetComponent<MeshRenderer>();
        if (renderer != null)
        {
            list.Add(renderer);
        }

        foreach (Transform child in parent)
        {
            CollectMeshRenderersRecursive(child, list);
        }
    }

    // Example usage
    void Start()
    {
        spline = GetComponent<Spline>();
        //Debug.Log($"Found {renderers.Count} MeshRenderers.");
        //DrawPath();
    }

    /*private void DrawPath() 
    {
        Material mat = pathCompleteMaterial;
        for (int i = 0; i < majorPathParts.Count; i++) 
        {
            // completion maths
            if( ((float)i / majorPathParts.Count) * 100 > completion )
                mat = pathCompleteMaterial;
            else
                mat = pathIncompleteMaterial;
            majorPathParts[i].material = mat;
            minorPathParts[i].material = mat;
        }
    }*/
}
