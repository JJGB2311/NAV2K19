using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsultasInteligentes;


namespace CapaDeDiseno
{
	public partial class Compleja : Form
	{
		public Compleja(string user)
		{
			InitializeComponent();
			ComponenteConsultas ci = new ComponenteConsultas();
			ci.ObtenerUsuario(user);
			Point pos = new Point(0, 0);
			ci.Location = pos;
			this.Controls.Add(ci);
		}
	}
}
