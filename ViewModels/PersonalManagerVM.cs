using PersonelMVC.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonelMVC.ViewModels
{
    public class PersonalManagerVM
    {
        public IEnumerable<Department> Departments { get; set; }

        public Personnal Personnal { get; set; }
    }
}