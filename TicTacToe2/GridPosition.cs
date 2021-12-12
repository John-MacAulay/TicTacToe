using System;

namespace TicTacToe2
{
    public class GridPosition
    {
        
        public GridPosition(int row, int column )
        {
            Row = row;
            Column = column;
        }
        // public properties go below the constructor
        // private properties go above   - check if ya want JB
        public int Row { get; set; }
        public int Column { get; set; }
        
        // This override below  which changes compare by reference to compare by value for this object : 
        // stops equality checking using memory location but rather uses value references as described below
        // get this stuff via right click generate and then equality members.
        
        protected bool Equals(GridPosition other)
        {
            return Row == other.Row && Column == other.Column;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((GridPosition) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Row, Column);
        }
    }
}
