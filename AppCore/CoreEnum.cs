using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore
{
    /// <summary>
    /// This class stores generic Types.
    /// </summary>
    public class CoreEnum
    {
        /// <summary>
        /// Specifies the process result.
        /// </summary>
        public enum Result_Type
        {
            Failed = 0,
            Success = 1,
            NoData = 2
        };
        /// <summary>
        /// Specifies the entity status.
        /// </summary>
        public enum Status_Type
        {
            Passive = 0,
            Active = 1,
            Deleted = 2
        };

        /// <summary>
        /// Specifies the projects that solution contains.
        /// </summary>
        public enum Project_Type
        {
            All = 0,
            Framework = 1,
            AdminPanel = 2,
            PublicUI = 3
        };

        /// <summary>
        /// Specifies the product types 
        /// </summary>
        public enum Product_Type
        {
            Other = 0,
            Bundle = 1,
            Standalone = 2
        };

        /// <summary>
        /// Specifies the system parameters
        /// </summary>
        public enum Parameter_Type
        {
            ProductImageUpload = 0,
            PublisherImageUpload = 1,
            AuthorImageUpload = 2,
            CatalogCoverImageUpload = 3,
            ImagesForUI = 4
        };
    }
}
