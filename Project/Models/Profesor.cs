using Project.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Project.Models
{
    public class Profesor
    {
        public int IDProfesor { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public byte[]? Picture { get; set; }

        public BitmapImage Image
        {
            get => ImageUtils.ByteArrayToBitmapImage(Picture!);
        }

        public string FullName() => $"{FirstName} {LastName}";
    }
}
