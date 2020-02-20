using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolutionUtils
{
    class PhoneTextBox : TextBox
    {
        [Browsable(true)]
        [Category("Custom Behavior")]
        [Description("Sets the Textbox as a Phone Textbox!")]

        public PhoneTextBox()
        {
            this.TextChanged += new EventHandler(textChanged);
            this.KeyUp += new KeyEventHandler(keyDown);
            this.ForeColor = System.Drawing.Color.Black;
            this.Focus();
            this.SelectionStart = this.Text.Length;
        }

        protected void textChanged(object sender, EventArgs e)
        {
            if(this.Text.Length > 11)
            {
                this.ForeColor = System.Drawing.Color.Red;
            } else
            {
                this.ForeColor = System.Drawing.Color.Black;
            }
        }

        public void keyDown(object sender, EventArgs e)
        {
            string s = Regex.Replace(this.Text, @"\D", "");
            this.Text = s;
            this.SelectionStart = this.Text.Length;
        }
    }
}
