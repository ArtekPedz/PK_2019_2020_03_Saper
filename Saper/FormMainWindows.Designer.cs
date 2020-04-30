namespace Saper
{
    partial class FormMainWindows
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.Menuglowne = new System.Windows.Forms.MenuStrip();
            this.grajToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prostaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.śrdniozaawansowanaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trudnaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.Menuglowne.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menuglowne
            // 
            this.Menuglowne.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Menuglowne.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.grajToolStripMenuItem});
            this.Menuglowne.Location = new System.Drawing.Point(0, 0);
            this.Menuglowne.Name = "Menuglowne";
            this.Menuglowne.Size = new System.Drawing.Size(800, 28);
            this.Menuglowne.TabIndex = 0;
            this.Menuglowne.Text = "menuStrip1";
            // 
            // grajToolStripMenuItem
            // 
            this.grajToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prostaToolStripMenuItem,
            this.śrdniozaawansowanaToolStripMenuItem,
            this.trudnaToolStripMenuItem});
            this.grajToolStripMenuItem.Name = "grajToolStripMenuItem";
            this.grajToolStripMenuItem.Size = new System.Drawing.Size(50, 24);
            this.grajToolStripMenuItem.Text = "Graj";
            // 
            // prostaToolStripMenuItem
            // 
            this.prostaToolStripMenuItem.Name = "prostaToolStripMenuItem";
            this.prostaToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.prostaToolStripMenuItem.Text = "Łatwa";
            this.prostaToolStripMenuItem.Click += new System.EventHandler(this.prostaToolStripMenuItem_Click);
            // 
            // śrdniozaawansowanaToolStripMenuItem
            // 
            this.śrdniozaawansowanaToolStripMenuItem.Name = "śrdniozaawansowanaToolStripMenuItem";
            this.śrdniozaawansowanaToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.śrdniozaawansowanaToolStripMenuItem.Text = "Srednia";
            // 
            // trudnaToolStripMenuItem
            // 
            this.trudnaToolStripMenuItem.Name = "trudnaToolStripMenuItem";
            this.trudnaToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.trudnaToolStripMenuItem.Text = "Trudna";
            // 
            // panelButtons
            // 
            this.panelButtons.AutoSize = true;
            this.panelButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButtons.Location = new System.Drawing.Point(0, 28);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(800, 422);
            this.panelButtons.TabIndex = 1;
            // 
            // FormMainWindows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.Menuglowne);
            this.MainMenuStrip = this.Menuglowne;
            this.Name = "FormMainWindows";
            this.Text = "Saper v1.0";
            this.Load += new System.EventHandler(this.FormMainWindows_Load);
            this.Menuglowne.ResumeLayout(false);
            this.Menuglowne.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Menuglowne;
        private System.Windows.Forms.ToolStripMenuItem grajToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prostaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem śrdniozaawansowanaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trudnaToolStripMenuItem;
        private System.Windows.Forms.Panel panelButtons;
    }
}

