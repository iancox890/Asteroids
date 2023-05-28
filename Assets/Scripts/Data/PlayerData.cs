using UnityEngine;

namespace Asteroids.Data
{
    /// <summary>
    /// Holds the player data file.
    /// </summary>
    [CreateAssetMenu(menuName = "Asteroids/Player Data", fileName = "Player Data")]
    public class PlayerData : ScriptableObject
    {
        [SerializeField] private string _fileName;
        [SerializeField] private ShipColorData _defaultShipColor;
        [SerializeField] private ShipUpgradeData _defaultShip;

        public event System.Action OnPlayerFileSaved;

        private PlayerFile _playerFile;
        public PlayerFile File
        {
            get
            {
                _playerFile = FileUtility.GetFile<PlayerFile>(_fileName);

                if (_playerFile == null)
                {
                    _playerFile = new PlayerFile();
                    _playerFile.ShipColor = _defaultShipColor.Color;
                    _playerFile.Ship = _defaultShip.ShipUpgrade.name;

                    FileUtility.WriteToFile(_playerFile, _fileName);
                }

                return _playerFile;
            }
        }

        public void SavePlayerFile()
        {
            FileUtility.WriteToFile(_playerFile, _fileName);
            OnPlayerFileSaved?.Invoke();
        }
    }
}