using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

    internal partial class DownloadForm: FormContent
    {
        public DownloadForm()
        {
            TemplateJson = $$"""
                             {
                                 "type": "AdaptiveCard",
                                 "$schema": "http://adaptivecards.io/schemas/adaptive-card.json",
                                 "version": "1.6",
                                 "body": [
                                     {
                                         "type": "Input.Text",
                                         "placeholder": "[URI | MAGNET | TORRENT_FILE | METALINK_FILE]",
                                         "label": "File ",
                                         "style": "Url",
                                         "id": "file"
                                     },
                                     {
                                         "type": "Input.Text",
                                         "placeholder": "The directory to store the downloaded file.",
                                         "label": "Directory",
                                         "id": "directory"
                                     },
                                     {
                                         "type": "Input.Text",
                                         "placeholder": "Name of the output file",
                                         "label": "Output Name",
                                         "id": "output"
                                     },
                                     {
                                         "type": "Input.Number",
                                         "placeholder": "1-*",
                                         "label": "Split",
                                         "min": 1,
                                         "max": 5,
                                         "value": 5,
                                         "id": "split"
                                     },
                                     {
                                         "type": "Input.ChoiceSet",
                                         "choices": [
                                             {
                                                 "title": "none",
                                                 "value": "none"
                                             },
                                             {
                                                 "title": "prealloc",
                                                 "value": "prealloc"
                                             },
                                             {
                                                 "title": "trunc",
                                                 "value": "trunc"
                                             },
                                             {
                                                 "title": "falloc",
                                                 "value": "falloc"
                                             }
                                         ],
                                         "placeholder": "prealloc",
                                         "id": "fileAllocation",
                                         "label": "File Allocation",
                                         "value": "prealloc"
                                     },
                                     {
                                         "type": "Input.Toggle",
                                         "title": "Check Integrity",
                                         "label": "Check Integrity",
                                         "id": "integrity",
                                         "value": "false"
                                     },
                                     {
                                         "type": "Input.Text",
                                         "placeholder": "Downloads URIs found in FILE.",
                                         "id": "inputFile",
                                         "label": "Input File"
                                     }
                                 ]
                             }          
                             """;
        }
    }
}

