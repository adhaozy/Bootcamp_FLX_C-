using System.IO;

class Program {
    static void Main() {
        string sourcePath = @"..\00FileStream\bootcamp.txt";
        string destPath =@"..\00FileStream\bootcamp2.txt";

        // Copy 
        if (File.Exists(sourcePath)) {
            File.Copy(sourcePath, destPath, true);
            Console.WriteLine("File copied.");
        }

        // Delete
        if (File.Exists(destPath)) {
            File.Delete(destPath);
            Console.WriteLine("File deleted.");
        }

        // Move
        if (File.Exists(sourcePath)) {
            string newPath = Path.Combine(Path.GetDirectoryName(sourcePath) ?? string.Empty, "newfile.txt");
            File.Move(sourcePath, newPath);
            Console.WriteLine("File moved.");
        }

        // Read 
        if (File.Exists(destPath)) {
            string content = File.ReadAllText(destPath);
            Console.WriteLine(content);
        }
    }
}
