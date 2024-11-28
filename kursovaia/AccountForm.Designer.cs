namespace kursovaia
{
    partial class AccountForm
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ReaderCardButton = new Guna.UI2.WinForms.Guna2Button();
            this.UserDataButton = new Guna.UI2.WinForms.Guna2Button();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1049, 80);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(997, 14);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(36, 32);
            this.button1.TabIndex = 1;
            this.button1.Text = "x";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(16, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "Профиль";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.ReaderCardButton);
            this.panel2.Controls.Add(this.UserDataButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 80);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1049, 81);
            this.panel2.TabIndex = 1;
            // 
            // ReaderCardButton
            // 
            this.ReaderCardButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ReaderCardButton.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.ReaderCardButton.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ReaderCardButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ReaderCardButton.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.ReaderCardButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ReaderCardButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ReaderCardButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ReaderCardButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ReaderCardButton.FillColor = System.Drawing.Color.Gray;
            this.ReaderCardButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ReaderCardButton.ForeColor = System.Drawing.Color.White;
            this.ReaderCardButton.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ReaderCardButton.Location = new System.Drawing.Point(541, 16);
            this.ReaderCardButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ReaderCardButton.Name = "ReaderCardButton";
            this.ReaderCardButton.Size = new System.Drawing.Size(467, 50);
            this.ReaderCardButton.TabIndex = 1;
            this.ReaderCardButton.Text = "Карточка читателя";
            this.ReaderCardButton.Click += new System.EventHandler(this.ReaderCardButton_Click);
            // 
            // UserDataButton
            // 
            this.UserDataButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.UserDataButton.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.UserDataButton.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.UserDataButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UserDataButton.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.UserDataButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.UserDataButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.UserDataButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.UserDataButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.UserDataButton.FillColor = System.Drawing.Color.Gray;
            this.UserDataButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UserDataButton.ForeColor = System.Drawing.Color.White;
            this.UserDataButton.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.UserDataButton.Location = new System.Drawing.Point(36, 16);
            this.UserDataButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.UserDataButton.Name = "UserDataButton";
            this.UserDataButton.Size = new System.Drawing.Size(467, 50);
            this.UserDataButton.TabIndex = 0;
            this.UserDataButton.Text = "Данные пользователя";
            this.UserDataButton.Click += new System.EventHandler(this.UserDataButton_Click);
            // 
            // panelContainer
            // 
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 161);
            this.panelContainer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(1049, 425);
            this.panelContainer.TabIndex = 2;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this.panel2;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // AccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 586);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AccountForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AccountForm";
            this.Load += new System.EventHandler(this.AccountForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button UserDataButton;
        private Guna.UI2.WinForms.Guna2Button ReaderCardButton;
        private System.Windows.Forms.Panel panelContainer;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private System.Windows.Forms.Button button1;
    }
}