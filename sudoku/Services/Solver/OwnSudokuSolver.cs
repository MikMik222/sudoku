using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudoku.Services.Solver
{

    internal class SudokuSolver : ISudokuSolver
    {

        public int[,]? Solve(int[,] board)
        {
            int[,] boardCopy = (int[,])board.Clone();

            if (SolveIterative(boardCopy))
                return boardCopy;
            else
                return null;
        }

        private bool SolveIterative(int[,] board)
        {
            var emptyCells = GetEmptyCells(board);
            var stack = new Stack<(int row, int col, int nextNum)>();
            int index = 0;

            while (index < emptyCells.Count)
            {
                var (row, col) = emptyCells[index];
                int startNum = GetStartNumberForCell(stack, row, col);

                bool placedNumber = TryPlaceNumber(board, row, col, startNum, stack);

                if (placedNumber)
                {
                    index++;
                }
                else
                {
                    index--;
                    if (index < 0)
                        return false;
                }
            }

            return true;
        }
        
        private int GetStartNumberForCell(Stack<(int row, int col, int nextNum)> stack, int row, int col)
        {
            if (stack.Count > 0 && stack.Peek().row == row && stack.Peek().col == col)
            {
                var top = stack.Pop();
                return top.nextNum;
            }
            return 1;
        }

        private bool TryPlaceNumber(int[,] board, int row, int col, int startNum, Stack<(int row, int col, int nextNum)> stack)
        {
            board[row, col] = 0; 

            for (int num = startNum; num <= 9; num++)
            {
                if (CanPlaceNumber(board, row, col, num))
                {
                    board[row, col] = num;
                    stack.Push((row, col, num + 1)); 
                    return true;
                }
            }

            return false; // No valid number found
        }

        private List<(int row, int col)> GetEmptyCells(int[,] board)
        {
            var list = new List<(int, int)>();
            for (int r = 0; r < 9; r++)
                for (int c = 0; c < 9; c++)
                    if (board[r, c] == 0)
                        list.Add((r, c));
            return list;
        }

        private bool CanPlaceNumber(int[,] board, int row, int col, int num)
        {
            return !IsInRow(board, row, num)
                && !IsInColumn(board, col, num)
                && !IsInBox(board, row, col, num);
        }

        private bool IsInRow(int[,] board, int row, int num)
        {
            for (int c = 0; c < 9; c++)
                if (board[row, c] == num)
                    return true;
            return false;
        }

        private bool IsInColumn(int[,] board, int col, int num)
        {
            for (int r = 0; r < 9; r++)
                if (board[r, col] == num)
                    return true;
            return false;
        }

        private bool IsInBox(int[,] board, int row, int col, int num)
        {
            int boxStartRow = (row / 3) * 3;
            int boxStartCol = (col / 3) * 3;

            for (int r = boxStartRow; r < boxStartRow + 3; r++)
                for (int c = boxStartCol; c < boxStartCol + 3; c++)
                    if (board[r, c] == num)
                        return true;
            return false;
        }
    }

}