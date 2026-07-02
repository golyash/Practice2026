using CommandLib;
namespace FileSystemCommands;

public class DirectorySizeCommand : ICommand
{
    private readonly string DirectoryPath;
    public long FinalSize {get; private set; } = -1;
    public DirectorySizeCommand(string directory_path)
    {
        if (string.IsNullOrWhiteSpace(directory_path)) throw new ArgumentException("Имя каталога не может быть пустым или состоять из пробелов, а также быть null");
        DirectoryPath = directory_path;
    }

    public void Execute()
    {
        if (!Directory.Exists(DirectoryPath)) { throw new DirectoryNotFoundException($"Каталога по пути {DirectoryPath} ну существует"); }
        try
        {
            long size = 0;
            string[] files = Directory.GetFiles(DirectoryPath, "*", SearchOption.AllDirectories);
            foreach(var file in files)
            {
                FileInfo file_info = new FileInfo(file);
                size += file_info.Length;
            }
            FinalSize = size;
            Console.WriteLine($"Общий размер каталога {DirectoryPath} : {FinalSize} байт");
        }
        catch (Exception ex) { Console.WriteLine($"Ошибка при подсчёте размера : {ex.Message}"); }
    }
}
