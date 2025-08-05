namespace sudoku.Services.Solver
{
    public interface ISudokuSolver
    {
        public int[,]? Solve(int[,] board);
    }
}