using MediaBrowser.Model.Plugins;

namespace MovieOfTheWeek.Configuration
{
    public class PluginConfiguration : BasePluginConfiguration
    {
        public string SelectedMovieId { get; set; }
        public bool EnableGlowEffect { get; set; }
        
        public PluginConfiguration()
        {
            EnableGlowEffect = true;
        }
    }
} 