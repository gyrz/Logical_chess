using System.Collections.Generic;

namespace Chess_Game
{
	partial class BaseDialog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseDialog));
			this.GameRules = new System.Windows.Forms.Button();
			this.StartGame = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// GameRules
			// 
			resources.ApplyResources(this.GameRules, "GameRules");
			this.GameRules.Name = "GameRules";
			this.GameRules.UseVisualStyleBackColor = true;
			this.GameRules.Click += new System.EventHandler(this._GameRules_Click);
			// 
			// StartGame
			// 
			resources.ApplyResources(this.StartGame, "StartGame");
			this.StartGame.Name = "StartGame";
			this.StartGame.UseVisualStyleBackColor = true;
			this.StartGame.Click += new System.EventHandler(this._StartGame_Click);
			// 
			// button1
			// 
			resources.ApplyResources(this.button1, "button1");
			this.button1.Name = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this._Button1_Click);
			// 
			// BaseDialog
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.Controls.Add(this.button1);
			this.Controls.Add(this.StartGame);
			this.Controls.Add(this.GameRules);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.Name = "BaseDialog";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button GameRules;
		private System.Windows.Forms.Button StartGame;
		private System.Windows.Forms.Button button1;
	}
}

