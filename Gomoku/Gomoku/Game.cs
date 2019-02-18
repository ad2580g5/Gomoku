﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    class Game
    {
        private Board board = new Board();
        private PieceType currentPlayer = PieceType.BLACK;
        private PieceType winner = PieceType.NONE;
        public PieceType Winner
        {
            get { return winner; }
        }
        public bool CanBePlaced(int x, int y)
        {
            return board.CanBePlaced(x,y);
        }
        public piece PlaceAPiece(int x,int y)
        {
            piece piece = board.PlaceAPiece(x,y, currentPlayer);
            if (piece != null)
            {
                //check Win?
                CheckWinner();
                if (currentPlayer == PieceType.BLACK)
                {
                    currentPlayer = PieceType.WHITE;
                }
                else if (currentPlayer == PieceType.WHITE)
                {
                    currentPlayer = PieceType.BLACK;
                }
                return piece;
            }
                    return null;
        }
        private void CheckWinner()
        {
            int centerX = board.LastPlaceNode.X;
            int centerY = board.LastPlaceNode.Y;
            //check 8 way
            for (int xDir = -1; xDir <= 1; xDir++)
            {
                for (int yDir = -1; yDir <= 1; yDir++)
                {
                    if (xDir == 0 && yDir == 0)
                    {
                        continue;
                    }



                    // Exclude middle situation
                    // Record howmany same color pieces 
                    int count = 1;
                    while (count < 5)
                    {
                        int targetX = centerX + count * xDir;
                        int targetY = centerY + count * yDir;
                        //Check color same?
                        if (targetX < 0 || targetX >= Board.NODE_COUNT ||
                            targetY < 0 || targetY >= Board.NODE_COUNT ||
                            board.GetPieceType(targetX, targetY) != currentPlayer)
                        {
                            break;
                        }
                        count++;
                    }
                    //Check if 5 pieces?
                    if (count == 5)
                    {
                        winner = currentPlayer;
                    }
                }
            }
        }
    }
}
