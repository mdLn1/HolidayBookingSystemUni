using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HBSDatabase;

namespace HBSTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            test();
        }

        public void test()
        {
            using (HBSModel _entity = new HBSModel())
            {
                var _user = _entity.Users.ToList();
                Console.WriteLine(_user[0].Username);
            }
        } 

    }
}
