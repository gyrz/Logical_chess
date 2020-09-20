using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_Game
{
	public partial class BaseDialog : Form
	{
		public BaseDialog()
		{
			InitializeComponent();
		}

		private void _GameRules_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start( AppDomain.CurrentDomain.BaseDirectory + "..\\..\\gamerules\\rules.txt");
		}

		private void _StartGame_Click(object sender, EventArgs e)
		{
			Hide();
			Gui.GameDialog dialogGameDialog = new Gui.GameDialog();
			dialogGameDialog.ShowDialog();
			Close();
		}

		private void _Button1_Click( object sender, EventArgs e )
		{
			Close();
		}
	}
}
