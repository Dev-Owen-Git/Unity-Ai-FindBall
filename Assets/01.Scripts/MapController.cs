using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [ SerializeField ] MeshRenderer[] meshs;

    public void Success()
    {
        for ( int i = 0; i < meshs.Length; i++ )
        {
            meshs[i].material.color = Color.green;
        }
    }

    public void Fail()
    {
        for ( int i = 0; i < meshs.Length; i++ )
        {
            meshs[i].material.color = Color.red;
        }
    }
}
