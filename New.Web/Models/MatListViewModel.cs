using New.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace New.Web.Models
{
    public class MatListViewModel
    {
        public IEnumerable<Material> Materials { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
        public IEnumerable<Sheet> Sheets { get; set; }
    }
}