
namespace sudoku.Services.Loader
{
    public interface ILoadData
    {
        public (SudokuBoardViewModel? board, string error) Load(string filename);
    }
}
