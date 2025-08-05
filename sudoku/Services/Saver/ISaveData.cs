using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudoku.Services.Saver
{
    public interface ISaveData
    {
        public string Save(string fileName, SudokuBoardViewModel board);
    }
}
