
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
            this.dgvUser = new System.Windows.Forms.DataGridView();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddRent = new System.Windows.Forms.Button();
            this.btnShowUserRents = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.txtRegistration = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtPopust = new System.Windows.Forms.TextBox();
            this.txtUkupnaCena = new System.Windows.Forms.TextBox();
            this.dgvStavke = new System.Windows.Forms.DataGridView();
            this.btnDodajStavku = new System.Windows.Forms.Button();
            this.btnObrisiStavku = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStavke)).BeginInit();
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
            // btnAddRent
            // 
            this.btnAddRent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAddRent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRent.Location = new System.Drawing.Point(177, 625);
            this.btnAddRent.Name = "btnAddRent";
            this.btnAddRent.Size = new System.Drawing.Size(284, 37);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 587);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Popust:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(370, 587);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Ukupna cena:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 327);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Registarski broj automobila:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(132, 369);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Datum do:";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(224, 369);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(144, 20);
            this.dateTimePicker.TabIndex = 21;
            // 
            // txtRegistration
            // 
            this.txtRegistration.Location = new System.Drawing.Point(224, 327);
            this.txtRegistration.Name = "txtRegistration";
            this.txtRegistration.Size = new System.Drawing.Size(144, 20);
            this.txtRegistration.TabIndex = 23;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Location = new System.Drawing.Point(24, 297);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(597, 6);
            this.panel1.TabIndex = 24;
            // 
            // txtPopust
            // 
            this.txtPopust.Location = new System.Drawing.Point(264, 584);
            this.txtPopust.Name = "txtPopust";
            this.txtPopust.Size = new System.Drawing.Size(79, 20);
            this.txtPopust.TabIndex = 25;
            // 
            // txtUkupnaCena
            // 
            this.txtUkupnaCena.Location = new System.Drawing.Point(475, 584);
            this.txtUkupnaCena.Name = "txtUkupnaCena";
            this.txtUkupnaCena.ReadOnly = true;
            this.txtUkupnaCena.Size = new System.Drawing.Size(79, 20);
            this.txtUkupnaCena.TabIndex = 26;
            // 
            // dgvStavke
            // 
            this.dgvStavke.AllowUserToAddRows = false;
            this.dgvStavke.AllowUserToDeleteRows = false;
            this.dgvStavke.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStavke.Location = new System.Drawing.Point(24, 406);
            this.dgvStavke.Name = "dgvStavke";
            this.dgvStavke.ReadOnly = true;
            this.dgvStavke.Size = new System.Drawing.Size(597, 150);
            this.dgvStavke.TabIndex = 27;
            // 
            // btnDodajStavku
            // 
            this.btnDodajStavku.BackColor = System.Drawing.Color.LightBlue;
            this.btnDodajStavku.FlatAppearance.BorderColor = System.Drawing.Color.SkyBlue;
            this.btnDodajStavku.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDodajStavku.ForeColor = System.Drawing.Color.Black;
            this.btnDodajStavku.Location = new System.Drawing.Point(417, 340);
            this.btnDodajStavku.Name = "btnDodajStavku";
            this.btnDodajStavku.Padding = new System.Windows.Forms.Padding(1);
            this.btnDodajStavku.Size = new System.Drawing.Size(90, 42);
            this.btnDodajStavku.TabIndex = 29;
            this.btnDodajStavku.Text = "Dodaj stavku";
            this.btnDodajStavku.UseVisualStyleBackColor = true;
            // 
            // btnObrisiStavku
            // 
            this.btnObrisiStavku.BackColor = System.Drawing.Color.LightBlue;
            this.btnObrisiStavku.FlatAppearance.BorderColor = System.Drawing.Color.SkyBlue;
            this.btnObrisiStavku.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnObrisiStavku.ForeColor = System.Drawing.Color.Black;
            this.btnObrisiStavku.Location = new System.Drawing.Point(531, 340);
            this.btnObrisiStavku.Name = "btnObrisiStavku";
            this.btnObrisiStavku.Padding = new System.Windows.Forms.Padding(1);
            this.btnObrisiStavku.Size = new System.Drawing.Size(90, 42);
            this.btnObrisiStavku.TabIndex = 30;
            this.btnObrisiStavku.Text = "Obriši stavku";
            this.btnObrisiStavku.UseVisualStyleBackColor = true;
            // 
            // UCRent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnObrisiStavku);
            this.Controls.Add(this.btnDodajStavku);
            this.Controls.Add(this.dgvStavke);
            this.Controls.Add(this.txtUkupnaCena);
            this.Controls.Add(this.txtPopust);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtRegistration);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnShowUserRents);
            this.Controls.Add(this.btnAddRent);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.dgvUser);
            this.Controls.Add(this.label1);
            this.Name = "UCRent";
            this.Size = new System.Drawing.Size(658, 665);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStavke)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvUser;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddRent;
        private System.Windows.Forms.Button btnShowUserRents;
        private Label label2;
        private Label label4;
        private Label label5;
        private Label label9;
        private DateTimePicker dateTimePicker;
        private TextBox txtRegistration;
        private Panel panel1;
        private TextBox txtPopust;
        private TextBox txtUkupnaCena;
        private DataGridView dgvStavke;
        private Button btnDodajStavku;
        private Button btnObrisiStavku;

        public DataGridView DgvUser { get => dgvUser; set => dgvUser = value; }   
        public TextBox TxtName { get => txtName; set => txtName = value; }
        public Button BtnAddRent { get => btnAddRent; set => btnAddRent = value; }
        public Button BtnShowUserRents { get => btnShowUserRents; set => btnShowUserRents = value; }
        public DateTimePicker DateTimePicker { get => dateTimePicker; set => dateTimePicker = value; }
        public TextBox TxtPopust { get => txtPopust; set => txtPopust = value; }
        public TextBox TxtUkupnaCena { get => txtUkupnaCena; set => txtUkupnaCena = value; }
        public DataGridView DgvStavke { get => dgvStavke; set => dgvStavke = value; }
        public Button BtnDodajStavku { get => btnDodajStavku; set => btnDodajStavku = value; }
        public Button BtnObrisiStavku { get => btnObrisiStavku; set => btnObrisiStavku = value; }
        public TextBox TxtRegistration { get => txtRegistration; set => txtRegistration = value; }

    }
}
