using System.ComponentModel;


public class SudokuBoardViewModel 
{
    public SudokuCell[][] Cells { get; set; }


    public event Action<int, int>? CellValueChanged;


    public SudokuBoardViewModel()
    {
        Cells = new SudokuCell[9][];
        for (int r = 0; r < 9; r++)
        {
            Cells[r] = new SudokuCell[9];
            for (int c = 0; c < 9; c++)
            {
                int row = r;
                int col = c;
                Cells[r][c] = new SudokuCell();
            }
        }
    }

    //public SudokuBoardViewModel()
    //{
    //    for (int r = 0; r < 9; r++)
    //        for (int c = 0; c < 9; c++)
    //        {
    //            int row = r;
    //            int col = c;
    //            Cells[r, c] = new SudokuCell();
    //        }
    //}

    internal void SetValue(int selectedRow, int selectedCol, int v, bool isGiven = false)
    {
        if (Cells[selectedRow][selectedCol].Value != v)
        {
            Cells[selectedRow][selectedCol].Value = v;
            CellValueChanged?.Invoke(selectedRow, selectedCol);
        }
    }

    internal void SetInvalid(int selectedRow, int selectedCol, bool isInvalid)
    {
        if (Cells[selectedRow][selectedCol].IsInvalid != isInvalid)
        {
            Cells[selectedRow][selectedCol].IsInvalid = isInvalid;
            CellValueChanged?.Invoke(selectedRow, selectedCol);
        }
    }
}