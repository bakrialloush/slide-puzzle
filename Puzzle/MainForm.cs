using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Puzzle
{
    enum Side { Left, Top, Right, Bottom }

    public partial class MainForm : Form
    {
        const int rows = 3;
        const int columns = 3;
        int clicks = 0;
        TableLayoutPanelCellPosition emptyCellPosition =
            new TableLayoutPanelCellPosition(columns - 1, rows - 1);

        public MainForm()
        {
            InitializeComponent();
            Reset();
        }

        private void Reset()
        {
            SetClicks(0);
            table.Controls.Clear();
            table.ColumnStyles.Clear();
            table.RowStyles.Clear();
            table.RowCount = rows;
            table.ColumnCount = columns;
            emptyCellPosition = new TableLayoutPanelCellPosition(columns - 1, rows - 1);
            var cell = 0;
            for (int row = 0; row < rows; row++)
            {
                var rowStyle = new RowStyle(SizeType.Percent, 100 / rows);
                table.RowStyles.Add(rowStyle);
                for (int colurmn = 0; colurmn < columns; colurmn++)
                {
                    if (row == 0)
                    {
                        var columnStyle = new ColumnStyle(SizeType.Percent, 100 / columns);
                        table.ColumnStyles.Add(columnStyle);

                    }
                    if (colurmn != columns - 1 || row != rows - 1)
                    {
                        var position = new TableLayoutPanelCellPosition(colurmn, row);
                        var button = new Button
                        {
                            Name = "button" + ++cell,
                            Text = cell.ToString(),
                            Tag = position,
                            Font = new Font("", rows * -3 + 32),
                            Dock = DockStyle.Fill,
                        };
                        button.Click += button_Click;
                        table.Controls.Add(button);
                        table.SetCellPosition(button, position);
                    }
                }
            }
            table.Enabled = true;
            BtnRandomize.Enabled = true;
        }

        private void Randomize()
        {
            Random rand = new Random();
            for (int i = 0; i < columns * rows; i++)
            {
                var cell1 = new TableLayoutPanelCellPosition(rand.Next(columns), rand.Next(rows));
                var cell2 = new TableLayoutPanelCellPosition(rand.Next(columns), rand.Next(rows));
                for (; ; )
                {
                    if (cell1 != emptyCellPosition && cell2 != emptyCellPosition)
                    {

                        var button1 = table.GetControlFromPosition(cell1.Column, cell1.Row);
                        var button2 = table.GetControlFromPosition(cell2.Column, cell2.Row);
                        table.SetCellPosition(button1, cell2);
                        table.SetCellPosition(button2, cell1);
                        Thread.Sleep(100);
                        Application.DoEvents();
                    }
                    break;
                }
            }
            SetClicks(clicks);
        }

        private void SetClicks(int count)
        {
            clicks = count;
            LabelClicks.Text = clicks.ToString();
        }

        private void button_Click(object sender, EventArgs e)
        {
            MoveButton(sender as Control);
        }

        private List<Side> GetAllowedSides(TableLayoutPanelCellPosition position)
        {
            var allowed = new List<Side>();
            if (position.Column != 0) allowed.Add(Side.Left);
            if (position.Row != 0) allowed.Add(Side.Top);
            if (position.Column != columns - 1) allowed.Add(Side.Right);
            if (position.Row != rows - 1) allowed.Add(Side.Bottom);
            return allowed;
        }

        private List<TableLayoutPanelCellPosition> getAllowedPositions
            (TableLayoutPanelCellPosition current)
        {
            var allowedSides = GetAllowedSides(current);
            var allowedPositions = allowedSides.ConvertAll(side => new TableLayoutPanelCellPosition
            {
                Column = current.Column + (side == Side.Left ? -1 : side == Side.Right ? 1 : 0),
                Row = current.Row + (side == Side.Top ? -1 : side == Side.Bottom ? 1 : 0),
            });
            return allowedPositions;
        }

        private void MoveButton(Control button)
        {
            var position = table.GetCellPosition(button);
            var positions = getAllowedPositions(position);
            if (positions.Contains(emptyCellPosition))
            {
                var current = table.GetCellPosition(button);
                table.SetCellPosition(button, emptyCellPosition);
                emptyCellPosition = current;
                SetClicks(++clicks);
                if (IsCorrect())
                {
                    MessageBox.Show("Nice man!");
                    table.Enabled = false;
                    BtnReset.Enabled = false;
                }
            }
            BtnRandomize.Enabled = false;
        }

        private void BtnRandomize_Click(object sender, EventArgs e)
        {
            Randomize();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private bool IsCorrect()
        {
            bool correct = true;
            foreach (Button button in table.Controls)
            {
                if (table.GetCellPosition(button) != (TableLayoutPanelCellPosition)button.Tag)
                {
                    correct = false;
                }
            }
            return correct;
        }
    }
}
