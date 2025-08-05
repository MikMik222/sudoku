public class SudokuBoardConverter : ISudokuBoardConverter
{
    public int[,] ToArray(SudokuBoardViewModel board)
    {
        int[,] result = new int[9, 9];
        for (int r = 0; r < 9; r++)
            for (int c = 0; c < 9; c++)
                result[r, c] = board.Cells[r][c].Value;

        return result;
    }

    public void FromArray(SudokuBoardViewModel board, int[,] data)
    {
        for (int r = 0; r < 9; r++)
            for (int c = 0; c < 9; c++)
                    board.Cells[r][c].Value = data[r, c];
    }
    public void CopyValues(SudokuBoardViewModel from, SudokuBoardViewModel to)
    {
        for (int r = 0; r < 9; r++)
        {
            for (int c = 0; c < 9; c++)
            {
                to.Cells[r][c].Value = from.Cells[r][c].Value;
                to.Cells[r][c].IsInvalid = from.Cells[r][c].IsInvalid;
            }
        }
    }
}
