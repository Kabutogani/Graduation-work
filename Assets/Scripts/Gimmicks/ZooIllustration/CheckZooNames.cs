using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class CheckZooNames
{
    public static bool CheckZooName(string[] nameFileArray, string inputText){
        bool b = nameFileArray.Contains(inputText);
        return b;
    }
}
