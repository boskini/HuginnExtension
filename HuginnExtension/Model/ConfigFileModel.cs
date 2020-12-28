using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuginnExtension.Model
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
