using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Chess_Game.Resources
{
	public class CoordPair
	{
		public int  iX { get; set; }
		public int  iY { get; set; }
		public bool bIsAvalible { get; set; }
		public bool bIsOccupied { get; set; }

		public CoordPair()
		{
			iX = 0;
			iY = 0;
			bIsAvalible = true;
			bIsOccupied = false;
		}

		public CoordPair( int iX, int iY )
		{
			this.iX = iX;
			this.iY = iY;
			bIsAvalible = true;
			bIsOccupied = false;
		}
	}
}
