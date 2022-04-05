using System.Collections.Generic;
using System.IO;

namespace CardGameWebApp.Server
{
    public class StorageService
    {
        private const string dataFileExtension = ".cgd";
        private readonly string dataPath;

        public StorageService(string dataPath)
        {
            this.dataPath = dataPath;
        }

        public string GetFile(string file)
        {
            var data = string.Empty;
            using (var stream = File.OpenRead($"{dataPath}{file.Replace("/", @"\")}{dataFileExtension}"))
            {
                data = new StreamReader(stream).ReadToEnd();
            }
            return data;
        }

        public void StoreFile(string file, string contents)
        {
            File.WriteAllText($"{dataPath}{file.Replace("/", @"\")}{dataFileExtension}", contents);
        }

        public IEnumerable<string> GetFiles(string uri)
        {
            var directory = new DirectoryInfo($"{dataPath}{uri}");
            foreach (var item in directory.GetFiles($"*{dataFileExtension}"))
            {
                int index = item.Name.LastIndexOf('.');
                yield return item.Name.Substring(0, index);
            }
        }

        public IEnumerable<string> GetFolders(string uri)
        {
            var directory = new DirectoryInfo($"{dataPath}{uri}");
            foreach (var item in directory.GetDirectories())
            {
                yield return item.Name;
            }
        }

        public void CreateFolder(string uri)
        {
            var directory = new DirectoryInfo($"{dataPath}{uri}");
            if (directory.Exists)
                return;

            directory.Create();
        }

        public void RemoveFile(string uri)
        {
            var file = new FileInfo($"{dataPath}{uri}{dataFileExtension}");
            if (file.Exists)
                file.Delete();
        }

        internal void DeleteFolder(string uri, bool recursive = false)
        {
            var dir = new DirectoryInfo($"{dataPath}{uri}");
            dir.Delete(recursive);
        }
    }
}
