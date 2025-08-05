public class SudokuValidator : ISudokuValidator
{
    public void Validate(SudokuBoardViewModel board)
    {
        ResetInvalidFlags(board);
        ValidateRows(board);
        ValidateColumns(board);
        ValidateSubgrids(board);
    }

    private void ResetInvalidFlags(SudokuBoardViewModel board)
    {
        for (int row = 0; row < 9; row++)
            for (int col = 0; col < 9; col++)
                board.Cells[row][col].IsInvalid = false;
    }

    private void ValidateRows(SudokuBoardViewModel board)
    {
        for (int row = 0; row < 9; row++)
        {
            var cells = GetNonEmptyCells(board, row, 0, row, 8);
            MarkConflicts(cells, board);
        }
    }

    private void ValidateColumns(SudokuBoardViewModel board)
    {
        for (int col = 0; col < 9; col++)
        {
            var cells = GetNonEmptyCells(board, 0, col, 8, col);
            MarkConflicts(cells, board);
        }
    }

    private void ValidateSubgrids(SudokuBoardViewModel board)
    {
        for (int blockRow = 0; blockRow < 3; blockRow++)
        {
            for (int blockCol = 0; blockCol < 3; blockCol++)
            {
                int startRow = blockRow * 3;
                int startCol = blockCol * 3;
                int endRow = startRow + 2;
                int endCol = startCol + 2;

                var cells = GetNonEmptyCells(board, startRow, startCol, endRow, endCol);
                MarkConflicts(cells, board);
            }
        }
    }

    private List<(int value, int row, int col)> GetNonEmptyCells(
        SudokuBoardViewModel board,
        int startRow,
        int startCol,
        int endRow,
        int endCol)
    {
        var result = new List<(int value, int row, int col)>();

        for (int row = startRow; row <= endRow; row++)
        {
            for (int col = startCol; col <= endCol; col++)
            {
                int value = board.Cells[row][col].Value;
                if (value != 0)
                {
                    result.Add((value, row, col));
                }
            }
        }

        return result;
    }

    private void MarkConflicts(List<(int value, int row, int col)> cells, SudokuBoardViewModel board)
    {
        var valuePositions = new Dictionary<int, List<(int row, int col)>>();

        foreach (var (value, row, col) in cells)
        {
            if (!valuePositions.ContainsKey(value))
                valuePositions[value] = new List<(int, int)>();

            valuePositions[value].Add((row, col));
        }

        foreach (var kvp in valuePositions)
        {
            if (kvp.Value.Count > 1)
            {
                foreach (var (row, col) in kvp.Value)
                {
                    board.Cells[row][col].IsInvalid = true;
                }
            }
        }
    }
}
