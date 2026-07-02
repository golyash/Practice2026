using CommandLib;
namespace FileSystemCommands;

public class FindFilesCommand : ICommand
{
    private readonly string DirectoryPath;
    private readonly string SearchPattern;
    public List<string> FoundFiles {get; private set; } = new();
    public FindFilesCommand(string directory_path, string search_pattern)
    {
        if (string.IsNullOrWhiteSpace(directory_path)) throw new ArgumentException("Имя каталога не может быть пустым или состоять из пробелов, а также быть null");
        if (string.IsNullOrWhiteSpace(search_pattern)) throw new ArgumentException("Маска не может быть пустой или состоять из пробелов, а также быть null");
        DirectoryPath = directory_path;
        SearchPattern = search_pattern;
    }

    public void Execute()
    {
        if (!Directory.Exists(DirectoryPath)) { throw new DirectoryNotFoundException($"Каталога по пути {DirectoryPath} ну существует"); }
        try
        {
            string[] files = Directory.GetFiles(DirectoryPath, SearchPattern, SearchOption.AllDirectories);
            FoundFiles = new List<string>(files);
            Console.WriteLine($"Найдено файлов по маске {SearchPattern} : {FoundFiles.Count}");
            foreach(var file in FoundFiles)
            {
                Console.WriteLine(file);
            }
        }
        catch (Exception ex) { Console.WriteLine($"Ошибка при поиске : {ex.Message}"); }
    }
}
