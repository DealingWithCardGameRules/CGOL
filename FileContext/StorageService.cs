using System.Collections.Generic;
using System.IO;

namespace FileContext
{
	public class StorageService
    {
        private const string dataFileExtension = ".cgd";
        private readonly string dataPath;

        public StorageService(string dataPath)
        {
            this.dataPath = dataPath;
        }

        public string GetFile(string uri)
        {
            return $"{dataPath}{uri}{dataFileExtension}";
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
    }
}
