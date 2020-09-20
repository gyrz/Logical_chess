using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess_Game.Resources;


namespace Chess_Game.Resources
{
	class Basis
	{
		public List<CoordPair> listTable { get; set; }
		static public Dictionary<int, string> errorDictionary = new Dictionary<int, string>();

		public Basis()
		{
			listTable = new List<CoordPair>();
			_CreateList();
			_FillErrors();
		}

		~Basis()
		{
			listTable.Clear();
			errorDictionary.Clear();
		}

		private void _CreateList()
		{
			for( int iPos = 0; iPos < 8; ++iPos )
				for( int iPosInner = 0; iPosInner < 8; ++iPosInner )
					listTable.Add( new CoordPair( iPos, iPosInner ) );
		}

		public List<CoordPair> GetListAvalibleSpots()
		{
			List<CoordPair> listOutput = new List<CoordPair>();
			foreach( CoordPair cp in listTable )
			{
				if( cp.bIsOccupied == true )
					continue;

				if( cp.bIsAvalible == false )
					continue;

				listOutput.Add( cp );
			}

			return listOutput;
		}

		public List<CoordPair> PossibleGoodMoves( Piece.EPieceType epiecetype )
		{
			List<CoordPair> listOutput = new List<CoordPair>();

			List<CoordPair> listCoordPair = GetListAvalibleSpots();
			for( int iPos = 0; iPos < listCoordPair.Count(); iPos++ )
			{
				CoordPair CoordPairIndex = listCoordPair[iPos];

				Piece Piece = new Piece( CoordPairIndex, epiecetype );
				Piece.bSimulate = true;
				Piece.MakeCoordsUnavalible( listTable );
				if( Piece.iError == 1 )
					continue;

				listOutput.Add( CoordPairIndex );
			}

			return listOutput;
		}

		public int GenerateRandomNumber( int imin, int imax )
		{
			return new Random().Next( imin, imax );
		}

		public Piece ComputerMove( Piece.EPieceType epiecetype )
		{
			List<CoordPair> listPossibleGoodMoves = PossibleGoodMoves( epiecetype );
			int iIndex = GenerateRandomNumber( 1, listPossibleGoodMoves.Count() + 1 );

			CoordPair ComputerCoordPair = new CoordPair();
			if( listPossibleGoodMoves.Count() > 0 )
				ComputerCoordPair = listPossibleGoodMoves[ iIndex - 1 ];

			return new Piece( ComputerCoordPair, epiecetype );
		}

		public bool CheckIsThereAnyMove( Piece.EPieceType epiecetype )
		{
			if( PossibleGoodMoves( epiecetype ).Count() > 0 )
				return true;

			return false;
		}

		private void _FillErrors()
		{
			errorDictionary.Add( 1, "Leütöttek sajnos :(" );
			errorDictionary.Add( 2, "A bábud leüt valakit :(" );
			errorDictionary.Add( 3, "Nincs több lépés :(" );
		}

		public void ClearListTypes()
		{
			listTable.Clear();
			errorDictionary.Clear();
		}
	}
}
