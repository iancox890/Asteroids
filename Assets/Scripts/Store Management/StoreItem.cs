using UnityEngine;
using AsteroidsApp.ScoreManagement;
using AsteroidsApp.FileData;

namespace AsteroidsApp.StoreManagement
{
    /// <summary>
    /// Base class for all store items, defining a price, 
    /// a store item data, and a purchase method.
    /// </summary>
    public class StoreItem : ScriptableObject
    {
        [SerializeField] private int _price;

        private StoreItemData _data;
        public StoreItemData Data
        {
            get
            {
                _data = FileUtility.GetFile<StoreItemData>(name);

                if (_data == null)
                {
                    _data = new StoreItemData(name);
                    _data.Save();
                }

                return _data;
            }
        }

        private void Purchase()
        {
            PointsData pointsData = FileUtility.GetFile<PointsData>(ScoreManager.POINTS_DATA_FILE_NAME);
            if (pointsData == null || pointsData.Points < _price) return;

            Data.IsPurchased = true;
            Data.Save();
        }
    }
}