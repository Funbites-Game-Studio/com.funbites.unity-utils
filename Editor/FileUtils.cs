namespace Funbites.UnityUtils.Editor
{

    using System.IO;
    using System.Text;
    using System.Threading.Tasks;

    public static class FileUtils
    {

        private const int DefaultBufferSize = 4096;
        private const FileOptions DefaultOptions = FileOptions.Asynchronous | FileOptions.SequentialScan;


        public static void ShowExplorer(string itemPath)
        {
            itemPath = itemPath.Replace(@"/", @"\");
            System.Diagnostics.Process.Start("explorer.exe", "/select," + itemPath);
        }

        public static async Task<string> ReadAllTextAsync(string filePath)
        {
            using var sourceStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read,
                DefaultBufferSize, DefaultOptions);
            using var reader = new StreamReader(sourceStream, Encoding.Unicode);
            return await reader.ReadToEndAsync();
        }
    }
}
