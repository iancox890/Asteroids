using UnityEngine;

namespace AsteroidsApp.FileData
{
    /// <summary>
    /// Holds data for a given store item. (purchased state)
    /// </summary>
    public class StoreItemData : IFile
    {
        private string _fileName;
        public string FileName => _fileName;

        [SerializeField] private bool _isPurchased;
        public bool IsPurchased { get => _isPurchased; set => _isPurchased = value; }

        public StoreItemData(string fileName)
        {
            _fileName = fileName;
        }

        public void Save()
        {
            FileUtility.WriteToFile(this);
        }
    }
}