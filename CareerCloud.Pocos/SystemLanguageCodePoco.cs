using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CareerCloud.Pocos
{
    [Table("System_Language_Codes")]
   public  class SystemLanguageCodePoco : IPoco
    {
        public SystemLanguageCodePoco()
        {
            CompanyDescriptions = new HashSet<CompanyDescriptionPoco>();
        }
        [NotMapped]
        public Guid Id { get; set; }

        [Key]
        public string LanguageID { get; set; }
        public string Name { get; set; }
        [Column("Native_Name")]
        public string NativeName { get; set; }
        public virtual ICollection<CompanyDescriptionPoco> CompanyDescriptions { get; set; }
    }
}
