using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public string ItemName;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();

        text.text = ItemName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void OnUse(){
        
    }
}
