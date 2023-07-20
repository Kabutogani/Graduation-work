using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugStateUI : MonoBehaviour
{
    [SerializeField] private Monkey _monkey;
    private Text _text;
    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        string t = "EnemyState : " + _monkey._currentMode;
        _text.text = t;
    }
}
