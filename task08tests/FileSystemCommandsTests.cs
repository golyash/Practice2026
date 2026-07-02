using FileSystemCommands;
namespace FileSystemCommandsTests;

public class FileSystemCommandsTests
{
    [Fact]
    public void DirectorySizeCommand_ShouldCalculateSize()
    {
        var test_directory_path = Path.Combine(Path.GetTempPath(), "TestDirectory");
        if (Directory.Exists(test_directory_path)) Directory.Delete(test_directory_path, true);
        Directory.CreateDirectory(test_directory_path);

        File.WriteAllText(Path.Combine(test_directory_path, "test1.txt"), "Hello");
        File.WriteAllText(Path.Combine(test_directory_path, "test2.txt"), "World");
        long expected_size = 10;

        var command = new DirectorySizeCommand(test_directory_path);
        command.Execute();

        Assert.Equal(expected_size, command.FinalSize);
        Directory.Delete(test_directory_path, true);
    }

    [Fact]
    public void FindFilesCommand_ShouldFindMatchingFiles()
    {
        var test_directory_path = Path.Combine(Path.GetTempPath(), "TestDirectory");
        if (Directory.Exists(test_directory_path)) Directory.Delete(test_directory_path, true);
        Directory.CreateDirectory(test_directory_path);

        File.WriteAllText(Path.Combine(test_directory_path, "file1.txt"), "Text");
        File.WriteAllText(Path.Combine(test_directory_path, "file2.log"), "Log");

        var command = new FindFilesCommand(test_directory_path, "*.txt");
        command.Execute();

        string found_file = Assert.Single(command.FoundFiles);
        Assert.EndsWith("file1.txt", found_file);
        Directory.Delete(test_directory_path, true);
    }

    [Fact]
    public void DirectorySizeCommand_ShouldThrowWhenDirectoryDoesNotExist_TryCatch()
    {
        var fake_path = Path.Combine(Path.GetTempPath(), "NotExistDirectory");
        var command = new DirectorySizeCommand(fake_path);
        try
        {
            command.Execute();
            Assert.Fail("Команда должна была выбросить исключение DirectoryNotFoundException");
        }
        catch(DirectoryNotFoundException) {}
    }

    [Fact]
    public void FindFilesCommand_ShouldReturnEmptyListWhenNoFilesMatchMask_TryCatch()
    {
        var test_directory_path = Path.Combine(Path.GetTempPath(), "TestDirectory");
        if (Directory.Exists(test_directory_path)) Directory.Delete(test_directory_path, true);
        Directory.CreateDirectory(test_directory_path);
        var command = new FindFilesCommand(test_directory_path, "*.mp3");
        try
        {
            command.Execute();
            Assert.Empty(command.FoundFiles);
        }
        catch(Exception ex) { Assert.Fail($"Команда выбросила непредвиденноу исключение {ex.Message}"); }
        finally
        {
            if (Directory.Exists(test_directory_path)) Directory.Delete(test_directory_path, true);
        }
    }
}
