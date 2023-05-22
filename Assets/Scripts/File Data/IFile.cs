namespace AsteroidsApp.FileData
{
    public interface IFile
    {
        string FileName { get; }
        void Save();
    }
}