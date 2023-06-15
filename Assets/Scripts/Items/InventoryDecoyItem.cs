using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDecoyItem : InventoryItem
{
    [SerializeField]private GameObject _decoyPrefab;

    public override void OnUse()
    {
        GameObject decoyObj = Instantiate(_decoyPrefab);
        decoyObj.transform.position = GameObject.FindWithTag("Player").transform.position;
        Destroy(this.gameObject);
    }
}
