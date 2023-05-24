using UnityEngine;
using UnityEditor;
using Asteroids.Data;

namespace Asteroids.Editor
{
    public class FileManagementMenu
    {
        [MenuItem("Asteroids/Files/Delete Files")]
        private static void DeleteFiles()
        {
            FileUtility.DeleteAll();
            Debug.Log("Deleted all files.");
        }

        [MenuItem("Asteroids/Files/Open File Directory")]
        private static void OpenFileDirectory() => EditorUtility.RevealInFinder(FileUtility.FileDirectory);
    }
}