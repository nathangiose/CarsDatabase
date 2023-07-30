namespace CarsDatabase
{
    partial class frmSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearch));
            this.cboField = new System.Windows.Forms.ComboBox();
            this.cboOperator = new System.Windows.Forms.ComboBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.dgvCars = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCars)).BeginInit();
            this.SuspendLayout();
            // 
            // cboField
            // 
            this.cboField.FormattingEnabled = true;
            this.cboField.Items.AddRange(new object[] {
            "VehicleRegNo",
            "Make",
            "EngineSize",
            "DateRegistered",
            "RentalPerDay",
            "Available"});
            this.cboField.Location = new System.Drawing.Point(122, 65);
            this.cboField.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboField.Name = "cboField";
            this.cboField.Size = new System.Drawing.Size(138, 28);
            this.cboField.TabIndex = 0;
            // 
            // cboOperator
            // 
            this.cboOperator.FormattingEnabled = true;
            this.cboOperator.Items.AddRange(new object[] {
            "=",
            "<",
            ">",
            "<=",
            ">="});
            this.cboOperator.Location = new System.Drawing.Point(286, 65);
            this.cboOperator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboOperator.Name = "cboOperator";
            this.cboOperator.Size = new System.Drawing.Size(117, 28);
            this.cboOperator.TabIndex = 1;
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(432, 65);
            this.txtValue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(135, 27);
            this.txtValue.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(151, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Field";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(299, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Operator";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(469, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 29);
            this.label3.TabIndex = 3;
            this.label3.Text = "Value";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(603, 63);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 31);
            this.button1.TabIndex = 4;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(603, 28);
            this.btnRun.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(86, 31);
            this.btnRun.TabIndex = 4;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // dgvCars
            // 
            this.dgvCars.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvCars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCars.Location = new System.Drawing.Point(14, 123);
            this.dgvCars.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvCars.Name = "dgvCars";
            this.dgvCars.RowHeadersWidth = 51;
            this.dgvCars.RowTemplate.Height = 25;
            this.dgvCars.Size = new System.Drawing.Size(807, 241);
            this.dgvCars.TabIndex = 5;
            // 
            // frmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(834, 380);
            this.Controls.Add(this.dgvCars);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.cboOperator);
            this.Controls.Add(this.cboField);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmSearch";
            this.Text = "frmSearch";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSearch_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCars)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox cboField;
        private ComboBox cboOperator;
        private TextBox txtValue;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button1;
        private Button btnRun;
        private DataGridView dgvCars;
    }
}