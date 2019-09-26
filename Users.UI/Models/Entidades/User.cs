using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Users.UI.Models
{
   
    [Table("User")]
    public class User 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]      
        [Required(ErrorMessage = " El Id es requerido")]
        public int Id { get; set; }
      
        [StringLength(200)]
        [Required(AllowEmptyStrings = false, ErrorMessage = " El nombre es obligatorio")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreateDate { get; set; }
        [DataType(DataType.Date)]

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime UpdateDate { get; set; }



        //public User(int id, string name, DateTime createDate, DateTime updateDate)
        //{
        //    this.Id = id;
        //    this.Name = name;
        //    this.CreateDate = createDate;
        //    this.UpdateDate = updateDate;
        //}
    }
}