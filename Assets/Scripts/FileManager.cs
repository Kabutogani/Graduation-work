using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class FileManager
{
    public static bool ExistsFolderInDataFolder(string path){
        return Directory.Exists(Application.dataPath + "/" + path);
    }

    public static bool ExistsFileInDataFolder(string path){
        return File.Exists(Application.dataPath + "/" + path);
    }

    public static void CreateFolder(string path){
        Directory.CreateDirectory(path);
    }

    public static void CreateFile(string path){
        File.Create(path);
    }
}
