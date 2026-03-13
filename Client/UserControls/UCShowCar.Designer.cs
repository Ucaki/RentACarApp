
using System.Windows.Forms;

namespace Client.UserControls
{
    partial class UCShowCar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbClassCar = new System.Windows.Forms.ComboBox();
            this.numUpDownYearProduction = new System.Windows.Forms.NumericUpDown();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.txtBrand = new System.Windows.Forms.TextBox();
            this.txtRegistration = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDeleteCar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownYearProduction)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbClassCar
            // 
            this.cmbClassCar.FormattingEnabled = true;
            this.cmbClassCar.Location = new System.Drawing.Point(173, 211);
            this.cmbClassCar.Name = "cmbClassCar";
            this.cmbClassCar.Size = new System.Drawing.Size(125, 21);
            this.cmbClassCar.TabIndex = 19;
            // 
            // numUpDownYearProduction
            // 
            this.numUpDownYearProduction.Location = new System.Drawing.Point(173, 171);
            this.numUpDownYearProduction.Maximum = new decimal(new int[] {
            2026,
            0,
            0,
            0});
            this.numUpDownYearProduction.Minimum = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.numUpDownYearProduction.Name = "numUpDownYearProduction";
            this.numUpDownYearProduction.Size = new System.Drawing.Size(67, 20);
            this.numUpDownYearProduction.TabIndex = 18;
            this.numUpDownYearProduction.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numUpDownYearProduction.Value = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(173, 128);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(125, 20);
            this.txtModel.TabIndex = 17;
            // 
            // txtBrand
            // 
            this.txtBrand.Location = new System.Drawing.Point(173, 88);
            this.txtBrand.Name = "txtBrand";
            this.txtBrand.Size = new System.Drawing.Size(125, 20);
            this.txtBrand.TabIndex = 16;
            // 
            // txtRegistration
            // 
            this.txtRegistration.Location = new System.Drawing.Point(173, 48);
            this.txtRegistration.Name = "txtRegistration";
            this.txtRegistration.Size = new System.Drawing.Size(125, 20);
            this.txtRegistration.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(70, 211);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Class:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Production year:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(70, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Model:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Brand:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Registration:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(70, 252);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Status:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(173, 249);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(125, 21);
            this.cmbStatus.TabIndex = 21;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(43, 328);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(124, 50);
            this.btnUpdate.TabIndex = 22;
            this.btnUpdate.Text = "Sačuvaj izmenu";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDeleteCar
            // 
            this.btnDeleteCar.Location = new System.Drawing.Point(223, 328);
            this.btnDeleteCar.Name = "btnDeleteCar";
            this.btnDeleteCar.Size = new System.Drawing.Size(124, 50);
            this.btnDeleteCar.TabIndex = 23;
            this.btnDeleteCar.Text = "Izbriši automobil";
            this.btnDeleteCar.UseVisualStyleBackColor = true;
            // 
            // UCShowCar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDeleteCar);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbClassCar);
            this.Controls.Add(this.numUpDownYearProduction);
            this.Controls.Add(this.txtModel);
            this.Controls.Add(this.txtBrand);
            this.Controls.Add(this.txtRegistration);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UCShowCar";
            this.Size = new System.Drawing.Size(446, 435);
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownYearProduction)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbClassCar;
        private System.Windows.Forms.NumericUpDown numUpDownYearProduction;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.TextBox txtBrand;
        private System.Windows.Forms.TextBox txtRegistration;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDeleteCar;

        public TextBox TxtModel { get => txtModel; set => txtModel = value; }
        public TextBox TxtBrand { get => txtBrand; set => txtBrand = value; }
        public TextBox TxtRegistration { get => txtRegistration; set => txtRegistration = value; }
        public NumericUpDown NumUpDownYearProduction { get => numUpDownYearProduction; set => numUpDownYearProduction = value; }
        public ComboBox CmbClassCar { get => cmbClassCar; set => cmbClassCar = value; }
        public ComboBox CmbStatus { get => cmbStatus; set => cmbStatus = value; }
        public Button BtnUpdate { get => btnUpdate; set => btnUpdate = value; }
        public Button BtnDeleteCar { get => btnDeleteCar; set => btnDeleteCar = value; }
       

    }
}
