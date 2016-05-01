using System;
using System.IO;
using System.Linq;

namespace CroquetAustralia.Edit.Specifications.Helpers
{
    public class IISExpress
    {
        public FileInfo GetExeFile()
        {
            var programFileDirectories = new[]
            {
                Environment.GetEnvironmentVariable("ProgramFiles(x86)"),
                Environment.GetEnvironmentVariable("ProgramFiles")
            };

            var possibleIISExpressPaths = programFileDirectories.Select(directory => Path.Combine(directory, @"IIS Express\iisexpress.exe")).ToArray();
            var iisExpressPath = possibleIISExpressPaths.FirstOrDefault(File.Exists);

            if (!string.IsNullOrWhiteSpace(iisExpressPath))
            {
                return new FileInfo(iisExpressPath);
            }

            var searched = string.Join(", ", programFileDirectories.Select(directory => string.Format("'{0}'", directory)));
            var message = $"Cannot find 'iisexpress.exe'. Searched {searched}.";

            throw new FileNotFoundException(message);
        }
    }
}