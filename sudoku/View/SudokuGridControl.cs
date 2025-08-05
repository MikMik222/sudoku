using System.ComponentModel;

public class SudokuGridControl : Control
{
    private int selectedRow = -1;
    private int selectedCol = -1;
    private SudokuBoardViewModel? _viewModel;
    private ISudokuValidator _validator;


    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public SudokuBoardViewModel? ViewModel
    {
        get => _viewModel;
        set
        {
            if (_viewModel != null)
                _viewModel.CellValueChanged -= OnCellValueChanged;

            _viewModel = value;

            if (_viewModel != null)
                _viewModel.CellValueChanged += OnCellValueChanged;
        }
    }

    public SudokuGridControl(ISudokuValidator validator)
    {
        this.DoubleBuffered = true;
        this.SetStyle(ControlStyles.ResizeRedraw, true);
        this.TabStop = true;

        this.Width = 450;
        this.Height = 450;

        this.BackColor = Color.White;

        this.MouseClick += SudokuGrid_MouseClick;
        this.KeyPress += SudokuGrid_KeyPress;
        _validator = validator;
    }

    private void OnCellValueChanged(int row, int col)
    {
        _validator.Validate(_viewModel!);
        Invalidate();
    }

    private void SudokuGrid_KeyPress(object? sender, KeyPressEventArgs e)
    {
        if (_viewModel == null || selectedRow == -1 || selectedCol == -1)
            return;

        if (e.KeyChar >= '1' && e.KeyChar <= '9')
        {
            int val = e.KeyChar - '0';
            _viewModel.SetValue(selectedRow, selectedCol, val);
        }
        else if (e.KeyChar == '\b') // backspace
        {
            _viewModel.SetValue(selectedRow, selectedCol, 0);
        }
    }

    private void SudokuGridControl_MouseClick(object? sender, MouseEventArgs e)
    {
        int cellSize = this.Width / 9;
        selectedCol = e.X / cellSize;
        selectedRow = e.Y / cellSize;
        this.Focus();
        Invalidate();
    }


    public void ResetPos()
    {
        selectedRow = -1;
        selectedCol = -1;
    }


    private void SudokuGrid_MouseClick(object sender, MouseEventArgs e)
    {
        int cellSize = this.Width / 9;
        selectedCol = e.X / cellSize;
        selectedRow = e.Y / cellSize;
        this.Focus();
        Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        if (_viewModel == null)
            return;

        int cellSize = this.Width / 9;
        Graphics g = e.Graphics;

        DrawSubgridBackgrounds(g, cellSize);
        HighlightInvalidCells(g, cellSize);
        HighlightSelectedCell(g, cellSize);
        DrawCellNumbers(g, cellSize);
        DrawGridLines(g, cellSize);
    }

    private void DrawSubgridBackgrounds(Graphics g, int cellSize)
    {
        for (int blockRow = 0; blockRow < 3; blockRow++)
        {
            for (int blockCol = 0; blockCol < 3; blockCol++)
            {
                Rectangle block = new Rectangle(blockCol * 3 * cellSize, blockRow * 3 * cellSize, 3 * cellSize, 3 * cellSize);
                using Brush brush = new SolidBrush(GetSubgridColor(blockRow, blockCol));
                g.FillRectangle(brush, block);
            }
        }
    }

    private void HighlightInvalidCells(Graphics g, int cellSize)
    {
        for (int r = 0; r < 9; r++)
        {
            for (int c = 0; c < 9; c++)
            {
                if (_viewModel.Cells[r][c].IsInvalid)
                {
                    Rectangle rect = new Rectangle(c * cellSize, r * cellSize, cellSize, cellSize);
                    using Brush b = new SolidBrush(Color.FromArgb(120, Color.Red));
                    g.FillRectangle(b, rect);
                }
            }
        }
    }

    private void HighlightSelectedCell(Graphics g, int cellSize)
    {
        if (selectedRow != -1 && selectedCol != -1)
        {
            Rectangle selRect = new Rectangle(selectedCol * cellSize, selectedRow * cellSize, cellSize, cellSize);
            using Brush b = new SolidBrush(Color.FromArgb(120, Color.LightBlue));
            g.FillRectangle(b, selRect);
        }
    }

    private void DrawCellNumbers(Graphics g, int cellSize)
    {
        using Font font = new Font("Consolas", cellSize / 2);
        using StringFormat sf = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };

        for (int r = 0; r < 9; r++)
        {
            for (int c = 0; c < 9; c++)
            {
                int val = _viewModel.Cells[r][c].Value;
                if (val > 0)
                {
                    Rectangle rect = new Rectangle(c * cellSize, r * cellSize, cellSize, cellSize);
                    g.DrawString(val.ToString(), font, Brushes.Black, rect, sf);
                }
            }
        }
    }

    private void DrawGridLines(Graphics g, int cellSize)
    {
        using Pen thinPen = new Pen(Color.Black, 1);
        for (int i = 0; i <= 9; i++)
        {
            int pos = i * cellSize;
            g.DrawLine(thinPen, pos, 0, pos, this.Height);
            g.DrawLine(thinPen, 0, pos, this.Width, pos);
        }

        using Pen thickPen = new Pen(Color.Black, 3);
        for (int i = 0; i <= 9; i += 3)
        {
            int pos = i * cellSize;
            g.DrawLine(thickPen, pos, 0, pos, this.Height);
            g.DrawLine(thickPen, 0, pos, this.Width, pos);
        }
    }


    private Color GetSubgridColor(int row, int col)
    {
        return ((row + col) % 2 == 0) ? Color.White : Color.LightGray;
    }
}
