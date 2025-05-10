using Meta.XR.MRUtilityKit; // ✅ 通常 EffectMesh 属于这个命名空间
using UnityEngine;

[RequireComponent(typeof(EffectMesh))]
[RequireComponent(typeof(MeshCollider))]
[RequireComponent(typeof(MeshFilter))]
public class EffectMeshColliderBinder : MonoBehaviour
{
    void Start()
    {
        var meshFilter = GetComponent<MeshFilter>();
        var meshCollider = GetComponent<MeshCollider>();

        if (meshFilter != null && meshCollider != null)
        {
            meshCollider.sharedMesh = meshFilter.sharedMesh;
        }
    }
}

