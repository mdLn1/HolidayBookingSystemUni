using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayBookingSystem
{
    class ComboItem
    {
        public string Text;
        public int ID;
        public ComboItem(string text, int id)
        {
            Text = text;
            ID = id;
        }
        public override string ToString()
        {
            return Text;
        }
    }
}
