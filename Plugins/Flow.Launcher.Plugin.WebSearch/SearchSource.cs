using System.IO;
using System.Windows.Media;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Flow.Launcher.Infrastructure.Image;
using Flow.Launcher.Infrastructure;
using System.Reflection;

namespace Flow.Launcher.Plugin.WebSearch
{
    public class SearchSource : BaseModel
    {
        public string Title { get; set; }
        public string ActionKeyword { get; set; }

        [NotNull]
        public string Icon { get; set; } = "web_search.png";

        public bool CustomIcon { get; set; } = false;

        /// <summary>
        /// Default icons are placed in Images directory in the app location. 
        /// Custom icons are placed in the user data directory
        /// </summary>
        [JsonIgnore]
        public string IconPath 
        {
            get
            {
                if (CustomIcon)
                    return Path.Combine(Main.CustomImagesDirectory, Icon);

                return Path.Combine(Main.DefaultImagesDirectory, Icon);
            }
        }

        public string Url { get; set; }
        public bool Enabled { get; set; }

        public SearchSource DeepCopy()
        {
            var webSearch = new SearchSource
            {
                Title = string.Copy(Title),
                ActionKeyword = string.Copy(ActionKeyword),
                Url = string.Copy(Url),
                Icon = string.Copy(Icon),
                CustomIcon = CustomIcon,
                Enabled = Enabled
            };
            return webSearch;
        }
    }
}