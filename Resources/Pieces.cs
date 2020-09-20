using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Chess_Game.Resources
{
	public class Piece : CoordPair
	{
		public enum EPieceType
		{
			PT_UNDEFINED,          // Ismeretlen
			PT_KNIGHT,             // Huszar
			PT_QUEEN,              // Vezer
			PT_KING,               // Kiraly
			PT_BISHOP,             // Futo
			PT_ROOK                // Bastya
		}
		public EPieceType ePieceType{ get; set; }
		public int iError { get; set; }
		public bool bSimulate { get; set; }

		public Piece()
		{
			ePieceType = EPieceType.PT_UNDEFINED;
			iError = 0;
		}

		public Piece( CoordPair coordpair, EPieceType epiece )
		{
			ePieceType = epiece;
			iX = coordpair.iX;
			iY = coordpair.iY;
			bIsAvalible = coordpair.bIsAvalible;
			bIsOccupied = coordpair.bIsOccupied;
			iError = 0;
			bSimulate = false;
		}

		protected bool _CheckCoordPair( CoordPair coordpair )
		{
			if( coordpair != null )
			{
				if( coordpair.bIsOccupied == true )
				{
					iError = 1;
					return false;
				}
				if( !bSimulate )
					coordpair.bIsAvalible = false;
			}

			return true;
		}

		protected void _MakeUnavalible_Lines( List<CoordPair> listcoordpair, int imax )
		{
			for( int iPos = 1; iPos <= imax; iPos++ )
			{
				CoordPair Cp = listcoordpair.Find( cp => cp.iX == new CoordPair( iX + iPos, iY ).iX &&
				                                         cp.iY == new CoordPair( iX + iPos, iY ).iY  );
				if( _CheckCoordPair( Cp ) == false )
					break;

				Cp = listcoordpair.Find( cp => cp.iX == new CoordPair( iX, iY + iPos ).iX &&
				                               cp.iY == new CoordPair( iX, iY + iPos ).iY  );
				if( _CheckCoordPair( Cp ) == false )
					break;

				Cp = listcoordpair.Find( cp => cp.iX == new CoordPair( iX - iPos, iY ).iX &&
				                               cp.iY == new CoordPair( iX - iPos, iY ).iY  );
				if( _CheckCoordPair( Cp ) == false )
					break;

				Cp = listcoordpair.Find( cp => cp.iX == new CoordPair( iX, iY - iPos ).iX &&
				                               cp.iY == new CoordPair( iX, iY - iPos ).iY  );
				if( _CheckCoordPair( Cp ) == false )
					break;
			}
		}

		protected void _MakeUnavalible_Diagonal( List<CoordPair> listcoordpair, int imax )
		{
			for( int iPos = 1; iPos <= imax; iPos++ )
			{
				CoordPair objCoordPair = listcoordpair.Find( cp => cp.iX == new CoordPair( iX - iPos, iY - iPos ).iX &&
				                                                   cp.iY == new CoordPair( iX - iPos, iY - iPos ).iY  );
				if( _CheckCoordPair( objCoordPair ) == false )
					break;

				objCoordPair = listcoordpair.Find( cp => cp.iX == new CoordPair( iX - iPos, iY + iPos ).iX &&
				                                         cp.iY == new CoordPair( iX - iPos, iY + iPos ).iY  );
				if( _CheckCoordPair( objCoordPair ) == false )
					break;

				objCoordPair = listcoordpair.Find( cp => cp.iX == new CoordPair( iX + iPos, iY  + iPos ).iX &&
				                                         cp.iY == new CoordPair( iX + iPos, iY  + iPos ).iY  );
				if( _CheckCoordPair( objCoordPair ) == false )
					break;

				objCoordPair = listcoordpair.Find( cp => cp.iX == new CoordPair( iX + iPos, iY - iPos ).iX &&
				                                         cp.iY == new CoordPair( iX + iPos, iY - iPos ).iY  );
				if( _CheckCoordPair( objCoordPair ) == false )
					break;
			}
		}

		public List<CoordPair> MakeCoordsUnavalible( List<CoordPair> listcoordpair )
		{
			CoordPair objCoordpair = listcoordpair.Find( cp => cp.iX == new CoordPair( iX, iY ).iX &&
			                                                   cp.iY == new CoordPair( iX, iY ).iY  );
			if( objCoordpair != null && bSimulate == false )
				objCoordpair.bIsOccupied = true;

			switch ( ePieceType )
			{
				case EPieceType.PT_KNIGHT:
					_MakeUnavalible_Knight( listcoordpair );
					break;
				case EPieceType.PT_QUEEN:
					_MakeUnavalible_Queen( listcoordpair );
					break;
				case EPieceType.PT_KING:
					_MakeUnavalible_King( listcoordpair );
					break;
				case EPieceType.PT_BISHOP:
					_MakeUnavalible_Bishop( listcoordpair );
					break;
				case EPieceType.PT_ROOK:
					_MakeUnavalible_Rook( listcoordpair );
					break;
			}

			return listcoordpair;
		}

		protected void _MakeUnavalible_Knight( List<CoordPair> listcoordpair )
		{
			// ez egy trukkos kis babu, de lagalabb cuki
			CoordPair objCoordPair = listcoordpair.Find( cp => cp.iX == new CoordPair( iX + 2, iY + 1 ).iX &&
			                                                   cp.iY == new CoordPair( iX + 2, iY + 1 ).iY  );
			if( _CheckCoordPair( objCoordPair ) == false )
				return;

			objCoordPair = listcoordpair.Find( cp => cp.iX == new CoordPair( iX + 2, iY - 1 ).iX &&
			                                         cp.iY == new CoordPair( iX + 2, iY - 1 ).iY  );
			if( _CheckCoordPair( objCoordPair ) == false )
				return;

			objCoordPair = listcoordpair.Find( cp => cp.iX == new CoordPair( iX - 2, iY - 1 ).iX &&
			                                         cp.iY == new CoordPair( iX - 2, iY - 1 ).iY );
			if( _CheckCoordPair( objCoordPair ) == false )
				return;

			objCoordPair = listcoordpair.Find( cp => cp.iX == new CoordPair( iX - 2, iY + 1 ).iX &&
			                                         cp.iY == new CoordPair( iX - 2, iY + 1 ).iY );
			if( _CheckCoordPair( objCoordPair ) == false )
				return;

			objCoordPair = listcoordpair.Find( cp => cp.iX == new CoordPair( iX + 1, iY + 2 ).iX &&
			                                         cp.iY == new CoordPair( iX + 1, iY + 2 ).iY );
			if( _CheckCoordPair( objCoordPair ) == false )
				return;

			objCoordPair = listcoordpair.Find( cp => cp.iX == new CoordPair( iX + 1, iY - 2 ).iX &&
			                                         cp.iY == new CoordPair( iX + 1, iY - 2 ).iY );
			if( _CheckCoordPair( objCoordPair ) == false )
				return;

			objCoordPair = listcoordpair.Find( cp => cp.iX == new CoordPair( iX - 1, iY - 2 ).iX &&
			                                         cp.iY == new CoordPair( iX - 1, iY - 2 ).iY );
			if( _CheckCoordPair( objCoordPair ) == false )
				return;

			objCoordPair = listcoordpair.Find( cp => cp.iX == new CoordPair( iX - 1, iY + 2 ).iX &&
			                                         cp.iY == new CoordPair( iX - 1, iY + 2 ).iY );
			if( _CheckCoordPair( objCoordPair ) == false )
				return;
		}

		protected void _MakeUnavalible_Queen( List<CoordPair> listcoordpair )
		{
			_MakeUnavalible_Diagonal( listcoordpair, 8 );
			_MakeUnavalible_Lines(    listcoordpair, 8 );
		}

		protected void _MakeUnavalible_King( List<CoordPair> listcoordpair )
		{
			_MakeUnavalible_Diagonal( listcoordpair, 1 );
			_MakeUnavalible_Lines(    listcoordpair, 1 );
		}

		protected void _MakeUnavalible_Bishop( List<CoordPair> listcoordpair )
		{
			_MakeUnavalible_Diagonal( listcoordpair, 8 );
		}

		protected void _MakeUnavalible_Rook( List<CoordPair> listcoordpair )
		{
			_MakeUnavalible_Lines( listcoordpair, 8 );
		}
	}
}
