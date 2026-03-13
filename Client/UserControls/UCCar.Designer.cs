
using System.Windows.Forms;

namespace Client.UserControls
{
    partial class UCCar
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
            this.btnAddNewCar = new System.Windows.Forms.Button();
            this.dgvCars = new System.Windows.Forms.DataGridView();
            this.cmbClassCar = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDeleteCar = new System.Windows.Forms.Button();
            this.btnShowCar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCars)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddNewCar
            // 
            this.btnAddNewCar.Location = new System.Drawing.Point(43, 338);
            this.btnAddNewCar.Name = "btnAddNewCar";
            this.btnAddNewCar.Size = new System.Drawing.Size(139, 47);
            this.btnAddNewCar.TabIndex = 0;
            this.btnAddNewCar.Text = "Dodaj Automobil";
            this.btnAddNewCar.UseVisualStyleBackColor = true;
            // 
            // dgvCars
            // 
            this.dgvCars.AllowUserToAddRows = false;
            this.dgvCars.AllowUserToDeleteRows = false;
            this.dgvCars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCars.Location = new System.Drawing.Point(13, 15);
            this.dgvCars.Name = "dgvCars";
            this.dgvCars.ReadOnly = true;
            this.dgvCars.Size = new System.Drawing.Size(666, 234);
            this.dgvCars.TabIndex = 1;
            // 
            // cmbClassCar
            // 
            this.cmbClassCar.FormattingEnabled = true;
            this.cmbClassCar.Location = new System.Drawing.Point(154, 267);
            this.cmbClassCar.Name = "cmbClassCar";
            this.cmbClassCar.Size = new System.Drawing.Size(121, 21);
            this.cmbClassCar.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 270);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Pretrazi po klasi automobila:";
            // 
            // btnDeleteCar
            // 
            this.btnDeleteCar.Location = new System.Drawing.Point(419, 338);
            this.btnDeleteCar.Name = "btnDeleteCar";
            this.btnDeleteCar.Size = new System.Drawing.Size(139, 47);
            this.btnDeleteCar.TabIndex = 4;
            this.btnDeleteCar.Text = "Obrisi Automobil";
            this.btnDeleteCar.UseVisualStyleBackColor = true;
            // 
            // btnShowCar
            // 
            this.btnShowCar.Location = new System.Drawing.Point(242, 338);
            this.btnShowCar.Name = "btnShowCar";
            this.btnShowCar.Size = new System.Drawing.Size(139, 47);
            this.btnShowCar.TabIndex = 5;
            this.btnShowCar.Text = "Prikazi Automobil";
            this.btnShowCar.UseVisualStyleBackColor = true;
            // 
            // UCCar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnShowCar);
            this.Controls.Add(this.btnDeleteCar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbClassCar);
            this.Controls.Add(this.dgvCars);
            this.Controls.Add(this.btnAddNewCar);
            this.Name = "UCCar";
            this.Size = new System.Drawing.Size(693, 422);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCars)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddNewCar;
        private System.Windows.Forms.DataGridView dgvCars;
        private System.Windows.Forms.ComboBox cmbClassCar;
        private System.Windows.Forms.Label label1;
        private Button btnDeleteCar;
        private Button btnShowCar;

        public Button BtnAddNewCar { get => btnAddNewCar; set => btnAddNewCar = value; }
        public Button BtnShowCar { get => btnShowCar; set => btnShowCar = value; }
        public ComboBox CmbClassCar { get => cmbClassCar; set => cmbClassCar = value; }
        public DataGridView DgvCars { get => dgvCars; set => dgvCars = value; }
    }
}
