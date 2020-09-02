using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialRandomizer : MonoBehaviour
{

    [SerializeField]
    private Material[] _materials;
    [SerializeField]
    private Renderer _renderer;

    public void Start()
    {
        ChangeMaterial();
    }

    public void Reset()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void ChangeMaterial()
    {
        _renderer.material = SelectRandomMaterial();
    }

    private Material SelectRandomMaterial()
    {
        return _materials[Random.Range(0, _materials.Length)];
    }

}

