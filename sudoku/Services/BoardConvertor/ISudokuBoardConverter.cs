public interface ISudokuBoardConverter
{
    int[,] ToArray(SudokuBoardViewModel board);
    void FromArray(SudokuBoardViewModel board, int[,] data);

    public void CopyValues(SudokuBoardViewModel from, SudokuBoardViewModel to);
}
