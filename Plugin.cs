using System;
using System.Collections.Generic;
using MediaBrowser.Common.Configuration;
using MediaBrowser.Common.Plugins;
using MediaBrowser.Model.Plugins;
using MediaBrowser.Model.Serialization;
using MovieOfTheWeek.Configuration;
using MediaBrowser.Controller.Library;
using MediaBrowser.Controller.Session;
using MediaBrowser.Controller.Dto;

namespace MovieOfTheWeek
{
    public class Plugin : BasePlugin<PluginConfiguration>, IHasWebPages
    {
        private readonly ILibraryManager _libraryManager;
        private readonly ISessionManager _sessionManager;
        private readonly IDtoService _dtoService;

        public static HomePageModification HomePageModification { get; private set; }

        public Plugin(
            IApplicationPaths applicationPaths, 
            IXmlSerializer xmlSerializer,
            ILibraryManager libraryManager,
            ISessionManager sessionManager,
            IDtoService dtoService)
            : base(applicationPaths, xmlSerializer)
        {
            Instance = this;
            _libraryManager = libraryManager;
            _sessionManager = sessionManager;
            _dtoService = dtoService;

            HomePageModification = new HomePageModification(_libraryManager, _dtoService);
            HomePageModification.RunAsync().ConfigureAwait(false);
        }

        public override string Name => "Movie of the Week";
        public override Guid Id => Guid.Parse("e29b0e36-d7c3-4068-9b12-3f87f3dcf947");

        public static Plugin Instance { get; private set; }

        public IEnumerable<PluginPageInfo> GetPages()
        {
            return new[]
            {
                new PluginPageInfo
                {
                    Name = "movieoftheweekconfig",
                    EmbeddedResourcePath = GetType().Namespace + ".Configuration.configpage.html",
                    EnableInMainMenu = true,
                    MenuSection = "server",
                    DisplayName = "Movie of the Week"
                }
            };
        }
    }
} 