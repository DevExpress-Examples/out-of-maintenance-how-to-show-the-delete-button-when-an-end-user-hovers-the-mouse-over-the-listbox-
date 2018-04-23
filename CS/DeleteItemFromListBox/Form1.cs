using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DeleteItemFromListBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            new DeleteHelper(listBoxControl1);
        }
    }
}
