using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveSystem
{
    public static string saveDataPath = Application.dataPath + "/Save";
    public static string saveDataName = "Save";
    public static string inventoryDataName = "Inventory";
    public static string CurrentLoadSaveDataPath;
    public static string CurrentLoadInventoryDataPath;
    public static int CurrentLoadDataNum;
    public static SaveLoader[] SaveLoaders = new SaveLoader[200];

    public static bool ExistsSaveDataFolder(){
        return FileManager.ExistsFolder(saveDataPath);
    }

    public static bool ExistsSaveDataFile(int dataNum){
        return FileManager.ExistsFile(saveDataPath + "/" + saveDataName + dataNum + ".txt");
    }

    public static bool ExistsInventoryDataFile(int dataNum){
        return FileManager.ExistsFile(saveDataPath + "/" + inventoryDataName + dataNum + ".txt");
    }

    public static void CreateSaveDataFolder(){
        FileManager.CreateFolder(saveDataPath);
    }

    public static void CreateSaveDataFile(int dataNum){
        string[] nullDatas = new string[200];
        for(int i = 0; i < nullDatas.Length; i++){
            nullDatas[i] = "";
        }
        Debug.Log("wirteNull");
        File.WriteAllLines(SaveSystem.saveDataPath + "/" + SaveSystem.saveDataName + dataNum + ".txt", nullDatas);
    }

    public static void CreateInventoryDataFile(int dataNum){
        string[] nullDatas = new string[200];
        for(int i = 0; i < nullDatas.Length; i++){
            nullDatas[i] = "";
        }
        File.WriteAllLines(SaveSystem.saveDataPath + "/" + SaveSystem.inventoryDataName + dataNum + ".txt", nullDatas);
    }

    public static string GetSaveDataPath(int dataNum){
        return saveDataPath + "/" + saveDataName + dataNum + ".txt";
    }

    public static string GetInventoryDataPath(int dataNum){
        return saveDataPath + "/" + inventoryDataName + dataNum + ".txt";
    }

    public static void Save(){
        string[] tempDatas = TextLoad.TextSplitToLine(LoadSaveDataAll(CurrentLoadDataNum));
        TimeCounter.instance.SetTime();
        for(int i = 0; i < SaveLoaders.Length; i++){
            if(SaveLoaders[i] != null){
                for(int n = 0; n < SaveLoaders[i].saveNumbers.Length; n++){
                    tempDatas[SaveLoaders[i].saveNumbers[n]] = SaveLoaders[i].tempDatas[n];
                    //Debug.Log("i="+i+", n="+n+ "がお呼ばれ！ 値は "+SaveLoaders[i].tempDatas[n],SaveLoaders[i].gameObject);
                }
            }
        }
        File.WriteAllLines(CurrentLoadSaveDataPath, tempDatas);
        InventorySave();
        Debug.Log("DataSaved!!");
    }

    private static void InventorySave(){
        string[] tempDatas = TextLoad.TextSplitToLine(LoadInventoryDataAll(CurrentLoadDataNum));
        // for(int i = 0; i < SaveLoaders.Length; i++){
        //     if(SaveLoaders[i] != null){
        //         for(int n = 0; n < SaveLoaders[i].saveNumbers.Length; n++){
        //             tempDatas[SaveLoaders[i].saveNumbers[n]] = SaveLoaders[i].tempDatas[n];
        //         }
        //     }
        // }
        tempDatas = Inventory.instance.GetAllItemInInventory();
        File.WriteAllLines(CurrentLoadInventoryDataPath, tempDatas);
        Debug.Log("InventorySaved!!");
    }

    public static string LoadSaveDataAll(int dataNum){
        string data = File.ReadAllText(saveDataPath + "/" + saveDataName + dataNum + ".txt");
        return data;
    }

    public static string LoadInventoryDataAll(int dataNum){
        string data = File.ReadAllText(saveDataPath + "/" + inventoryDataName + dataNum + ".txt");
        return data;
    }

    public static string LoadLine(int dataNum, int lineNum){
        string[] data = TextLoad.TextSplitToLine(LoadSaveDataAll(dataNum));
        return data[lineNum];
    }

    public static string LoadLine(int lineNum){
        string[] data = TextLoad.TextSplitToLine(LoadSaveDataAll(CurrentLoadDataNum));
        return data[lineNum];
    }
}
