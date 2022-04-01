using CardGameWebApp.Shared.Responses;
using FileContext;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http.Extensions;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CardGameWebApp.Server.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PersistenceController : Controller
	{
		const string USER = "anonymous";

		private readonly StorageService storage;

		public PersistenceController(StorageService directorySearcher)
		{
			this.storage = directorySearcher ?? throw new System.ArgumentNullException(nameof(directorySearcher));
		}

		private IDictionary<string, string> GenerateFolderLinks(IEnumerable<string> folders, string? url = null)
		{
			Dictionary<string, string> links = new();
			url = url == null ? string.Empty: $"{url}/";
			foreach (var folder in folders)
				links.Add(folder, Url.Action(nameof(Index), "persistence", new { url = $"{url}{folder}" }, Request.Scheme).Replace("%2F", "/"));

			return links;
		}

		private IDictionary<string, string> GenerateFileLinks(IEnumerable<string> files, string? url = null)
		{
			Dictionary<string, string> links = new();
			url = url == null ? string.Empty : $"{url}/";
			foreach (var file in files)
				links.Add(file, Url.Action(nameof(GetTextFile), "persistence", new { url = $"{url}{file}" }, Request.Scheme).Replace("%2F", "/"));

			return links;
		}

		[HttpGet]
		[HttpGet("folders/{*url}")]
		public StorageResponse Index(string url)
		{
			return new StorageResponse(Request.GetEncodedUrl())
			{
				folders = GenerateFolderLinks(storage.GetFolders($"{USER}/{url}"), url),
				files = GenerateFileLinks(storage.GetFiles($"{USER}/{url}"), url)
			};
		}

		[HttpPost("folders/{*url}")]
		public StorageResponse CreateFolder(string url)
		{
			return new StorageResponse(Request.GetEncodedUrl())
			{
				folders = GenerateFolderLinks(storage.GetFolders($"{USER}/{url}"), url),
				files = GenerateFileLinks(storage.GetFiles($"{USER}/{url}"), url)
			};
		}

		[HttpGet("files/{*url}")]
		public string GetTextFile(string url)
		{
			return storage.GetFile($"{USER}/{url}");
		}

		[HttpPost("files/{*url}")]
		public async Task<ActionResult> StoreTextFile(string url)
		{
			using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
			{
				var content = await reader.ReadToEndAsync();
				storage.StoreFile($"{USER}/{url}", content);
			}
			
			return Ok(Request.GetEncodedUrl());
		}
	}
}
