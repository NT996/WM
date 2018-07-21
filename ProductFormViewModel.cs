using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Models;

namespace Project.ViewModels
{
    public class ProductFormViewModel
    {
        public Product Product { get; set; }
        public string Title
        {
            get
            {
                if (Product != null && Product.ID != 0)
                    return "Edit Product";
                return "New Product";
            }
        }
    }
}