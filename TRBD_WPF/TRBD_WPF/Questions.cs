//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TRBD_WPF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Questions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Questions()
        {
            this.Answers = new HashSet<Answers>();
        }
    
        public int QuestionID { get; set; }
        public Nullable<int> TestID { get; set; }
        public string Question { get; set; }
        public string TrueAnswer { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Answers> Answers { get; set; }
        public virtual Test Test { get; set; }
    }
}