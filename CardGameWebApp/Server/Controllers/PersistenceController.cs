﻿using CardGameWebApp.Shared.Responses;
using FileContext;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http.Extensions;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System;

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
			var response = new StorageResponse(Url.Action(nameof(Index), "persistence", new { url = $"{url}" }, Request.Scheme).Replace("%2F", "/"))
			{
				folders = GenerateFolderLinks(storage.GetFolders($"{USER}/{url}"), url),
				files = GenerateFileLinks(storage.GetFiles($"{USER}/{url}"), url)
			};
			response.Links.Add("file", Url.Action(nameof(GetTextFile), "persistence", new { url = $"{url}" }, Request.Scheme).Replace("%2F", "/"));
			return response;
		}

		[HttpPost("folders/{*url}")]
		public IActionResult CreateFolder(string url)
		{
			storage.CreateFolder($"{USER}/{url}");
			return Created(Request.GetEncodedUrl(), null);
		}

		[HttpDelete("folders/{*url}")]
		public IActionResult DeleteFolder(string url)
		{
            if (!bool.TryParse(Request.Query["recursive"], out bool recursive))
                recursive = false;

            try
            {
				storage.DeleteFolder($"{USER}/{url}", recursive);
			}
			catch (IOException)
            {
				return Conflict("Folder is not empty. Please empty folder or repeat the request with the parameter recursive set to true.");
            }
            
			return Ok();
		}

		[HttpGet("files/{*url}")]
		public string GetTextFile(string url)
		{
			return storage.GetFile($"{USER}/{url}");
		}

		[HttpPost("files/{*url}")]
		public async Task<ActionResult> StoreTextFile(string url)
		{
			using (StreamReader reader = new(Request.Body, Encoding.UTF8))
			{
				var content = await reader.ReadToEndAsync();
				storage.StoreFile($"{USER}/{url}", content);
			}
			
			return Ok(Request.GetEncodedUrl());
		}

		[HttpDelete("files/{*url}")]
		public ActionResult RemoveTextFile(string url)
        {
			storage.RemoveFile($"{USER}/{url}");
			return Ok();
        }
	}
}
