using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Gomoku
{
    class Board
    {
        public static readonly int NODE_COUNT = 9;
        private static readonly Point NO_MATCH_POINT =new Point(-1, -1); 
        private static readonly int OFFSET = 75;
        private static readonly int NODE_RADIOUS = 10;
        private static readonly int NODE_DISTANCE = 75;
        private piece [,] pieces = new piece[NODE_COUNT,NODE_COUNT];
        private Point lastPlaceNode = NO_MATCH_POINT;
        public Point LastPlaceNode
        {
            get { return lastPlaceNode; }
        }
        public PieceType GetPieceType(int nodeIdX,int nodeIdY)
        {
            if (pieces[nodeIdX, nodeIdY] == null)
            {
                return PieceType.NONE;
            }
            else
            {
                return pieces[nodeIdX, nodeIdY].GetPieceType();
            }
        }
        public bool CanBePlaced(int x , int y)
        {
            //to  do: find nearliest Node;
            Point nodeId = FindTheCloseNode(x, y);
            //to  do: if no return false;
            if (nodeId == NO_MATCH_POINT)
            {
                return false;
            }
            if (pieces[nodeId.X, nodeId.Y] != null)
            {
                return false;
            }
            return true;
        }
        public piece PlaceAPiece(int x,int y,PieceType type)
        {
            Point nodeId = FindTheCloseNode(x, y);
            if (nodeId == NO_MATCH_POINT)
            {
                return null;
            }
            //Todo  
            if(pieces[nodeId.X,nodeId.Y] != null)
            {
                return null;
            }
            Point formPos = convertToFormPosition(nodeId);
            if (type == PieceType.BLACK)
            {
                pieces[nodeId.X, nodeId.Y] = new BlackPiece(formPos.X, formPos.Y);
            }
            else   
            {
                pieces[nodeId.X, nodeId.Y] = new WhitePiece(formPos.X, formPos.Y);
            }
            lastPlaceNode = nodeId;//Record lastPlace's poistion
            return pieces[nodeId.X, nodeId.Y];
        }
        private Point convertToFormPosition(Point nodeId)
        {
            Point formPosition = new Point();
            formPosition.X = nodeId.X * NODE_DISTANCE + OFFSET;
            formPosition.Y = nodeId.Y * NODE_DISTANCE + OFFSET;
            return formPosition;
        }
        private Point FindTheCloseNode(int x, int y)
        {
            int nodeIdX = FindTheCloseNode(x);
            if (nodeIdX == -1 || nodeIdX>= NODE_COUNT)
            {
                return NO_MATCH_POINT;
            }
            int nodeIdY = FindTheCloseNode(y);
            if (nodeIdY == -1 || nodeIdY >= NODE_COUNT)
            {
                return NO_MATCH_POINT;
            }
            return new Point (nodeIdX, nodeIdY);
        }
        private int FindTheCloseNode(int pos)
        {
            if (pos < OFFSET)
            {
                return -1;
            }
            pos -= OFFSET;
            int quotient = pos / NODE_DISTANCE;
            int remainder = pos % NODE_DISTANCE;
            if (remainder <= NODE_RADIOUS)
            {
                return quotient;
            }
            else if (remainder >= NODE_DISTANCE - NODE_RADIOUS)
            {
                return quotient + 1;
            }
            else
                return -1;
        }
    }
}
