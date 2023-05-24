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

                    FileUtility.WriteToFile(_playerFile, _fileName);
                }

                return _playerFile;
            }
        }

        public void SavePlayerFile()
        {
            FileUtility.WriteToFile(_playerFile, _fileName);
        }
    }
}