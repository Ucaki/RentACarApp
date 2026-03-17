
using System.Windows.Forms;

namespace Client.UserControls
{
    partial class UCUpdateRent
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
            this.dgvRentsForUser = new System.Windows.Forms.DataGridView();
            this.btnShowRent = new System.Windows.Forms.Button();
            this.btnReleaseRentItems = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentsForUser)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRentsForUser
            // 
            this.dgvRentsForUser.AllowUserToAddRows = false;
            this.dgvRentsForUser.AllowUserToDeleteRows = false;
            this.dgvRentsForUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRentsForUser.Location = new System.Drawing.Point(18, 50);
            this.dgvRentsForUser.Name = "dgvRentsForUser";
            this.dgvRentsForUser.ReadOnly = true;
            this.dgvRentsForUser.Size = new System.Drawing.Size(600, 224);
            this.dgvRentsForUser.TabIndex = 0;
            // 
            // btnShowRent
            // 
            this.btnShowRent.FlatAppearance.BorderColor = System.Drawing.Color.LightBlue;
            this.btnShowRent.Location = new System.Drawing.Point(254, 313);
            this.btnShowRent.Name = "btnShowRent";
            this.btnShowRent.Size = new System.Drawing.Size(137, 49);
            this.btnShowRent.TabIndex = 1;
            this.btnShowRent.Text = "Izaberi iznajmljivanje";
            this.btnShowRent.UseVisualStyleBackColor = true;
            // 
            // btnReleaseRentItems
            // 
            this.btnReleaseRentItems.Location = new System.Drawing.Point(111, 313);
            this.btnReleaseRentItems.Name = "btnReleaseRentItems";
            this.btnReleaseRentItems.Size = new System.Drawing.Size(137, 49);
            this.btnReleaseRentItems.TabIndex = 2;
            this.btnReleaseRentItems.Text = "Razduži";
            this.btnReleaseRentItems.UseVisualStyleBackColor = true;
            this.btnReleaseRentItems.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(166, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(278, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Izmenite stavke koje želite da razdužite";
            // 
            // UCUpdateRent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnReleaseRentItems);
            this.Controls.Add(this.btnShowRent);
            this.Controls.Add(this.dgvRentsForUser);
            this.Name = "UCUpdateRent";
            this.Size = new System.Drawing.Size(634, 412);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentsForUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRentsForUser;
        private System.Windows.Forms.Button btnShowRent;
        private Button btnReleaseRentItems;
        private Label label1;

        public DataGridView DgvRentsForUser { get => dgvRentsForUser; set => dgvRentsForUser = value; }
        public Button BtnShowRent { get => btnShowRent; set => btnShowRent = value; }
        public Button BtnReleaseRentItems { get => btnReleaseRentItems; set => btnReleaseRentItems = value; }
    }
}
