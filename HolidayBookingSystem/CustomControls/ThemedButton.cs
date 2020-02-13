using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace HolidayBookingSystem.CustomControls
{
    class ThemedButton : Button
    {
        [Browsable(true)]
        [Category("Custom Behavior")]
        [Description("Sets a button with custom design")]
        public ThemedButton()
        {
            this.BackColor = System.Drawing.Color.IndianRed;
            this.CausesValidation = false;
            this.Cursor = Cursors.Hand;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new Padding(2);
            this.Size = new System.Drawing.Size(132, 43);
            this.TabIndex = 9;
            this.UseVisualStyleBackColor = false;
        }
    }
}
