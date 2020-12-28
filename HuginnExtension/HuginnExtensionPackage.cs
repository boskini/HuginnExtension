using EnvDTE;
using HuginnExtension.Model;
using Microsoft;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Management.Automation;
using System.Runtime.InteropServices;
using System.Threading;
using Task = System.Threading.Tasks.Task;

namespace HuginnExtension
{
    [Guid(PackageGuidString)]
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [ProvideService(typeof(HuginnExtensionPackage), IsAsyncQueryable = true)]
    [ProvideAutoLoad(VSConstants.UICONTEXT.NoSolution_string, PackageAutoLoadFlags.BackgroundLoad)]
    [ProvideAutoLoad(VSConstants.UICONTEXT.SolutionExists_string, PackageAutoLoadFlags.BackgroundLoad)]
    [ProvideAutoLoad(VSConstants.UICONTEXT.SolutionHasMultipleProjects_string, PackageAutoLoadFlags.BackgroundLoad)]
    [ProvideAutoLoad(VSConstants.UICONTEXT.SolutionHasSingleProject_string, PackageAutoLoadFlags.BackgroundLoad)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    public sealed class HuginnExtensionPackage : AsyncPackage
    {
        private DTE _DTE;
        private DocumentEvents _dteDocumentEvents;

        public const string PackageGuidString = "3f690938-1d0c-47d2-af51-801671a7ca39";
        private const string _CONFIGFILENAME = "Huginn-config.json";

        #region Events
        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            await this.JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);
            await Command.InitializeAsync(this);

            _DTE = (DTE)await GetServiceAsync(typeof(DTE));
            Assumes.Present(_DTE);

            _dteDocumentEvents = _DTE.Events.DocumentEvents;
            _dteDocumentEvents.DocumentSaved += OnDocumentSaved;
        }
        private void OnDocumentSaved(EnvDTE.Document doc)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            try
            {
                var filename = doc.Name;

                var filepath = GetConfigfilePath(doc.Path); // Find configuration file path
                if (filepath != "")
                {
                    var configList = LoadJson(filepath); // Get content of configuration path

                    if (configList.items.Length > 0)
                    {
                        foreach (var config in configList.items)
                        {
                            if (doc.Name.ToLower().Contains("." + config.ext) || config.ext.Equals("*"))
                            {
                                //run "powershell Set-ExecutionPolicy RemoteSigned" in x86 and x64 powershell
                                PowerShell.Create().AddCommand(config.command).Invoke();
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                //TODO Implements log
            }
        }
        #endregion

        #region Utils
        private ConfigFileModel LoadJson(string path)
        {
            try
            {
                using (StreamReader r = new StreamReader(path))
                {
                    string json = r.ReadToEnd();
                    ConfigFileModel items = JsonConvert.DeserializeObject<ConfigFileModel>(json);
                    return items;
                }
            }
            catch (Exception ex)
            {
                //TODO Implements log
                return new ConfigFileModel();
            }
        }

        private string GetConfigfilePath(string FolderFullPath)
        {
            var arrPath = FolderFullPath.Split('\\');
            for (var i = arrPath.Length - 1; i > 0; i--)
            {
                var path = "";
                for (var x = 0; x < i; x++)
                {
                    if (x > 0) path += "\\";
                    path += arrPath[x];
                }

                var filename = path + "\\" + _CONFIGFILENAME;
                var exists = File.Exists(filename);
                if (exists) return filename;
            }

            return "";
        }
        #endregion
    }
}

