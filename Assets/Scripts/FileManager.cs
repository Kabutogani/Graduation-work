using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class FileManager
{
    public static bool ExistsFolder(string path){
        return Directory.Exists(path);
    }

    public static bool ExistsFile(string path){
        return File.Exists(path);
    }

    public static void CreateFolder(string path){
        Directory.CreateDirectory(path);
    }

    public static void CreateFile(string path){
        File.Create(path);
    }
}
