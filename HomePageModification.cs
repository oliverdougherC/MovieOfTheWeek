using MediaBrowser.Controller.Library;
using MediaBrowser.Controller.Plugins;
using MediaBrowser.Model.Plugins;
using MediaBrowser.Model.Entities;
using MediaBrowser.Model.Dto;
using MediaBrowser.Controller.Dto;
using MediaBrowser.Model.Querying;
using System;
using System.Threading.Tasks;

namespace MovieOfTheWeek
{
    public class HomePageModification : IServerEntryPoint
    {
        private readonly ILibraryManager _libraryManager;
        private readonly IDtoService _dtoService;

        public HomePageModification(ILibraryManager libraryManager, IDtoService dtoService)
        {
            _libraryManager = libraryManager;
            _dtoService = dtoService;
        }

        public Task RunAsync()
        {
            return Task.CompletedTask;
        }

        public void Dispose()
        {
        }

        public async Task<BaseItemDto> GetFeaturedMovie()
        {
            var config = Plugin.Instance.Configuration;
            if (string.IsNullOrEmpty(config.SelectedMovieId))
                return null;

            var movie = _libraryManager.GetItemById(config.SelectedMovieId);
            if (movie == null)
                return null;

            var dto = _dtoService.GetBaseItemDto(movie, new DtoOptions());
            
            // Add custom attributes for the client to use
            dto.Overview = $"<div class='movieOfTheWeek{(config.EnableGlowEffect ? " with-glow" : "")}'>{dto.Overview}</div>";
            
            return dto;
        }
    }
} 