using System;
using System.IO;
using System.Linq;
using Anotar.NLog;
using OpenMagic.Extensions;

namespace CroquetAustralia.Edit.Specifications.Helpers
{
    public class Solution
    {
        private readonly DirectoryInfo _solutionDirectory;

        public Solution()
        {
            _solutionDirectory = GetSolutionFile("edit.croquet-australia.com.au").Directory;
        }

        private static FileInfo GetSolutionFile(string solutionName)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var solutionParentDirectory = currentDirectory.TextBefore($@"\{solutionName}\", null);

            if (solutionParentDirectory == null)
            {
                throw new Exception($"Expected to find solutionName '{solutionName}' in current directory '{currentDirectory}'.");
            }

            var solutionFile = new FileInfo(Path.Combine(solutionParentDirectory,$@"{solutionName}\{solutionName}.sln"));

            if (!solutionFile.Exists)
            {
                throw new FileNotFoundException($"Cannot find solution file '{solutionFile.FullName}'.");
            }

            LogTo.Debug($"Found solution: {solutionFile.FullName}");
            return solutionFile;
        }

        public FileInfo GetProjectFile(string projectName)
        {
            var projectFile = new FileInfo(Path.Combine(_solutionDirectory.FullName, $@"source\{projectName}\{projectName}.csproj"));

            if (!projectFile.Exists)
            {
                throw new FileNotFoundException($"Cannot find project file for project '{projectName}'.");
            }

            LogTo.Debug($"Found project: {projectFile.FullName}");
            return projectFile;
        }
    }
}