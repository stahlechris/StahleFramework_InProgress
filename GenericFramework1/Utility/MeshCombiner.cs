using UnityEngine;

namespace Stahle.Utility
{
    //Put this on a object that needs all of its meshes (with same materials) combined!
    [RequireComponent(typeof(MeshFilter))]
    public class MeshCombiner : MonoBehaviour
    {
        Matrix4x4 myTransformMatrix;
        MeshCollider myMeshCollider;

        private void CombineAllMeshesIntoOneParentMesh()
        {
            //cache local values in matrix form to offset calculations
            myTransformMatrix = transform.worldToLocalMatrix;

            //Do magic
            MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
            CombineInstance[] combine = new CombineInstance[meshFilters.Length];
            Mesh finalMesh = new Mesh();

            //Debug.Log(name + " is combining " + meshFilters.Length + meshFilters[1].name + " meshes!");

            for (int i = 0; i < meshFilters.Length; i++)
            {
                //combine all meshes - this parents and all children
                combine[i].subMeshIndex = 0;
                combine[i].mesh = meshFilters[i].sharedMesh;
                combine[i].transform = myTransformMatrix * meshFilters[i].transform.localToWorldMatrix;
                //Don't disable the parents meshCollider
                if (i != 0)
                {
                    meshFilters[i].GetComponent<MeshCollider>().enabled = false;
                }
            }

            finalMesh.CombineMeshes(combine);
            GetComponent<MeshFilter>().sharedMesh = finalMesh;


            if (myMeshCollider != null)
            {
                myMeshCollider.sharedMesh = finalMesh;
            }
            else
            {
                myMeshCollider = gameObject.AddComponent<MeshCollider>();
                myMeshCollider.sharedMesh = finalMesh;
                myMeshCollider.convex = true;
            }
        }
    }
}