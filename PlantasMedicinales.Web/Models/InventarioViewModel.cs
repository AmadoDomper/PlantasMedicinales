using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlantasMedicinales.Web.Models
{
    public class InventarioViewModel
    {
            public string ProductName { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public Nullable<int> Price { get; set; }
            public Nullable<int> ImageId { get; set; }
            public HttpPostedFileWrapper ImageFile { get; set; }
    }
}