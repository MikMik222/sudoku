using MaterialSkin.Controls;
using sudoku.Services.FileDialog;
using sudoku.Services.Loader;
using sudoku.Services.Saver;
using sudoku.Services.Solver;

namespace sudoku
{
    public partial class MainWindow : MaterialForm
    {
        private SudokuGridControl sudokuGrid;
        private ISudokuSolver sudokuSolver;
        private SudokuBoardViewModel viewModel;
        private ISudokuBoardConverter sudokuBoardConverter;
        private ISaveData saveData;
        private ILoadData loadData;
        private IOpenDialog openDialog;


        public MainWindow(ISudokuSolver sudokuSolver, ISudokuBoardConverter sudokuBoardConverter,
            ISaveData saveData, IOpenDialog openDialog, ILoadData loadData)
        {
            InitializeComponent();
            viewModel = new SudokuBoardViewModel();
            InitSudokuGrid();
            this.sudokuSolver = sudokuSolver;
            this.sudokuBoardConverter = sudokuBoardConverter;
            this.saveData = saveData;
            this.openDialog = openDialog;
            this.loadData = loadData;
        }



        private void InitSudokuGrid()
        {
            panelSpaceFOrGrid.Visible = false;
            var validator = new SudokuValidator();
            sudokuGrid = new SudokuGridControl(validator)
            {
                Location = new Point(80, 120),
                Size = new Size(451, 451),
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            };

            sudokuGrid.ViewModel = viewModel;
            this.Controls.Add(sudokuGrid);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            CenterHorizontalGrid();
        }

        private void CenterHorizontalGrid()
        {
            if (sudokuGrid != null) sudokuGrid.Left = (this.ClientSize.Width - sudokuGrid.Width) / 2;
        }

        private void btnSolveClick(object sender, EventArgs e)
        {
            sudokuGrid.ResetPos();
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (viewModel.Cells[row][col].IsInvalid)
                    {
                        MessageBox.Show("Please set corect number in board.");
                        return;
                    }

                }
            }
            var boardToSolve = sudokuBoardConverter.ToArray(viewModel);
            var solvedBoard = sudokuSolver.Solve(boardToSolve);
            if (solvedBoard != null)
            {
                sudokuBoardConverter.FromArray(viewModel, solvedBoard);
                sudokuGrid.Invalidate();
            }
            else
            {
                MessageBox.Show("No solution found.");
            }
        }

        private void btnSaveClick(object sender, EventArgs e)
        {
            sudokuGrid.ResetPos();
            var fileName = openDialog.OpenDialogForSave();
            if (string.IsNullOrEmpty(fileName))
            {
                MessageBox.Show("No file selected.");
                return;
            }
            else
            {
                var result = saveData.Save(fileName, viewModel);
                if (result == "")
                    MessageBox.Show("File saved successfully.");
                else
                    MessageBox.Show($"File not saved\n{result}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoadClick(object sender, EventArgs e)
        {
            sudokuGrid.ResetPos();
            var fileName = openDialog.OpenDialogForOpen();
            if (string.IsNullOrEmpty(fileName))
            {
                MessageBox.Show("No file selected.");
                return;
            }
            else
            {
                var (board, error) = loadData.Load(fileName);
                if (error == "" && board != null)
                {
                    sudokuBoardConverter.CopyValues(board, viewModel);
                    sudokuGrid.Invalidate();
                }
                else
                {
                    MessageBox.Show($"File not loaded\n{error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            sudokuGrid.ResetPos();
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    viewModel.Cells[row][ col].Value =  0;
                    viewModel.Cells[row][col].IsInvalid = false;
                }
            }
            sudokuGrid.Invalidate();
        }
    }
}
