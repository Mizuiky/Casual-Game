using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelPiece : MonoBehaviour
{
    [SerializeField]
    private GameObject _plane;

    private float _height = -0.5f;

    public Vector3 Size
    {
        get => _size;
    }

    private Vector3 _size;

    public void Init()
    {
        _size = _plane.GetComponent<Renderer>().bounds.size;    
    }

    public void SetPosition(Vector3 pieceTransform)
    {
        pieceTransform.y = _height;

        transform.position = pieceTransform;
    }
}
