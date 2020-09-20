using Chess_Game.Resources;
using Chess_Game.Gui;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_Game.Gui
{
	public partial class GameDialog : Form
	{
		public Button[,] arrButton = new Button[8,8];

		private Basis _objBasis;
		internal Basis objBasis { get => _objBasis; set => _objBasis = value; }

		public Piece.EPieceType ePieceType;

		public GameDialog()
		{
			objBasis = new Basis();
			InitializeComponent();
			_InitGrid();
			_RollPiece();
		}

		private void _RollPiece()
		{
			ePieceType = ( Piece.EPieceType )objBasis.GenerateRandomNumber( 1, 6 );
			switch( ePieceType )
			{
				case Piece.EPieceType.PT_KING:
				pictureBox1.Image = Properties.Resources.King_200;
				label6.Text = "Király";
				break;
				case Piece.EPieceType.PT_BISHOP:
				pictureBox1.Image = Properties.Resources.Bishop_200;
				label6.Text = "Futó";
				break;
				case Piece.EPieceType.PT_KNIGHT:
				pictureBox1.Image = Properties.Resources.Knight_200;
				label6.Text = "Huszár";
				break;
				case Piece.EPieceType.PT_QUEEN:
				pictureBox1.Image = Properties.Resources.Queen_200;
				label6.Text = "Vezér";
				break;
				case Piece.EPieceType.PT_ROOK:
				pictureBox1.Image = Properties.Resources.Rook_200;
				label6.Text = "Bástya";
				break;
			}
		}

		private void _InitGrid()
		{
			int iSize = panel1.Height / 8;

			for( int iPos = 0; iPos < 8; ++iPos )
			{
				for( int iPosInner = 0; iPosInner < 8; ++iPosInner )
				{
					arrButton[ iPos, iPosInner ] = new Button();
					arrButton[ iPos, iPosInner ].Height = iSize;
					arrButton[ iPos, iPosInner ].Width  = iSize;
					arrButton[ iPos, iPosInner ].Location = new Point( iPos * iSize, iPosInner * iSize );
					arrButton[ iPos, iPosInner ].Text = " ";
					arrButton[ iPos, iPosInner ].Tag = objBasis.listTable.Find( cp => cp.iX == new CoordPair( iPos, iPosInner ).iX && cp.iY == new CoordPair( iPos, iPosInner ).iY );
					arrButton[ iPos, iPosInner ].Click += _ButtonClickEvent;

					panel1.Controls.Add( arrButton[iPos, iPosInner] );
				}

			}
		}

		private void _AddImagetoButton( Button button, Piece.EPieceType epiecetype )
		{
			switch( ePieceType )
			{
				case Piece.EPieceType.PT_KING:
				button.Image = Properties.Resources.King_40;
				button.BackColor = Color.Aqua;
				break;
				case Piece.EPieceType.PT_BISHOP:
				button.Image = Properties.Resources.Bishop_40;
				button.BackColor = Color.Fuchsia;
				break;
				case Piece.EPieceType.PT_KNIGHT:
				button.Image = Properties.Resources.Knight_40;
				button.BackColor = Color.Orange;
				break;
				case Piece.EPieceType.PT_QUEEN:
				button.Image = Properties.Resources.Queen_40;
				button.BackColor = Color.Yellow;
				break;
				case Piece.EPieceType.PT_ROOK:
				button.Image = Properties.Resources.Rook_40;
				button.BackColor = Color.Blue;
				break;
			}
		}

		private void _ButtonClickEvent( object sender, EventArgs e )
		{
			Button objButton = ( Button )sender;
			CoordPair objCoordPair = ( CoordPair )objButton.Tag;

			if( objCoordPair.bIsAvalible == false )
			{
				_TriggerEndGame( 1 );
				return;
			}

			Piece objPiece = new Piece( objCoordPair, ePieceType );
			_AddImagetoButton( objButton, ePieceType );

			objBasis.listTable = objPiece.MakeCoordsUnavalible( objBasis.listTable );

			if( objPiece.iError == 1 )
			{
				_TriggerEndGame( 2 );
				return;
			}

			if( !objBasis.CheckIsThereAnyMove( ePieceType ) )
			{
				_TriggerEndGame( -1, true );
				return;
			}

			objPiece = objBasis.ComputerMove( ePieceType );
			_AddImagetoButton( arrButton[objPiece.iX, objPiece.iY], ePieceType ); 
			objBasis.listTable = objPiece.MakeCoordsUnavalible( objBasis.listTable );

			if( checkBox1.Checked )
				_ColorButtons( Color.Red );

			_RollPiece();
			if( !objBasis.CheckIsThereAnyMove( ePieceType ) )
			{
				_TriggerEndGame( 3 );
			}
		}

		private void _TriggerEndGame( int ierrorcode, bool bresult = false )
		{
			if( bresult )
				MessageBox.Show( "NYERTÉÉÉÉL! :)" );
			else
				MessageBox.Show( "Vesztettél! :(\nOka: " + Basis.errorDictionary[ierrorcode] );

			_TriggerQuestion();
		}

		private void _TriggerQuestion()
		{
			DialogResult dialogResult = MessageBox.Show("Szeretnél még egy kört játszani?", "Megpróbálod újra?", MessageBoxButtons.YesNo);
			if( dialogResult == DialogResult.Yes )
			{
				Hide();
				objBasis.ClearListTypes();
				GameDialog dialogGameDialog = new GameDialog();
				dialogGameDialog.ShowDialog();
				Close();
			}
			else
			{
				Close();
			}
		}

		private void _CheckBox1_CheckedChanged( object sender, EventArgs e )
		{
			if( checkBox1.Checked )
				_ColorButtons( Color.Red );
			else
				_ColorButtons( Color.Transparent );
		}

		private void _ColorButtons( Color color )
		{
			foreach( Button btn in arrButton )
			{
				CoordPair objCoordPair = (CoordPair)btn.Tag;

				if( !objCoordPair.bIsAvalible )
					btn.BackColor = color;
			}
		}

		private void _Button1_Click( object sender, EventArgs e )
		{
			Piece objPiece = objBasis.ComputerMove( ePieceType );
			arrButton[objPiece.iX, objPiece.iY].BackColor = Color.Green;
		}
	}
}
