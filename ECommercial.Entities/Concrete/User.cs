using ECommercial.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercial.Entities.Concrete
{
    public class User : IEntity
    {
        [Key]
        public int Id { get; set; }
        [StringLength(60)]
        [Column(TypeName = "NVarChar")]
        public string FirstName { get; set; }
        [StringLength(60)]
        [Column(TypeName = "NVarChar")]
        public string LastName { get; set; }
        [StringLength(60)]
        [Column(TypeName = "NVarChar")]
        public string Email { get; set; }
        [StringLength(60)]
        [Column(TypeName = "NVarChar")]
        public string Phone { get; set; }
        [StringLength(500)]
        [Column(TypeName = "NVarChar")]
        public string PasswordSalt { get; set; }
        [StringLength(500)]
        [Column(TypeName = "NVarChar")]
        public string PaswordHash { get; set; }
        public DateTime? DateOfSign { get; set; }
        [NotMapped]
        public virtual bool RememberMe { get; set; }
        public bool Status { get; set; }
        public List<UserFavorite> UserFavorites { get; set; }
    }
}
