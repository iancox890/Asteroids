using UnityEngine;

namespace AsteroidsApp.FileData
{
    /// <summary>
    /// Holds the data for the players total points earned.
    /// </summary>
    [System.Serializable]
    public class PointsData : IFile
    {
        private string _fileName;
        public string FileName => _fileName;

        [SerializeField] private int _points;
        public int Points { get => _points; set => _points = value; }

        public PointsData(string fileName)
        {
            _fileName = fileName;
        }

        public void Save()
        {
            FileUtility.WriteToFile(this);
        }
    }
}