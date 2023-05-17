using UnityEngine;

namespace AsteroidsApp.FileManagement
{
    /// <summary>
    /// Holds the data for the players total points earned.
    /// </summary>
    [System.Serializable]
    public class PlayerPointsFile : IFile
    {
        public string FileName => "PlayerPoints";

        [SerializeField] private int _points;
        public int Points { get => _points; set => _points = value; }

        public void Save()
        {
            FileUtility.WriteToFile(this);
        }
    }
}