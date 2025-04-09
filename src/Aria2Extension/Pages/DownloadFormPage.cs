using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
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

            TemplateJson = File.ReadAllText(path);
        }

        public override CommandResult SubmitForm(string payload)
        {
            var formInput = JsonNode.Parse(payload)?.AsObject();
            if (formInput == null)
            {
                return CommandResult.GoHome();
            }

            // retrieve the value of the input field with the id "name"
            var name = formInput["directory"]?.ToString();

            // do something with the data
            Console.WriteLine(name);
            // and eventually
            return CommandResult.GoBack();
        }
    }
}

