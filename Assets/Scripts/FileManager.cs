using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class FileManager
{
    public static bool ExistsFolderInDataFolder(string path){
        return System.IO.Directory.Exists(Application.dataPath + "/" + path);
    }

    public static bool ExistsFileInDataFolder(string path){
        return System.IO.File.Exists(Application.dataPath + "/" + path);
    }

    public static void CreateFolder(string path){
        System.IO.Directory.CreateDirectory(path);
    }
}
