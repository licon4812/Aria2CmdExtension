using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aria2Extension.Models
{
    internal partial class DownloadFormResultsModel
    {
        public string? File { get; set; } // [URI | MAGNET | TORRENT_FILE | METALINK_FILE]
        public string? Directory { get; set; } = string.Empty; // The directory to store the downloaded file (Required)
        public string? Output { get; set; } // Name of the output file
        public int Split { get; set; } = 5; // Split (1-5)
        public string FileAllocation { get; set; } = "prealloc"; // File Allocation (Choices: none, prealloc, trunc, falloc)
        public bool Integrity { get; set; } = false; // Check Integrity
        public bool Continue { get; set; } = false; // Continue
        public string? InputFile { get; set; } // Downloads URIs found in FILE
        public int MaxConcurrentDownloads { get; set; } = 5; // Max Concurrent Downloads (Min: 1)
        public bool ForceSequential { get; set; } = false; // Force Sequential
        public int MaxConnection { get; set; } = 1; // Max Connection Per Server (Min: 1, Max: 16)
        public string? FtpUser { get; set; } // FTP User
        public string? FtpPassword { get; set; } // FTP Password (Password style)
        public string? HttpUser { get; set; } // HTTP User
        public string? HttpPassword { get; set; } // HTTP Password (Password style)
        public string? CookiesFile { get; set; } // Cookies File
        public bool ShowFiles { get; set; } = false; // Show Files
        public int MaxOverallUpload { get; set; } = 0; // Max Overall Upload Limit (0 means unrestricted)
        public int MaxUpload { get; set; } = 0; // Max Upload Limit (0 means unrestricted)
        public string? TorrentFile { get; set; } // Torrent File Path
        public string ListenPort { get; set; } = "6881-6999"; // Listen Port (Default: "6881-6999")
        public bool EnableDHT { get; set; } = true; // Enable DHT
        public string DHTListenPort { get; set; } = "6881-6999"; // DHT Listen Port (Default: "6881-6999")
        public bool EnableDHT6 { get; set; } = false; // Enable DHT6
        public string DHT6ListenAddress { get; set; } = "::1"; // DHT6 Listen Address (Default: "::1")
        public string? MetalinkFile { get; set; } // Metalink File
    }
}
