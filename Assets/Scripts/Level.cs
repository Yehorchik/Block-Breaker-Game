using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    [SerializeField] int breakeableBlocks;
    SceneLoader sceneloader;
    private void Start()
    {
        sceneloader = FindObjectOfType<SceneLoader>();
    }

    public void CountBreakebleBlocks()
    {
        breakeableBlocks++;

    }

    public void BlockDestroy()
    {
        breakeableBlocks--;
        if(breakeableBlocks <= 0)
        {
            sceneloader.LoadNextScene();
        }
    }
}
