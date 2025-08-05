
namespace sudoku
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelSpaceFOrGrid = new Panel();
            label = new Label();
            btnSolve = new MaterialSkin.Controls.MaterialButton();
            btnLoad = new MaterialSkin.Controls.MaterialButton();
            btnSave = new MaterialSkin.Controls.MaterialButton();
            panelSpaceFOrGrid.SuspendLayout();
            SuspendLayout();
            // 
            // panelSpaceFOrGrid
            // 
            panelSpaceFOrGrid.Controls.Add(label);
            panelSpaceFOrGrid.Location = new Point(57, 120);
            panelSpaceFOrGrid.Name = "panelSpaceFOrGrid";
            panelSpaceFOrGrid.Size = new Size(450, 450);
            panelSpaceFOrGrid.TabIndex = 1;
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new Point(53, 22);
            label.Name = "label";
            label.Size = new Size(330, 20);
            label.TabIndex = 0;
            label.Text = "SPACE FOR GRID - THIS DISABLE WHEN TO RUN";
            // 
            // btnSolve
            // 
            btnSolve.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSolve.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSolve.Depth = 0;
            btnSolve.HighEmphasis = true;
            btnSolve.Icon = null;
            btnSolve.Location = new Point(132, 602);
            btnSolve.Margin = new Padding(4, 6, 4, 6);
            btnSolve.MouseState = MaterialSkin.MouseState.HOVER;
            btnSolve.Name = "btnSolve";
            btnSolve.NoAccentTextColor = Color.Empty;
            btnSolve.Size = new Size(66, 36);
            btnSolve.TabIndex = 2;
            btnSolve.Text = "SOLVE";
            btnSolve.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSolve.UseAccentColor = false;
            btnSolve.UseVisualStyleBackColor = true;
            btnSolve.Click += btnSolveClick;
            // 
            // btnLoad
            // 
            btnLoad.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnLoad.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnLoad.Depth = 0;
            btnLoad.HighEmphasis = true;
            btnLoad.Icon = null;
            btnLoad.Location = new Point(57, 602);
            btnLoad.Margin = new Padding(4, 6, 4, 6);
            btnLoad.MouseState = MaterialSkin.MouseState.HOVER;
            btnLoad.Name = "btnLoad";
            btnLoad.NoAccentTextColor = Color.Empty;
            btnLoad.Size = new Size(64, 36);
            btnLoad.TabIndex = 3;
            btnLoad.Text = "LOAD";
            btnLoad.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnLoad.UseAccentColor = false;
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoadClick;
            // 
            // btnSave
            // 
            btnSave.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSave.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSave.Depth = 0;
            btnSave.HighEmphasis = true;
            btnSave.Icon = null;
            btnSave.Location = new Point(210, 602);
            btnSave.Margin = new Padding(4, 6, 4, 6);
            btnSave.MouseState = MaterialSkin.MouseState.HOVER;
            btnSave.Name = "btnSave";
            btnSave.NoAccentTextColor = Color.Empty;
            btnSave.Size = new Size(64, 36);
            btnSave.TabIndex = 4;
            btnSave.Text = "SAVE";
            btnSave.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSave.UseAccentColor = false;
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSaveClick;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(587, 689);
            Controls.Add(btnSave);
            Controls.Add(btnLoad);
            Controls.Add(btnSolve);
            Controls.Add(panelSpaceFOrGrid);
            Name = "MainWindow";
            Text = "Sudoku solver";
            panelSpaceFOrGrid.ResumeLayout(false);
            panelSpaceFOrGrid.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panelSpaceFOrGrid;
        private Label label;
        private MaterialSkin.Controls.MaterialButton btnSolve;
        private MaterialSkin.Controls.MaterialButton btnLoad;
        private MaterialSkin.Controls.MaterialButton btnSave;
    }
}