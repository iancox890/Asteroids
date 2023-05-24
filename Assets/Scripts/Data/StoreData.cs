using UnityEngine;

namespace Asteroids.Data
{
    /// <summary>
    /// Base class for all store items. 
    /// </summary>
    public class StoreData : ScriptableObject
    {
        [Header("Store Data")]
        [SerializeField] private string _fileName;
        [Space(2)]
        [SerializeField] private int _price;
        public int Price => _price;

        private StoreFile _storeFile;
        public StoreFile File
        {
            get
            {
                _storeFile = FileUtility.GetFile<StoreFile>(_fileName);

                if (_storeFile == null)
                {
                    _storeFile = new StoreFile();

                    if (_price == 0)
                    {
                        _storeFile.IsPurchased = true;
                        _storeFile.IsEquipped = true;
                    }

                    FileUtility.WriteToFile(_storeFile, _fileName);
                }

                return _storeFile;
            }
        }

        public virtual void Equip(PlayerData playerData) { }

        public void SaveStoreFile()
        {
            FileUtility.WriteToFile(_storeFile, _fileName);
        }
    }
}