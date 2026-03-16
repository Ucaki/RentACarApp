
using System.Windows.Forms;

namespace Client.UserControls
{
    partial class UCAddRent
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
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtCar = new System.Windows.Forms.TextBox();
            this.txtUgovorenaCena = new System.Windows.Forms.TextBox();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.txtKm = new System.Windows.Forms.TextBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSaveRent = new System.Windows.Forms.Button();
            this.dgvListRents = new System.Windows.Forms.DataGridView();
            this.btnDodajIznajmljivanjeUListu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListRents)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(66, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Početkna KM:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(66, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Popust:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Ugovorena cena:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Automobil";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Korisnik:";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(210, 55);
            this.txtUser.Name = "txtUser";
            this.txtUser.ReadOnly = true;
            this.txtUser.Size = new System.Drawing.Size(235, 20);
            this.txtUser.TabIndex = 14;
            // 
            // txtCar
            // 
            this.txtCar.Location = new System.Drawing.Point(210, 97);
            this.txtCar.Name = "txtCar";
            this.txtCar.ReadOnly = true;
            this.txtCar.Size = new System.Drawing.Size(235, 20);
            this.txtCar.TabIndex = 15;
            // 
            // txtUgovorenaCena
            // 
            this.txtUgovorenaCena.Location = new System.Drawing.Point(210, 138);
            this.txtUgovorenaCena.Name = "txtUgovorenaCena";
            this.txtUgovorenaCena.ReadOnly = true;
            this.txtUgovorenaCena.Size = new System.Drawing.Size(68, 20);
            this.txtUgovorenaCena.TabIndex = 16;
            this.txtUgovorenaCena.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(210, 176);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(68, 20);
            this.txtDiscount.TabIndex = 17;
            this.txtDiscount.Text = "0";
            this.txtDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtKm
            // 
            this.txtKm.Location = new System.Drawing.Point(210, 213);
            this.txtKm.Name = "txtKm";
            this.txtKm.ReadOnly = true;
            this.txtKm.Size = new System.Drawing.Size(235, 20);
            this.txtKm.TabIndex = 18;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(210, 254);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(144, 20);
            this.dateTimePicker.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(66, 260);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Datum do:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(284, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "€";
            // 
            // btnSaveRent
            // 
            this.btnSaveRent.Location = new System.Drawing.Point(69, 327);
            this.btnSaveRent.Name = "btnSaveRent";
            this.btnSaveRent.Size = new System.Drawing.Size(142, 52);
            this.btnSaveRent.TabIndex = 22;
            this.btnSaveRent.Text = "Sačuvaj iznajmljivanje";
            this.btnSaveRent.UseVisualStyleBackColor = true;
            // 
            // dgvListRents
            // 
            this.dgvListRents.AllowUserToAddRows = false;
            this.dgvListRents.AllowUserToDeleteRows = false;
            this.dgvListRents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListRents.Location = new System.Drawing.Point(525, 25);
            this.dgvListRents.Name = "dgvListRents";
            this.dgvListRents.ReadOnly = true;
            this.dgvListRents.Size = new System.Drawing.Size(533, 366);
            this.dgvListRents.TabIndex = 23;
            // 
            // btnDodajIznajmljivanjeUListu
            // 
            this.btnDodajIznajmljivanjeUListu.Location = new System.Drawing.Point(287, 327);
            this.btnDodajIznajmljivanjeUListu.Name = "btnDodajIznajmljivanjeUListu";
            this.btnDodajIznajmljivanjeUListu.Size = new System.Drawing.Size(149, 52);
            this.btnDodajIznajmljivanjeUListu.TabIndex = 24;
            this.btnDodajIznajmljivanjeUListu.Text = "Dodaj u listu";
            this.btnDodajIznajmljivanjeUListu.UseVisualStyleBackColor = true;
            // 
            // UCAddRent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDodajIznajmljivanjeUListu);
            this.Controls.Add(this.dgvListRents);
            this.Controls.Add(this.btnSaveRent);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.txtKm);
            this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.txtUgovorenaCena);
            this.Controls.Add(this.txtCar);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UCAddRent";
            this.Size = new System.Drawing.Size(1111, 440);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListRents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtCar;
        private System.Windows.Forms.TextBox txtUgovorenaCena;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.TextBox txtKm;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label label6;
        private Label label7;
        private Button btnSaveRent;
        private DataGridView dgvListRents;
        private Button btnDodajIznajmljivanjeUListu;

        public TextBox TxtUser { get => txtUser; set => txtUser = value; }
        public TextBox TxtCar { get => txtCar; set => txtCar = value; }
        public TextBox TxtUgovorenaCena { get => txtUgovorenaCena; set => txtUgovorenaCena = value; }
        public TextBox TxtDiscount { get => txtDiscount; set => txtDiscount = value; }
        public TextBox TxtKm { get => txtKm; set => txtKm = value; }
        public DateTimePicker DateTimePicker { get => dateTimePicker; set => dateTimePicker = value; }
        public Button BtnSaveRent { get => btnSaveRent; set => btnSaveRent = value; }
        public Button BtnDodajIznajmljivanjeUListu { get => btnDodajIznajmljivanjeUListu; set => btnDodajIznajmljivanjeUListu = value; }
        public DataGridView DgvListRents { get => dgvListRents; set => dgvListRents = value; }

    }
}
