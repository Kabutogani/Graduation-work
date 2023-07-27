using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TextLoad
{
    public static string Load(TextAsset asset){
        string t = asset.text;
        return t;
    }

    public static string[] TextSplit(string text, string sp){
        string[] textArray;
        textArray = text.Split(sp);
        return textArray;
    }

    public static string[] TextSplit(string text, char sp){
        string[] textArray;
        textArray = text.Split(sp);
        return textArray;
    }
}
