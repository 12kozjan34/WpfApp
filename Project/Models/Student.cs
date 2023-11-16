using Project.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Project.Models
{
    public class Student
    {
        public int IDStudent { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public byte[]? Picture { get; set; }
        public List<Kolegij>? Kolegiji { get; set; }

        public BitmapImage Image
        {
            get=> ImageUtils.ByteArrayToBitmapImage(Picture!);
        }
    }
}
