using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface ILoadableSaveData{
    void DataLoad(List<string> datas);
    void ChangeDataValue(int localSaveNum , string data);
}
