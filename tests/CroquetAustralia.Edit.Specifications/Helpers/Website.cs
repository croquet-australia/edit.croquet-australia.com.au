using System;
using System.Diagnostics;
using System.IO;
using Anotar.NLog;
using OpenMagic.Extensions;

namespace CroquetAustralia.Edit.Specifications.Helpers
{
    public class Website
    {
        private readonly FileInfo _iisExpressFile;
        private readonly FileInfo _projectFile;
        private readonly Uri _uri;

        public Website(string projectName, int port) : this(projectName, port, new IISExpress(), new Solution())
        {
        }

        protected Website(string projectName, int port, IISExpress iisExpress, Solution solution)
        {
            _projectFile = solution.GetProjectFile(projectName);
            _iisExpressFile = iisExpress.GetExeFile();
            _uri = new Uri($"https://localhost:{port}/");
        }


        public void StartIfNotRunning()
        {
            if (IsRunning())
            {
                LogTo.Debug($"'{_projectFile.Name}' website at {_uri} is running.");
                return;
            }
            Start();
        }

        private void Start()
        {
            var processStartInfo = new ProcessStartInfo
            {
                FileName = _iisExpressFile.FullName,
                Arguments = $@"/path:""{_projectFile.Directory?.FullName}"" /port:{_uri.Port}",
                WindowStyle = ProcessWindowStyle.Hidden
            };

            var process = Process.Start(processStartInfo);

            if (process == null)
            {
                throw new Exception($"Could not start IIS Express. projectDirectory: '{_projectFile.Directory?.FullName}' port: '{_uri.Port}'");
            }

            LogTo.Debug($"Started '{_projectFile.Name}' website at {_uri}.");
        }

        private bool IsRunning()
        {
            return _uri.IsResponding();
        }
    }
}