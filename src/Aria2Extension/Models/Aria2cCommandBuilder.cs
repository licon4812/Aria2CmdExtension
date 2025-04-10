using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aria2Extension.Models
{
    internal class Aria2cCommandBuilder(DownloadFormResultsModel downloadFormResults)
    {
        public string BuildCommand()
        {
            var aria2cCommand = new StringBuilder("aria2c");

            // Add the directory to store the downloaded file
            if (!string.IsNullOrEmpty(downloadFormResults.Directory))
            {
                var escapedDirectory = downloadFormResults.Directory.Replace("\\", "\\\\");
                aria2cCommand.Append(string.Format(CultureInfo.InvariantCulture, " --dir=\"{0}\"", escapedDirectory));
            }

            // Add the output file name
            if (!string.IsNullOrEmpty(downloadFormResults.Output))
            {
                var escapedOutputFile = downloadFormResults.Output.Replace("\\", "\\\\");
                aria2cCommand.Append(string.Format(CultureInfo.InvariantCulture, " --out=\"{0}\"", escapedOutputFile));
            }

            // Add the number of connections to use for downloading
            aria2cCommand.Append(string.Format(CultureInfo.InvariantCulture, " --split={0}", downloadFormResults.Split));

            // Add the file allocation method
            aria2cCommand.Append(string.Format(CultureInfo.InvariantCulture, " --file-allocation={0}", downloadFormResults.FileAllocation));

            // Add the integrity check option
            if (downloadFormResults.Integrity)
            {
                aria2cCommand.Append(" --check-integrity=true");
            }

            // Add the continue option
            if (downloadFormResults.Continue)
            {
                aria2cCommand.Append(" --continue=true");
            }

            // Add the input file for URIs
            if (!string.IsNullOrEmpty(downloadFormResults.InputFile))
            {
                var escapedInputFile = downloadFormResults.InputFile.Replace("\\", "\\\\");
                aria2cCommand.Append(string.Format(CultureInfo.InvariantCulture, " --input-file=\"{0}\"", escapedInputFile));
            }

            // Add the maximum number of concurrent downloads
            aria2cCommand.Append(string.Format(CultureInfo.InvariantCulture, " --max-concurrent-downloads={0}", downloadFormResults.MaxConcurrentDownloads));

            // Add the force sequential option
            if (downloadFormResults.ForceSequential)
            {
                aria2cCommand.Append(" --force-sequential=true");
            }

            // Add the maximum number of connections per server
            aria2cCommand.Append(string.Format(CultureInfo.InvariantCulture, " --max-connection-per-server={0}", downloadFormResults.MaxConnection));

            // Add FTP user and password
            if (!string.IsNullOrEmpty(downloadFormResults.FtpUser))
            {
                aria2cCommand.Append(string.Format(CultureInfo.InvariantCulture, " --ftp-user=\"{0}\"", downloadFormResults.FtpUser));
            }
            if (!string.IsNullOrEmpty(downloadFormResults.FtpPassword))
            {
                aria2cCommand.Append(string.Format(CultureInfo.InvariantCulture, " --ftp-passwd=\"{0}\"", downloadFormResults.FtpPassword));
            }

            // Add HTTP user and password
            if (!string.IsNullOrEmpty(downloadFormResults.HttpUser))
            {
                aria2cCommand.Append(string.Format(CultureInfo.InvariantCulture, " --http-user=\"{0}\"", downloadFormResults.HttpUser));
            }
            if (!string.IsNullOrEmpty(downloadFormResults.HttpPassword))
            {
                aria2cCommand.Append(string.Format(CultureInfo.InvariantCulture, " --http-passwd=\"{0}\"", downloadFormResults.HttpPassword));
            }

            // Add cookies file
            if (!string.IsNullOrEmpty(downloadFormResults.CookiesFile))
            {
                var escapedCookiesFile = downloadFormResults.CookiesFile.Replace("\\", "\\\\");
                aria2cCommand.Append(string.Format(CultureInfo.InvariantCulture, " --load-cookies=\"{0}\"", escapedCookiesFile));
            }

            // Add the show files option
            if (downloadFormResults.ShowFiles)
            {
                aria2cCommand.Append(" --show-files=true");
            }

            // Add the maximum overall upload limit
            if (downloadFormResults.MaxOverallUpload > 0)
            {
                aria2cCommand.Append(string.Format(CultureInfo.InvariantCulture, " --max-overall-upload-limit={0}K", downloadFormResults.MaxOverallUpload));
            }

            // Add the maximum upload limit per torrent
            if (downloadFormResults.MaxUpload > 0)
            {
                aria2cCommand.Append(string.Format(CultureInfo.InvariantCulture, " --max-upload-limit={0}K", downloadFormResults.MaxUpload));
            }

            // Add the torrent file
            if (!string.IsNullOrEmpty(downloadFormResults.TorrentFile))
            {
                aria2cCommand.Append(string.Format(CultureInfo.InvariantCulture, " --torrent-file=\"{0}\"", downloadFormResults.TorrentFile));
            }

            // Add the listen port for BitTorrent
            aria2cCommand.Append(string.Format(CultureInfo.InvariantCulture, " --listen-port={0}", downloadFormResults.ListenPort));

            // Add the DHT options
            if (downloadFormResults.EnableDHT)
            {
                aria2cCommand.Append(" --enable-dht=true");
            }
            aria2cCommand.Append(string.Format(CultureInfo.InvariantCulture, " --dht-listen-port={0}", downloadFormResults.DHTListenPort));
            if (downloadFormResults.EnableDHT6)
            {
                aria2cCommand.Append(" --enable-dht6=true");
            }
            aria2cCommand.Append(string.Format(CultureInfo.InvariantCulture, " --dht-listen-addr6={0}", downloadFormResults.DHT6ListenAddress));

            // Add the metalink file
            if (!string.IsNullOrEmpty(downloadFormResults.MetalinkFile))
            {
                var escapedMetalinkFile = downloadFormResults.MetalinkFile.Replace("\\", "\\\\");
                aria2cCommand.Append(string.Format(CultureInfo.InvariantCulture, " --metalink-file=\"{0}\"", escapedMetalinkFile));
            }

            // Add the file or URI to download
            if (!string.IsNullOrEmpty(downloadFormResults.File))
            {
                aria2cCommand.Append(string.Format(CultureInfo.InvariantCulture, " \"{0}\"", downloadFormResults.File));
            }

            // return the complete command
            return aria2cCommand.ToString();
        }
    }
}
