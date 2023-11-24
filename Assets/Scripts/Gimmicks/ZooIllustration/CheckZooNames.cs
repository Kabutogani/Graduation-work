using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class CheckZooNames
{
    public static bool CheckZooName(string[] nameFileArray, string inputText){
        bool b = nameFileArray.Contains(inputText);

        for (int i = 0; i < nameFileArray.Length; i++)
        {
            if(nameFileArray[i] == inputText){
                b = true;
            }

        }

        return b;
    }
}
