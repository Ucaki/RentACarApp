
using System.Windows.Forms;

namespace Client.UserControls
{
    partial class UCAddCar
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRegistration = new System.Windows.Forms.TextBox();
            this.txtBrand = new System.Windows.Forms.TextBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.numUpDownYearProduction = new System.Windows.Forms.NumericUpDown();
            this.cmbClassCar = new System.Windows.Forms.ComboBox();
            this.btnSaveCarInDb = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtKilometraza = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownYearProduction)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Registration:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Brand:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Production year:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Model:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Class:";
            // 
            // txtRegistration
            // 
            this.txtRegistration.Location = new System.Drawing.Point(154, 47);
            this.txtRegistration.Name = "txtRegistration";
            this.txtRegistration.Size = new System.Drawing.Size(125, 20);
            this.txtRegistration.TabIndex = 5;
            // 
            // txtBrand
            // 
            this.txtBrand.Location = new System.Drawing.Point(154, 87);
            this.txtBrand.Name = "txtBrand";
            this.txtBrand.Size = new System.Drawing.Size(125, 20);
            this.txtBrand.TabIndex = 6;
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(154, 127);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(125, 20);
            this.txtModel.TabIndex = 7;
            // 
            // numUpDownYearProduction
            // 
            this.numUpDownYearProduction.Location = new System.Drawing.Point(154, 170);
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
            this.numUpDownYearProduction.TabIndex = 8;
            this.numUpDownYearProduction.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numUpDownYearProduction.Value = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            // 
            // cmbClassCar
            // 
            this.cmbClassCar.FormattingEnabled = true;
            this.cmbClassCar.Location = new System.Drawing.Point(154, 210);
            this.cmbClassCar.Name = "cmbClassCar";
            this.cmbClassCar.Size = new System.Drawing.Size(125, 21);
            this.cmbClassCar.TabIndex = 9;
            // 
            // btnSaveCarInDb
            // 
            this.btnSaveCarInDb.Location = new System.Drawing.Point(54, 299);
            this.btnSaveCarInDb.Name = "btnSaveCarInDb";
            this.btnSaveCarInDb.Size = new System.Drawing.Size(225, 40);
            this.btnSaveCarInDb.TabIndex = 10;
            this.btnSaveCarInDb.Text = "Save new car";
            this.btnSaveCarInDb.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(51, 245);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Kilometraza:";
            // 
            // txtKilometraza
            // 
            this.txtKilometraza.Location = new System.Drawing.Point(154, 242);
            this.txtKilometraza.Name = "txtKilometraza";
            this.txtKilometraza.Size = new System.Drawing.Size(125, 20);
            this.txtKilometraza.TabIndex = 12;
            // 
            // UCAddCar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtKilometraza);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnSaveCarInDb);
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
            this.Name = "UCAddCar";
            this.Size = new System.Drawing.Size(411, 414);
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownYearProduction)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRegistration;
        private System.Windows.Forms.TextBox txtBrand;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.NumericUpDown numUpDownYearProduction;
        private System.Windows.Forms.ComboBox cmbClassCar;
        private System.Windows.Forms.Button btnSaveCarInDb;
        private Label label6;
        private TextBox txtKilometraza;

        public Button BtnSaveCarInDb { get => btnSaveCarInDb; set => btnSaveCarInDb = value; }
        public TextBox TxtRegistration { get => txtRegistration; set => txtRegistration = value;  }
        public TextBox TxtBrand { get => txtBrand; set => txtBrand = value; }
        public TextBox TxtModel { get => txtModel; set => txtModel = value; }
        public NumericUpDown NumUpDownYearProduction { get => numUpDownYearProduction; set => numUpDownYearProduction = value; }
        public ComboBox CmbClassCar { get => cmbClassCar; set => cmbClassCar = value; }
        public TextBox TxtKilometraza { get => txtKilometraza; set => txtKilometraza = value; }
    }
}
