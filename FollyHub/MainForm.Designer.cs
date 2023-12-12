namespace Follyverse
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressLabel = new System.Windows.Forms.Label();
            this.backPanel = new System.Windows.Forms.Panel();
            this.pButtons = new System.Windows.Forms.Panel();
            this.bhdrp = new System.Windows.Forms.Button();
            this.bunreal = new System.Windows.Forms.Button();
            this.burp = new System.Windows.Forms.Button();
            this.backBrowse = new System.Windows.Forms.Panel();
            this.manualPanel = new System.Windows.Forms.Panel();
            this.bimport_folder = new System.Windows.Forms.Button();
            this.bimport_files = new System.Windows.Forms.Button();
            this.manualLabel = new System.Windows.Forms.Label();
            this.brefresh = new System.Windows.Forms.Button();
            this.pagePanel = new System.Windows.Forms.Panel();
            this.bf5 = new System.Windows.Forms.Button();
            this.bf1 = new System.Windows.Forms.Button();
            this.pageNumber = new System.Windows.Forms.Button();
            this.bb1 = new System.Windows.Forms.Button();
            this.bb5 = new System.Windows.Forms.Button();
            this.projectTable = new System.Windows.Forms.TableLayoutPanel();
            this.bottomPanel.SuspendLayout();
            this.backPanel.SuspendLayout();
            this.pButtons.SuspendLayout();
            this.backBrowse.SuspendLayout();
            this.manualPanel.SuspendLayout();
            this.pagePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.progressBar1);
            this.bottomPanel.Controls.Add(this.progressLabel);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 788);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(1380, 25);
            this.bottomPanel.TabIndex = 0;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar1.Location = new System.Drawing.Point(38, 0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1342, 25);
            this.progressBar1.TabIndex = 0;
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.progressLabel.Location = new System.Drawing.Point(0, 0);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(38, 15);
            this.progressLabel.TabIndex = 1;
            this.progressLabel.Text = "label1";
            // 
            // backPanel
            // 
            this.backPanel.BackColor = System.Drawing.Color.Black;
            this.backPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.backPanel.Controls.Add(this.pButtons);
            this.backPanel.Controls.Add(this.backBrowse);
            this.backPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backPanel.Location = new System.Drawing.Point(0, 0);
            this.backPanel.Name = "backPanel";
            this.backPanel.Size = new System.Drawing.Size(1380, 788);
            this.backPanel.TabIndex = 1;
            // 
            // pButtons
            // 
            this.pButtons.Controls.Add(this.bhdrp);
            this.pButtons.Controls.Add(this.bunreal);
            this.pButtons.Controls.Add(this.burp);
            this.pButtons.Location = new System.Drawing.Point(327, 417);
            this.pButtons.Name = "pButtons";
            this.pButtons.Size = new System.Drawing.Size(136, 127);
            this.pButtons.TabIndex = 9;
            // 
            // bhdrp
            // 
            this.bhdrp.BackColor = System.Drawing.Color.Transparent;
            this.bhdrp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bhdrp.Image = ((System.Drawing.Image)(resources.GetObject("bhdrp.Image")));
            this.bhdrp.Location = new System.Drawing.Point(11, 38);
            this.bhdrp.Name = "bhdrp";
            this.bhdrp.Size = new System.Drawing.Size(75, 32);
            this.bhdrp.TabIndex = 8;
            this.bhdrp.Text = "button7";
            this.bhdrp.UseVisualStyleBackColor = false;
            // 
            // bunreal
            // 
            this.bunreal.BackColor = System.Drawing.Color.Transparent;
            this.bunreal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bunreal.Image = ((System.Drawing.Image)(resources.GetObject("bunreal.Image")));
            this.bunreal.Location = new System.Drawing.Point(11, 76);
            this.bunreal.Name = "bunreal";
            this.bunreal.Size = new System.Drawing.Size(75, 23);
            this.bunreal.TabIndex = 7;
            this.bunreal.Text = "button6";
            this.bunreal.UseVisualStyleBackColor = false;
            // 
            // burp
            // 
            this.burp.BackColor = System.Drawing.Color.Transparent;
            this.burp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.burp.Image = ((System.Drawing.Image)(resources.GetObject("burp.Image")));
            this.burp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.burp.Location = new System.Drawing.Point(11, 9);
            this.burp.Name = "burp";
            this.burp.Size = new System.Drawing.Size(115, 38);
            this.burp.TabIndex = 6;
            this.burp.Text = "button5";
            this.burp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.burp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.burp.UseVisualStyleBackColor = false;
            // 
            // backBrowse
            // 
            this.backBrowse.Controls.Add(this.manualPanel);
            this.backBrowse.Controls.Add(this.pagePanel);
            this.backBrowse.Controls.Add(this.projectTable);
            this.backBrowse.Location = new System.Drawing.Point(459, 34);
            this.backBrowse.Name = "backBrowse";
            this.backBrowse.Size = new System.Drawing.Size(771, 444);
            this.backBrowse.TabIndex = 5;
            // 
            // manualPanel
            // 
            this.manualPanel.Controls.Add(this.bimport_folder);
            this.manualPanel.Controls.Add(this.bimport_files);
            this.manualPanel.Controls.Add(this.manualLabel);
            this.manualPanel.Controls.Add(this.brefresh);
            this.manualPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.manualPanel.Location = new System.Drawing.Point(0, 0);
            this.manualPanel.Name = "manualPanel";
            this.manualPanel.Size = new System.Drawing.Size(771, 23);
            this.manualPanel.TabIndex = 3;
            // 
            // bimport_folder
            // 
            this.bimport_folder.BackColor = System.Drawing.SystemColors.Control;
            this.bimport_folder.Dock = System.Windows.Forms.DockStyle.Right;
            this.bimport_folder.FlatAppearance.BorderSize = 0;
            this.bimport_folder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bimport_folder.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bimport_folder.ForeColor = System.Drawing.SystemColors.WindowText;
            this.bimport_folder.Location = new System.Drawing.Point(450, 0);
            this.bimport_folder.Name = "bimport_folder";
            this.bimport_folder.Size = new System.Drawing.Size(107, 23);
            this.bimport_folder.TabIndex = 4;
            this.bimport_folder.Text = "Import";
            this.bimport_folder.UseVisualStyleBackColor = false;
            this.bimport_folder.Click += new System.EventHandler(this.bimport_folder_Click);
            // 
            // bimport_files
            // 
            this.bimport_files.BackColor = System.Drawing.SystemColors.Control;
            this.bimport_files.Dock = System.Windows.Forms.DockStyle.Right;
            this.bimport_files.FlatAppearance.BorderSize = 0;
            this.bimport_files.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bimport_files.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bimport_files.ForeColor = System.Drawing.SystemColors.WindowText;
            this.bimport_files.Location = new System.Drawing.Point(557, 0);
            this.bimport_files.Name = "bimport_files";
            this.bimport_files.Size = new System.Drawing.Size(107, 23);
            this.bimport_files.TabIndex = 3;
            this.bimport_files.Text = "Import";
            this.bimport_files.UseVisualStyleBackColor = false;
            this.bimport_files.Click += new System.EventHandler(this.bimport_files_Click);
            // 
            // manualLabel
            // 
            this.manualLabel.AutoSize = true;
            this.manualLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.manualLabel.Location = new System.Drawing.Point(0, 0);
            this.manualLabel.Name = "manualLabel";
            this.manualLabel.Size = new System.Drawing.Size(0, 15);
            this.manualLabel.TabIndex = 2;
            // 
            // brefresh
            // 
            this.brefresh.BackColor = System.Drawing.SystemColors.Control;
            this.brefresh.Dock = System.Windows.Forms.DockStyle.Right;
            this.brefresh.FlatAppearance.BorderSize = 0;
            this.brefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.brefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.brefresh.ForeColor = System.Drawing.SystemColors.WindowText;
            this.brefresh.Location = new System.Drawing.Point(664, 0);
            this.brefresh.Name = "brefresh";
            this.brefresh.Size = new System.Drawing.Size(107, 23);
            this.brefresh.TabIndex = 1;
            this.brefresh.Text = "Refresh";
            this.brefresh.UseVisualStyleBackColor = false;
            this.brefresh.Click += new System.EventHandler(this.brefresh_clicked);
            // 
            // pagePanel
            // 
            this.pagePanel.Controls.Add(this.bf5);
            this.pagePanel.Controls.Add(this.bf1);
            this.pagePanel.Controls.Add(this.pageNumber);
            this.pagePanel.Controls.Add(this.bb1);
            this.pagePanel.Controls.Add(this.bb5);
            this.pagePanel.Location = new System.Drawing.Point(25, 53);
            this.pagePanel.Name = "pagePanel";
            this.pagePanel.Size = new System.Drawing.Size(1090, 33);
            this.pagePanel.TabIndex = 2;
            // 
            // bf5
            // 
            this.bf5.Dock = System.Windows.Forms.DockStyle.Left;
            this.bf5.FlatAppearance.BorderSize = 0;
            this.bf5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bf5.Location = new System.Drawing.Point(390, 0);
            this.bf5.Name = "bf5";
            this.bf5.Size = new System.Drawing.Size(75, 33);
            this.bf5.TabIndex = 5;
            this.bf5.Text = ">>";
            this.bf5.UseVisualStyleBackColor = true;
            this.bf5.Click += new System.EventHandler(this.PageChangeClick);
            // 
            // bf1
            // 
            this.bf1.Dock = System.Windows.Forms.DockStyle.Left;
            this.bf1.FlatAppearance.BorderSize = 0;
            this.bf1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bf1.Location = new System.Drawing.Point(315, 0);
            this.bf1.Name = "bf1";
            this.bf1.Size = new System.Drawing.Size(75, 33);
            this.bf1.TabIndex = 4;
            this.bf1.Text = ">";
            this.bf1.UseVisualStyleBackColor = true;
            this.bf1.Click += new System.EventHandler(this.PageChangeClick);
            // 
            // pageNumber
            // 
            this.pageNumber.Dock = System.Windows.Forms.DockStyle.Left;
            this.pageNumber.FlatAppearance.BorderSize = 0;
            this.pageNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pageNumber.Location = new System.Drawing.Point(150, 0);
            this.pageNumber.Name = "pageNumber";
            this.pageNumber.Size = new System.Drawing.Size(165, 33);
            this.pageNumber.TabIndex = 3;
            this.pageNumber.Text = "button4";
            this.pageNumber.UseVisualStyleBackColor = true;
            // 
            // bb1
            // 
            this.bb1.Dock = System.Windows.Forms.DockStyle.Left;
            this.bb1.FlatAppearance.BorderSize = 0;
            this.bb1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bb1.Location = new System.Drawing.Point(75, 0);
            this.bb1.Name = "bb1";
            this.bb1.Size = new System.Drawing.Size(75, 33);
            this.bb1.TabIndex = 2;
            this.bb1.Text = "<";
            this.bb1.UseVisualStyleBackColor = true;
            this.bb1.Click += new System.EventHandler(this.PageChangeClick);
            // 
            // bb5
            // 
            this.bb5.Dock = System.Windows.Forms.DockStyle.Left;
            this.bb5.FlatAppearance.BorderSize = 0;
            this.bb5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bb5.Location = new System.Drawing.Point(0, 0);
            this.bb5.Name = "bb5";
            this.bb5.Size = new System.Drawing.Size(75, 33);
            this.bb5.TabIndex = 1;
            this.bb5.Text = "<<";
            this.bb5.UseVisualStyleBackColor = true;
            this.bb5.Click += new System.EventHandler(this.PageChangeClick);
            // 
            // projectTable
            // 
            this.projectTable.AutoScroll = true;
            this.projectTable.BackColor = System.Drawing.Color.Transparent;
            this.projectTable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.projectTable.ColumnCount = 3;
            this.projectTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.projectTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.projectTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.projectTable.Location = new System.Drawing.Point(167, 120);
            this.projectTable.Name = "projectTable";
            this.projectTable.RowCount = 5;
            this.projectTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.projectTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.projectTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.projectTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.projectTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.projectTable.Size = new System.Drawing.Size(869, 439);
            this.projectTable.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1380, 813);
            this.Controls.Add(this.backPanel);
            this.Controls.Add(this.bottomPanel);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Follyverse Hub";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.bottomPanel.ResumeLayout(false);
            this.bottomPanel.PerformLayout();
            this.backPanel.ResumeLayout(false);
            this.pButtons.ResumeLayout(false);
            this.backBrowse.ResumeLayout(false);
            this.manualPanel.ResumeLayout(false);
            this.manualPanel.PerformLayout();
            this.pagePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel bottomPanel;
        private Panel backPanel;
        private TableLayoutPanel projectTable;
        private Panel pagePanel;
        private Button bb1;
        private Button bb5;
        private Button bf5;
        private Button bf1;
        private Button pageNumber;
        private Panel backBrowse;
        private Panel manualPanel;
        private Label manualLabel;
        private Button brefresh;
        private Panel pButtons;
        private Button bhdrp;
        private Button bunreal;
        private Button burp;
        private Button bimport_files;
        private ProgressBar progressBar1;
        private Label progressLabel;
        private Button bimport_folder;
    }
}