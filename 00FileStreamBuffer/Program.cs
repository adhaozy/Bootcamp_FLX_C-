using System.IO;

class Program {
    static void Main() {
        string path = "largefile.txt";

        using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read)) {
            byte[] buffer = new byte[4096];
            int bytesRead;

            while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0) {
                // Process the data
                Console.WriteLine($"Read {bytesRead} bytes");
            }
        }
    }
}
