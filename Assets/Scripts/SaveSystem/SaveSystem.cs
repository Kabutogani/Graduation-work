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
        return FileManager.ExistsFolderInDataFolder(saveDataPath);
    }

    public static bool ExistsSaveDataFile(int i){
        return FileManager.ExistsFileInDataFolder(saveDataPath + "/" + saveDataName + i + ".txt");
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
}
