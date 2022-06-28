using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserData.Models
{
    public class UserDataModel
    {
        public UserDataModel()
        {
            this.ID = 0;
            this.FirstName = null;
            this.LastName = null;
            this.Cellnumber = null;
        }
        public UserDataModel(int id,string first_Name, string last_Name,string cell_number)
        {
            this.ID = id;
            this.FirstName = first_Name;
            this.LastName = last_Name;
            this.Cellnumber = cell_number;
        }

        public int ID { get; set; }
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "First name is required")]
        public string LastName { get; set; }        
        [Required(ErrorMessage = "CellNo is required")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Cellphone Number.")]
        public string Cellnumber { get; set; }
  
    }
}