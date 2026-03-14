
using System.Windows.Forms;

namespace Client.UserControls
{
    partial class UCRent
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
            this.dgvUser = new System.Windows.Forms.DataGridView();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvCar = new System.Windows.Forms.DataGridView();
            this.cmbClassCar = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddRent = new System.Windows.Forms.Button();
            this.btnShowUserRents = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCar)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Izaberite korisnika:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 267);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "Izaberite automobil:";
            // 
            // dgvUser
            // 
            this.dgvUser.AllowUserToAddRows = false;
            this.dgvUser.AllowUserToDeleteRows = false;
            this.dgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUser.Location = new System.Drawing.Point(24, 46);
            this.dgvUser.Name = "dgvUser";
            this.dgvUser.ReadOnly = true;
            this.dgvUser.Size = new System.Drawing.Size(597, 160);
            this.dgvUser.TabIndex = 2;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(218, 237);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(150, 20);
            this.txtName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 238);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Pretrazite korisnika po imenu:";
            // 
            // dgvCar
            // 
            this.dgvCar.AllowUserToAddRows = false;
            this.dgvCar.AllowUserToDeleteRows = false;
            this.dgvCar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCar.Location = new System.Drawing.Point(24, 300);
            this.dgvCar.Name = "dgvCar";
            this.dgvCar.ReadOnly = true;
            this.dgvCar.Size = new System.Drawing.Size(664, 161);
            this.dgvCar.TabIndex = 5;
            // 
            // cmbClassCar
            // 
            this.cmbClassCar.FormattingEnabled = true;
            this.cmbClassCar.Location = new System.Drawing.Point(218, 480);
            this.cmbClassCar.Name = "cmbClassCar";
            this.cmbClassCar.Size = new System.Drawing.Size(121, 21);
            this.cmbClassCar.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 481);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Pretrazite automobil po klasi:";
            // 
            // btnAddRent
            // 
            this.btnAddRent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAddRent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRent.Location = new System.Drawing.Point(175, 530);
            this.btnAddRent.Name = "btnAddRent";
            this.btnAddRent.Size = new System.Drawing.Size(284, 49);
            this.btnAddRent.TabIndex = 8;
            this.btnAddRent.Text = "Kreiraj iznajmljivanje";
            this.btnAddRent.UseVisualStyleBackColor = false;
            // 
            // btnShowUserRents
            // 
            this.btnShowUserRents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnShowUserRents.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowUserRents.Location = new System.Drawing.Point(417, 222);
            this.btnShowUserRents.Name = "btnShowUserRents";
            this.btnShowUserRents.Size = new System.Drawing.Size(137, 48);
            this.btnShowUserRents.TabIndex = 9;
            this.btnShowUserRents.Text = "Prikazi zaduženja";
            this.btnShowUserRents.UseVisualStyleBackColor = false;
            // 
            // UCRent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnShowUserRents);
            this.Controls.Add(this.btnAddRent);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbClassCar);
            this.Controls.Add(this.dgvCar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.dgvUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UCRent";
            this.Size = new System.Drawing.Size(737, 636);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvUser;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvCar;
        private System.Windows.Forms.ComboBox cmbClassCar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAddRent;
        private System.Windows.Forms.Button btnShowUserRents;
        public DataGridView DgvUser { get => dgvUser; set => dgvUser = value; }
        public DataGridView DgvCar { get => dgvCar; set => dgvCar = value; }
        public TextBox TxtName { get => txtName; set => txtName = value; }
        public ComboBox CmbClassCar { get => cmbClassCar; set => cmbClassCar = value; }
        public Button BtnAddRent { get => btnAddRent; set => btnAddRent = value; }
        public Button BtnShowUserRents { get => btnShowUserRents; set => btnShowUserRents = value; }
    }
}
