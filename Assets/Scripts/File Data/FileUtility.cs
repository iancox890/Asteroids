using UnityEngine;
using System.IO;

namespace AsteroidsApp.FileData
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

        ///<summary>Returns the full path of a file contained in the files directory.</summary>
        public static string GetPath(string fileName)
        {
            return $"{FileDirectory}/{fileName}.txt";
        }

        ///<summary> Deletes the data contained within IFileData.</summary>
        public static void DeleteFile(IFile fileData)
        {
            File.Delete(GetPath(fileData.FileName));
        }

        public static void DeleteAll()
        {
            string[] files = Directory.GetFiles(FileDirectory);
            for (int i = 0; i < files.Length; i++)
            {
                File.Delete(files[i]);
            }
        }

        ///<summary> Writes data of type IFileData to the a file in the files directory.</summary>
        public static void WriteToFile<T>(T fileData) where T : IFile
        {
            File.WriteAllText(GetPath(fileData.FileName), JsonUtility.ToJson(fileData));
        }

        ///<summary>Gets a file of type IFileData. If no file of this type is found, null is returned.</summary>
        public static T GetFile<T>(string fileName) where T : IFile
        {
            string path = GetPath(fileName);
            if (File.Exists(path) == false) return default(T);

            return JsonUtility.FromJson<T>(File.ReadAllText(path));
        }
    }
}