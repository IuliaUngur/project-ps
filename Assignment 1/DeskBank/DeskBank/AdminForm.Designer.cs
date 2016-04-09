namespace DeskBank
{
    partial class AdminForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.employeeListView = new System.Windows.Forms.ListView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.adminSelectedUserNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.adminSelectedPasswordTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.adminSelectedTypeComboBox = new System.Windows.Forms.ComboBox();
            this.adminUpdateSelectedEmployeeButton = new System.Windows.Forms.Button();
            this.adminDeleteSelectedEmployeeButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.adminNewUserNameTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.adminNewPasswordTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.adminNewTypeComboBox = new System.Windows.Forms.ComboBox();
            this.adminSaveNewEmployeeButton = new System.Windows.Forms.Button();
            this.employeeActivityListView = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.employeeListView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(649, 339);
            this.splitContainer1.SplitterDistance = 202;
            this.splitContainer1.TabIndex = 0;
            // 
            // employeeListView
            // 
            this.employeeListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.employeeListView.Location = new System.Drawing.Point(0, 0);
            this.employeeListView.Name = "employeeListView";
            this.employeeListView.Size = new System.Drawing.Size(202, 339);
            this.employeeListView.TabIndex = 0;
            this.employeeListView.UseCompatibleStateImageBehavior = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Controls.Add(this.groupBox2);
            this.flowLayoutPanel1.Controls.Add(this.employeeActivityListView);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(15);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(443, 339);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel2);
            this.groupBox1.Location = new System.Drawing.Point(18, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(15);
            this.groupBox1.Size = new System.Drawing.Size(200, 228);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selected Employee";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label1);
            this.flowLayoutPanel2.Controls.Add(this.adminSelectedUserNameTextBox);
            this.flowLayoutPanel2.Controls.Add(this.label2);
            this.flowLayoutPanel2.Controls.Add(this.adminSelectedPasswordTextBox);
            this.flowLayoutPanel2.Controls.Add(this.label3);
            this.flowLayoutPanel2.Controls.Add(this.adminSelectedTypeComboBox);
            this.flowLayoutPanel2.Controls.Add(this.adminUpdateSelectedEmployeeButton);
            this.flowLayoutPanel2.Controls.Add(this.adminDeleteSelectedEmployeeButton);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(15, 28);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(170, 185);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Name";
            // 
            // adminSelectedUserNameTextBox
            // 
            this.adminSelectedUserNameTextBox.Location = new System.Drawing.Point(0, 23);
            this.adminSelectedUserNameTextBox.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.adminSelectedUserNameTextBox.Name = "adminSelectedUserNameTextBox";
            this.adminSelectedUserNameTextBox.ReadOnly = true;
            this.adminSelectedUserNameTextBox.Size = new System.Drawing.Size(170, 20);
            this.adminSelectedUserNameTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 53);
            this.label2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password";
            // 
            // adminSelectedPasswordTextBox
            // 
            this.adminSelectedPasswordTextBox.Location = new System.Drawing.Point(0, 76);
            this.adminSelectedPasswordTextBox.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.adminSelectedPasswordTextBox.Name = "adminSelectedPasswordTextBox";
            this.adminSelectedPasswordTextBox.Size = new System.Drawing.Size(170, 20);
            this.adminSelectedPasswordTextBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 106);
            this.label3.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Type";
            // 
            // adminSelectedTypeComboBox
            // 
            this.adminSelectedTypeComboBox.FormattingEnabled = true;
            this.adminSelectedTypeComboBox.Items.AddRange(new object[] {
            "Admin",
            "Regular"});
            this.adminSelectedTypeComboBox.Location = new System.Drawing.Point(0, 129);
            this.adminSelectedTypeComboBox.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.adminSelectedTypeComboBox.Name = "adminSelectedTypeComboBox";
            this.adminSelectedTypeComboBox.Size = new System.Drawing.Size(170, 21);
            this.adminSelectedTypeComboBox.TabIndex = 5;
            // 
            // adminUpdateSelectedEmployeeButton
            // 
            this.adminUpdateSelectedEmployeeButton.Location = new System.Drawing.Point(0, 160);
            this.adminUpdateSelectedEmployeeButton.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.adminUpdateSelectedEmployeeButton.Name = "adminUpdateSelectedEmployeeButton";
            this.adminUpdateSelectedEmployeeButton.Size = new System.Drawing.Size(75, 23);
            this.adminUpdateSelectedEmployeeButton.TabIndex = 6;
            this.adminUpdateSelectedEmployeeButton.Text = "Update";
            this.adminUpdateSelectedEmployeeButton.UseVisualStyleBackColor = true;
            this.adminUpdateSelectedEmployeeButton.Click += new System.EventHandler(this.AdminUpdateSelectedEmployeeButtonClick);
            // 
            // adminDeleteSelectedEmployeeButton
            // 
            this.adminDeleteSelectedEmployeeButton.Location = new System.Drawing.Point(85, 160);
            this.adminDeleteSelectedEmployeeButton.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.adminDeleteSelectedEmployeeButton.Name = "adminDeleteSelectedEmployeeButton";
            this.adminDeleteSelectedEmployeeButton.Size = new System.Drawing.Size(75, 23);
            this.adminDeleteSelectedEmployeeButton.TabIndex = 7;
            this.adminDeleteSelectedEmployeeButton.Text = "Delete";
            this.adminDeleteSelectedEmployeeButton.UseVisualStyleBackColor = true;
            this.adminDeleteSelectedEmployeeButton.Click += new System.EventHandler(this.AdminDeleteSelectedEmployeeButtonClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.flowLayoutPanel3);
            this.groupBox2.Location = new System.Drawing.Point(224, 18);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(15);
            this.groupBox2.Size = new System.Drawing.Size(200, 228);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "New Employee";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.label4);
            this.flowLayoutPanel3.Controls.Add(this.adminNewUserNameTextBox);
            this.flowLayoutPanel3.Controls.Add(this.label5);
            this.flowLayoutPanel3.Controls.Add(this.adminNewPasswordTextBox);
            this.flowLayoutPanel3.Controls.Add(this.label6);
            this.flowLayoutPanel3.Controls.Add(this.adminNewTypeComboBox);
            this.flowLayoutPanel3.Controls.Add(this.adminSaveNewEmployeeButton);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(15, 28);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(170, 185);
            this.flowLayoutPanel3.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "User Name";
            // 
            // adminNewUserNameTextBox
            // 
            this.adminNewUserNameTextBox.Location = new System.Drawing.Point(0, 23);
            this.adminNewUserNameTextBox.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.adminNewUserNameTextBox.Name = "adminNewUserNameTextBox";
            this.adminNewUserNameTextBox.Size = new System.Drawing.Size(170, 20);
            this.adminNewUserNameTextBox.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 53);
            this.label5.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Password";
            // 
            // adminNewPasswordTextBox
            // 
            this.adminNewPasswordTextBox.Location = new System.Drawing.Point(0, 76);
            this.adminNewPasswordTextBox.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.adminNewPasswordTextBox.Name = "adminNewPasswordTextBox";
            this.adminNewPasswordTextBox.Size = new System.Drawing.Size(170, 20);
            this.adminNewPasswordTextBox.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(0, 106);
            this.label6.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Type";
            // 
            // adminNewTypeComboBox
            // 
            this.adminNewTypeComboBox.FormattingEnabled = true;
            this.adminNewTypeComboBox.Items.AddRange(new object[] {
            "Admin",
            "Regular"});
            this.adminNewTypeComboBox.Location = new System.Drawing.Point(0, 129);
            this.adminNewTypeComboBox.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.adminNewTypeComboBox.Name = "adminNewTypeComboBox";
            this.adminNewTypeComboBox.Size = new System.Drawing.Size(170, 21);
            this.adminNewTypeComboBox.TabIndex = 11;
            // 
            // adminSaveNewEmployeeButton
            // 
            this.adminSaveNewEmployeeButton.Location = new System.Drawing.Point(0, 160);
            this.adminSaveNewEmployeeButton.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.adminSaveNewEmployeeButton.Name = "adminSaveNewEmployeeButton";
            this.adminSaveNewEmployeeButton.Size = new System.Drawing.Size(75, 23);
            this.adminSaveNewEmployeeButton.TabIndex = 12;
            this.adminSaveNewEmployeeButton.Text = "Save";
            this.adminSaveNewEmployeeButton.UseVisualStyleBackColor = true;
            this.adminSaveNewEmployeeButton.Click += new System.EventHandler(this.AdminSaveNewEmployeeButtonClick);
            // 
            // employeeActivityListView
            // 
            this.employeeActivityListView.Location = new System.Drawing.Point(18, 252);
            this.employeeActivityListView.Name = "employeeActivityListView";
            this.employeeActivityListView.Size = new System.Drawing.Size(406, 75);
            this.employeeActivityListView.TabIndex = 4;
            this.employeeActivityListView.UseCompatibleStateImageBehavior = false;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 339);
            this.Controls.Add(this.splitContainer1);
            this.Name = "AdminForm";
            this.Text = "Admin Form";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnClose);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView employeeListView;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox adminSelectedUserNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox adminSelectedPasswordTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox adminSelectedTypeComboBox;
        private System.Windows.Forms.Button adminUpdateSelectedEmployeeButton;
        private System.Windows.Forms.Button adminDeleteSelectedEmployeeButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView employeeActivityListView;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox adminNewUserNameTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox adminNewPasswordTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox adminNewTypeComboBox;
        private System.Windows.Forms.Button adminSaveNewEmployeeButton;

    }
}