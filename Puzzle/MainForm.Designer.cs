namespace Puzzle
{
    partial class MainForm
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
            this.table = new System.Windows.Forms.TableLayoutPanel();
            this.BtnRandomize = new System.Windows.Forms.Button();
            this.LabelClicks = new System.Windows.Forms.Label();
            this.BtnReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // table
            // 
            this.table.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.table.ColumnCount = 1;
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table.Location = new System.Drawing.Point(196, 64);
            this.table.Name = "table";
            this.table.RowCount = 1;
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table.Size = new System.Drawing.Size(307, 318);
            this.table.TabIndex = 0;
            // 
            // BtnRandomize
            // 
            this.BtnRandomize.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnRandomize.Location = new System.Drawing.Point(80, 117);
            this.BtnRandomize.Name = "BtnRandomize";
            this.BtnRandomize.Size = new System.Drawing.Size(91, 38);
            this.BtnRandomize.TabIndex = 1;
            this.BtnRandomize.Text = "Randomize";
            this.BtnRandomize.UseVisualStyleBackColor = true;
            this.BtnRandomize.Click += new System.EventHandler(this.BtnRandomize_Click);
            // 
            // LabelClicks
            // 
            this.LabelClicks.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LabelClicks.Location = new System.Drawing.Point(80, 167);
            this.LabelClicks.Name = "LabelClicks";
            this.LabelClicks.Size = new System.Drawing.Size(91, 34);
            this.LabelClicks.TabIndex = 2;
            this.LabelClicks.Text = "0";
            this.LabelClicks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnReset
            // 
            this.BtnReset.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnReset.Location = new System.Drawing.Point(80, 64);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(91, 38);
            this.BtnReset.TabIndex = 3;
            this.BtnReset.Text = "Reset";
            this.BtnReset.UseVisualStyleBackColor = true;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 446);
            this.Controls.Add(this.BtnReset);
            this.Controls.Add(this.LabelClicks);
            this.Controls.Add(this.BtnRandomize);
            this.Controls.Add(this.table);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Slide Puzzle";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel table;
        private System.Windows.Forms.Button BtnRandomize;
        private System.Windows.Forms.Label LabelClicks;
        private System.Windows.Forms.Button BtnReset;
    }
}

