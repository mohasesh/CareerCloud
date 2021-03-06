using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CareerCloud.Pocos
{
    [Table("Security_Roles")]
   public class SecurityRolePoco : IPoco
    {
        public SecurityRolePoco()
        {
            SecurityLoginsRoles = new HashSet<SecurityLoginsRolePoco>();
        }
        [Key]
        public Guid Id { get; set; }
        public string Role { get; set; }
        [Column("Is_Inactive")]
        public Boolean IsInactive { get; set; }
        public virtual ICollection<SecurityLoginsRolePoco> SecurityLoginsRoles { get; set; }
    }
}
