using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaDeDiseno
{
    public partial class Ayudas : Form
    {
        public Ayudas()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog rutaFile = new OpenFileDialog();
            rutaFile.InitialDirectory = "c:\\";
            rutaFile.Filter = "chm files (*.chm)|*.chm";
            if (rutaFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                textBox1.Text = rutaFile.FileName;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog rutaFile = new OpenFileDialog();
            rutaFile.InitialDirectory = "c:\\";
            rutaFile.Filter = "chm files (*.html)|*.html";
            if (rutaFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                textBox3.Text = rutaFile.FileName;
            }
        }
    }
}
