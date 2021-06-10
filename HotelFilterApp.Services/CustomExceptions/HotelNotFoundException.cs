using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFilterApp.Services.CustomExceptions
{
    public class HotelNotFoundException: Exception
    {
        public HotelNotFoundException(string message)
            : base(message)
        {

        }
    }
}
