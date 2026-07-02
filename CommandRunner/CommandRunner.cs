using System.Reflection;
using CommandLib;
namespace CommandRunner;

class CommandRunner
{
    static void Main()
    {
        string dll_path = Path.GetFullPath("../Practice2026/FileSystemCommands/bin/Debug/net8.0/FileSystemCommands.dll");

        string demo_directory_path = Path.Combine(Path.GetTempPath(), "DemoDirectory");
        if(Directory.Exists(demo_directory_path)) Directory.Delete(demo_directory_path, true);
        Directory.CreateDirectory(demo_directory_path);
        File.WriteAllText(Path.Combine(demo_directory_path, "notes.txt"), "Hello World!");
        File.WriteAllText(Path.Combine(demo_directory_path, "file2.log"), "Log");
        try
        {
            Assembly assembly = Assembly.LoadFrom(dll_path);
            Type[] types = assembly.GetTypes();
            foreach(Type type in types)
            {
                if (typeof(ICommand).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
                {
                    ICommand? command_instance = null;
                    if(type.Name == "DirectorySizeCommand") command_instance = Activator.CreateInstance(type, new object[] {demo_directory_path}) as ICommand;
                    else if(type.Name == "FindFilesCommand") command_instance = Activator.CreateInstance(type, new object[] {demo_directory_path, "*txt"}) as ICommand;
                    if(command_instance != null)
                    {
                        Console.WriteLine($"Запуск класса {type.Name}");
                        command_instance.Execute();
                    }
                }
            }
        }
        catch (Exception ex) {Console.WriteLine($"Произошла ошибка рефлексии : {ex.Message}");}
        finally
        {
            if (Directory.Exists(demo_directory_path)) Directory.Delete(demo_directory_path, true);
        }
    }
}
