using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;

namespace Aria2Extension.Pages
{
    internal sealed partial class DownloadFormPage : FormContent
    {
        public DownloadFormPage()
        {
            TemplateJson = $$"""
            {
                "$schema": "http://adaptivecards.io/schemas/adaptive-card.json",
                "type": "AdaptiveCard",
                "version": "1.6",
                "body": [
                    {
                        "type": "TextBlock",
                        "text": "Test",
                        "size": "large"
                    }
            }            
            """;
        }
    }
}

