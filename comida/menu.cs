using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace comida
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cadcli form = new cadcli(); 
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            concli form = new concli();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cadpro form = new cadpro();
            form.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conpro form = new conpro();
            form.ShowDialog();
        }
    }
}
