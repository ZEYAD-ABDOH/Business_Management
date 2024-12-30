using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Arti.Client.Models
{
    [Flags]
    public enum StatusRequest
    {
        None =     0b_0000_0000,

        Completed= 0b_0000_0001,       // مكتمل
        InProgress = 0b_0000_0010,     // قيد التنفيذ
        Pending = 0b_0000_0100,         // معلق
        Cancelled = 0b_0000_1000,      // ملغي
        OnHold = 0b_0001_0000         // قيد الانتظار
    }
}
