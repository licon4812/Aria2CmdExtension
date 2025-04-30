using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Aria2Extension.Models;
using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;

namespace Aria2Extension.Pages
{
    internal sealed partial class DownloadFormPage : ContentPage
    {
        public DownloadFormPage()
        {
            Icon = new IconInfo("\uEBD3");
            Title = "Aria2: Download";
            Name = "Download";
        }

        public override IContent[] GetContent()
        {
            var downloadForm = new DownloadForm();
            return
            [
                downloadForm
            ];
        }
    }

    internal partial class DownloadForm : FormContent
    {
        public DownloadForm()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FormTemplates", "downloadForm.json");

            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"The file 'downloadForm.json' was not found at path: {path}");
            }

            var downloadDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            downloadDirectory = Path.Combine(downloadDirectory, "Downloads").Replace("\\","\\\\");

            TemplateJson = File.ReadAllText(path).Replace("$path", downloadDirectory);
        }

        public override CommandResult SubmitForm(string payload)
        {
            var formInput = JsonNode.Parse(payload)?.AsObject();
            if (formInput == null)
            {
                return CommandResult.GoHome();
            }

            // retrieve the payload and assign it to the custom object

            var downloadFormResult = new DownloadFormResultsModel()
            {
                File = formInput["file"]?.ToString(),
                Directory = formInput["directory"]?.ToString(),
                Output = formInput["output"]?.ToString(),
                Split = formInput["split"] != null ? int.Parse(formInput["split"].ToString()) : 5,
                FileAllocation = formInput["fileAllocation"]?.ToString() ?? "prealloc",
                Integrity = formInput["integrity"]?.ToString() == "true",
                Continue = formInput["continue"]?.ToString() == "true",
                InputFile = formInput["inputFile"]?.ToString(),
                MaxConcurrentDownloads = formInput["maxConcurrentDownloads"] != null ? int.Parse(formInput["maxConcurrentDownloads"].ToString()) : 5,
                ForceSequential = formInput["forceSequential"]?.ToString() == "true",
                MaxConnection = formInput["maxConnection"] != null ? int.Parse(formInput["maxConnection"].ToString()) : 1,
                FtpUser = formInput["ftpUser"]?.ToString(),
                FtpPassword = formInput["ftpPassword"]?.ToString(),
                HttpUser = formInput["httpUser"]?.ToString(),
                HttpPassword = formInput["HTTP Password"]?.ToString(),
                CookiesFile = formInput["cookiesFile"]?.ToString(),
                ShowFiles = formInput["showFiles"]?.ToString() == "true",
                MaxOverallUpload = formInput["maxOverallUpload"] != null ? int.Parse(formInput["maxOverallUpload"].ToString()) : 0,
                MaxUpload = formInput["maxUpload"] != null ? int.Parse(formInput["maxUpload"].ToString()) : 0,
                TorrentFile = formInput["torrentfile"]?.ToString(),
                ListenPort = formInput["listenPort"]?.ToString() ?? "6881-6999",
                EnableDHT = formInput["enableDHT"]?.ToString() == "true",
                DHTListenPort = formInput["dhtListenPort"]?.ToString() ?? "6881-6999",
                EnableDHT6 = formInput["enableDHT6"]?.ToString() == "true",
                DHT6ListenAddress = formInput["dht6ListenAddress"]?.ToString() ?? "::1",
                MetalinkFile = formInput["metalinkFile"]?.ToString()
            };

            // do something with the data
            var aria2cCommand = new Aria2cCommandBuilder(downloadFormResult).BuildCommand();

            // Run the command


            var startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/k {aria2cCommand} " ,
                UseShellExecute = true,
                CreateNoWindow = false
            };

            using var process = new Process();
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();

            // and eventually
            return CommandResult.GoBack();
        }
    }
}

