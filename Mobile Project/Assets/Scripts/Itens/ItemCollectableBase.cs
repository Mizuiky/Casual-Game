using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableBase : MonoBehaviour
{
    [Header("Item Fields")]

    [SerializeField]
    private Collider _itemCollider;

    [SerializeField]
    private GameObject _graphic;

    [SerializeField]
    protected string _tagToCompare;

    protected PlayerController _player;

    private void Start()
    {
        Init();    
    }

    protected virtual void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag(_tagToCompare))
        {
            _player = collider.GetComponent<PlayerController>();

            if (_player == null)
            {
                _player = collider.GetComponentInParent<PlayerController>();

                if(_player != null)
                    Collect();
            }
            else
            {
                Collect();
            }            
        }
    }

    public virtual void Collect()
    {
        HideItem();
        OnCollect();
    }

    public virtual void HideItem()
    {
        _itemCollider.enabled = false;

        if(_graphic != null)
            _graphic.SetActive(false);
    }

    public virtual void OnCollect() { }

    private void Init()
    {
        _itemCollider.enabled = true;
        _graphic.SetActive(true);
    }
}
