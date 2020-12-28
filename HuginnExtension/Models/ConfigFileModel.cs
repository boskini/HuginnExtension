namespace HuginnExtension.Models
{
    public class ConfigFileModel
    {
        public ConfigFileItemModel[] items { get; set; }
    }

    public class ConfigFileItemModel
    {
        public string ext { get; set; }
        public string command { get; set; }
    }
}
