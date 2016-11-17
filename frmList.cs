using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Runsome
{
    public partial class frmList : Form
    {
        public frmList(List<string> x)
        {
            InitializeComponent();
            foreach(string s in x)
            {
                lvFiles.Items.Add(s);
            }
        }

    }
}
