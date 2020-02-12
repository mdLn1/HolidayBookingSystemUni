using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HolidayBookingSystem
{
    class TextBox_Password : TextBox
    {
        [Browsable(true)]
        [Category("Custom Behavior")]
        [Description("Sets the Textbox as a Password Textbox!")]
        
        public TextBox_Password()
        {
            // Set to no text.
            this.Text = "";
            // The password character is an asterisk.
            this.PasswordChar = '*';
            // The control will allow no more than 14 characters.
            this.MaxLength = 32;
        }

    }
}
