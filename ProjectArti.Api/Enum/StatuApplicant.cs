namespace Arti.Client.Models
{
    [Flags]
    //BitWise operation (|,&,~,^)
    public enum StatuApplicant
    {
        None =     0b_0000_0000,
        Pending =  0b_0000_0001,       // قيد المراجعة
        Accepted = 0b_0000_0010,      // مقبول
        Rejected = 0b_0000_0100,     // مرفوض
        Interviewing= 0b_0000_1000,  // في مرحلة المقابلة
        Offered= 0b_0001_0000,       // تم تقديم عرض
        Hired = 0b_0010_0000,        // تم التوظيف
        OnHold = 0b_0100_0000,       // قيد الانتظار
    }
}
