
namespace kursovaia
{
    partial class ClientForm
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
            this.pictureAccount = new System.Windows.Forms.PictureBox();
            this.buttonCloseCF = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.genreComboBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.authorComboBox = new System.Windows.Forms.ComboBox();
            this.filterButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAccount)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureAccount
            // 
            this.pictureAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureAccount.Image = global::kursovaia.Properties.Resources.profile_picture;
            this.pictureAccount.Location = new System.Drawing.Point(896, 15);
            this.pictureAccount.Margin = new System.Windows.Forms.Padding(4);
            this.pictureAccount.Name = "pictureAccount";
            this.pictureAccount.Size = new System.Drawing.Size(76, 57);
            this.pictureAccount.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureAccount.TabIndex = 0;
            this.pictureAccount.TabStop = false;
            this.pictureAccount.Click += new System.EventHandler(this.pictureAccount_Click);
            // 
            // buttonCloseCF
            // 
            this.buttonCloseCF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCloseCF.Location = new System.Drawing.Point(997, 15);
            this.buttonCloseCF.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCloseCF.Name = "buttonCloseCF";
            this.buttonCloseCF.Size = new System.Drawing.Size(36, 32);
            this.buttonCloseCF.TabIndex = 2;
            this.buttonCloseCF.Text = "x";
            this.buttonCloseCF.UseVisualStyleBackColor = true;
            this.buttonCloseCF.Click += new System.EventHandler(this.buttonCloseCF_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.searchTextBox);
            this.panel1.Controls.Add(this.clearButton);
            this.panel1.Controls.Add(this.filterButton);
            this.panel1.Controls.Add(this.authorComboBox);
            this.panel1.Controls.Add(this.genreComboBox);
            this.panel1.Controls.Add(this.pictureAccount);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1049, 155);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // genreComboBox
            // 
            this.genreComboBox.FormattingEnabled = true;
            this.genreComboBox.Location = new System.Drawing.Point(24, 87);
            this.genreComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.genreComboBox.Name = "genreComboBox";
            this.genreComboBox.Size = new System.Drawing.Size(301, 24);
            this.genreComboBox.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(997, 14);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(36, 32);
            this.button1.TabIndex = 1;
            this.button1.Text = "x";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonCloseCF_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(16, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "Каталог ";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 155);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1049, 431);
            this.flowLayoutPanel1.TabIndex = 4;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // authorComboBox
            // 
            this.authorComboBox.FormattingEnabled = true;
            this.authorComboBox.Location = new System.Drawing.Point(358, 87);
            this.authorComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.authorComboBox.Name = "authorComboBox";
            this.authorComboBox.Size = new System.Drawing.Size(301, 24);
            this.authorComboBox.TabIndex = 3;
            // 
            // filterButton
            // 
            this.filterButton.Location = new System.Drawing.Point(721, 87);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(121, 30);
            this.filterButton.TabIndex = 4;
            this.filterButton.Text = "Применить";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(721, 120);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(150, 30);
            this.clearButton.TabIndex = 5;
            this.clearButton.Text = "Отчистить фильтр";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(167, 126);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(396, 22);
            this.searchTextBox.TabIndex = 6;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Поиск по названию:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 586);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonCloseCF);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ClientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ClientForm";
            this.Load += new System.EventHandler(this.ClientForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureAccount)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureAccount;
        private System.Windows.Forms.Button buttonCloseCF;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ComboBox genreComboBox;
        private System.Windows.Forms.ComboBox authorComboBox;
        private System.Windows.Forms.Button filterButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox searchTextBox;
    }
}