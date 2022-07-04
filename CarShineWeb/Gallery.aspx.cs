using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarShineWeb
{
    public partial class Gallery : System.Web.UI.Page
    {
        public List<string> ImagesForGallery { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            var images = System.IO.Directory.GetFiles(Server.MapPath("new-images\\gallery"));
            
            ImagesForGallery = new List<string>();
            foreach (var i in images) {

                FileInfo fi = new FileInfo(i);
                ImagesForGallery.Add(fi.Name);
            }

        }
    }
}