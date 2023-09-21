using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveSystem
{
    private static string saveDataPath = Application.dataPath + "/Save";
    private static string saveDataName = "Save";
    public static string currentLoadSaveDataPath;

    public static bool ExistsSaveDataFolder(){
        return FileManager.ExistsFolder(saveDataPath);
    }

    public static bool ExistsSaveDataFile(int dataNum){
        return FileManager.ExistsFile(saveDataPath + "/" + saveDataName + dataNum + ".txt");
    }

    public static void CreateSaveDataFolder(){
        FileManager.CreateFolder(saveDataPath);
    }

    public static void CreateSaveDataFile(int dataNum){
        FileManager.CreateFile(saveDataPath + "/" + saveDataName + dataNum + ".txt");
    }

    public static string GetSaveDataPath(int dataNum){
        return saveDataPath + "/" + saveDataName + dataNum + ".txt";
    }

    public static void Save(){
        
    }

    public static string LoadAll(int dataNum){
        string data = File.ReadAllText(saveDataPath + "/" + saveDataName + dataNum + ".txt");
        return data;
    }

    public static string LoadLine(int dataNum, int lineNum){
        string[] data = TextLoad.TextSplitToLine(LoadAll(dataNum));
        return data[lineNum];
    }
}
