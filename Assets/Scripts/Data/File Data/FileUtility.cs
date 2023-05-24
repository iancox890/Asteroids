using UnityEngine;
using System.IO;

namespace Asteroids.Data
{
    /// <summary>
    /// Utility class for saving and getting game files in JSON.
    /// </summary>
    public static class FileUtility
    {
        public static readonly string FileDirectory;

        static FileUtility()
        {
            FileDirectory = Directory.CreateDirectory(Application.persistentDataPath + "/Files").FullName;
        }

        public static string GetPath(string fileName)
        {
            return $"{FileDirectory}/{fileName}.txt";
        }

        public static void DeleteFile(string fileName)
        {
            File.Delete(GetPath(fileName));
        }

        public static void DeleteAll()
        {
            string[] files = Directory.GetFiles(FileDirectory);
            for (int i = 0; i < files.Length; i++)
            {
                File.Delete(files[i]);
            }
        }

        public static void WriteToFile<T>(T fileData, string fileName)
        {
            File.WriteAllText(GetPath(fileName), JsonUtility.ToJson(fileData));
        }

        public static T GetFile<T>(string fileName)
        {
            string path = GetPath(fileName);
            if (File.Exists(path) == false) return default(T);

            return JsonUtility.FromJson<T>(File.ReadAllText(path));
        }
    }
}