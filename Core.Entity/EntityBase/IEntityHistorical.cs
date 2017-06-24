using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
    public interface IEntityHistorical
    {
        // Kayıt geçmişinin tutulmasının önemli olduğu entitylerde kişi bilgisi tutar
        int? CreatedBy { get; set; }
        // Eklenme tarihini barındırır
        DateTime? CreatedDate { get; set; }
        
        // En son güncelleme yapan kullanıcıyı tutacak olan alandır.
        int? LastModifiedBy { get; set; }

        // Son güncelleme tarihini tutacak olan alandır.
        DateTime? LastModifiedDate { get; set; }

    }
}
