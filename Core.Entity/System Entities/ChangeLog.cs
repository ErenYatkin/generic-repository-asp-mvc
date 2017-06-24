
using System.Web.Mvc;

namespace ELTTurkey.Entity
{
    public class ChangeLog : Core.Entity.EntityHistorical
    {
        public string Title { get; set; }
        public string Version { get; set; }

        [AllowHtml]
        public string Summary { get; set; }
        public AppCore.CoreEnum.Project_Type ChangelogFor { get; set; }
    }
}
