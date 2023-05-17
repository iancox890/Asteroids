namespace AsteroidsApp.FileManagement
{
    public interface IFile
    {
        string FileName { get; }
        void Save();
    }
}