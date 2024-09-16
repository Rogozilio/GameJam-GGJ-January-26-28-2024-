using System;
using System.Collections.Generic;
using DefaultNamespace.Inventory;
using UnityEngine;

public class InspectionObject : MonoBehaviour
{
    public List<Item> items;
    public List<GameObject> objs;
    public float zoomValue;

    private GameObject _activeObj;
    private bool _isInspectobject;
    private float _speed = 1000f;

    private Camera3rd _camera3d;

    private void Start()
    {
        _camera3d = FindObjectOfType<Camera3rd>();
    }

    public void StartInspect(Item item)
    {
        if (_activeObj)
        {
            _camera3d.isDisabledAll = false;
            _activeObj.SetActive(false);
            _activeObj = null;
            return;
        }
        for(var i = 0; i < items.Count;i++)
        {
            if (items[i] == item)
            {
                MoveItemToCloseCamera(objs[i]);
            }
        }
    }

    private void MoveItemToCloseCamera(GameObject obj)
    {
        obj.SetActive(true);
        obj.transform.position = Camera.main.transform.position + Camera.main.transform.forward * zoomValue;
        _activeObj = obj;
        _camera3d.isDisabledAll = true;
    }

    private void Update()
    {
        if(!_activeObj || !_activeObj.activeSelf) return;
        
        float horizontal = Input.GetAxis("Mouse X");
        float vertical = Input.GetAxis("Mouse Y");

        _activeObj.transform.Rotate(0, horizontal * _speed * Time.fixedDeltaTime, -vertical * _speed * Time.fixedDeltaTime, Space.World);
    }
}