namespace DTProc
{
    partial class DTProc
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DTProc));
            this.PictureMenu = new System.Windows.Forms.PictureBox();
            this.RightClickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RightClickMenu_Translate = new System.Windows.Forms.ToolStripMenuItem();
            this.RightClickMenu_Translate_Auto = new System.Windows.Forms.ToolStripMenuItem();
            this.RightClickMenu_Translate_EnglishToChinese = new System.Windows.Forms.ToolStripMenuItem();
            this.RightClickMenu_Translate_JapaneseToChinese = new System.Windows.Forms.ToolStripMenuItem();
            this.RightClickMenu_Translate_NoTranslate = new System.Windows.Forms.ToolStripMenuItem();
            this.RightClickMenu_TextSize = new System.Windows.Forms.ToolStripMenuItem();
            this.RightClickMenu_TextSize_Big = new System.Windows.Forms.ToolStripMenuItem();
            this.RightClickMenu_TextSize_Medium = new System.Windows.Forms.ToolStripMenuItem();
            this.RightClickMenu_TextSize_Small = new System.Windows.Forms.ToolStripMenuItem();
            this.RightClickMenu_BGSet = new System.Windows.Forms.ToolStripMenuItem();
            this.RightClickMenu_Extend = new System.Windows.Forms.ToolStripMenuItem();
            this.RightClickMenu_Reduce = new System.Windows.Forms.ToolStripMenuItem();
            this.RightClickMenu_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PictureMenu)).BeginInit();
            this.RightClickMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // PictureMenu
            // 
            this.PictureMenu.BackColor = System.Drawing.Color.LightSeaGreen;
            this.PictureMenu.ContextMenuStrip = this.RightClickMenu;
            this.PictureMenu.Location = new System.Drawing.Point(0, 0);
            this.PictureMenu.Margin = new System.Windows.Forms.Padding(0);
            this.PictureMenu.Name = "PictureMenu";
            this.PictureMenu.Size = new System.Drawing.Size(64, 64);
            this.PictureMenu.TabIndex = 0;
            this.PictureMenu.TabStop = false;
            this.PictureMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureMenu_MouseDown);
            this.PictureMenu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureMenu_MouseMove);
            this.PictureMenu.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureMenu_MouseUp);
            // 
            // RightClickMenu
            // 
            this.RightClickMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RightClickMenu_Translate,
            this.RightClickMenu_TextSize,
            this.RightClickMenu_BGSet,
            this.RightClickMenu_Extend,
            this.RightClickMenu_Reduce,
            this.RightClickMenu_Exit});
            this.RightClickMenu.Name = "RightClickMenu";
            this.RightClickMenu.Size = new System.Drawing.Size(125, 136);
            // 
            // RightClickMenu_Translate
            // 
            this.RightClickMenu_Translate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RightClickMenu_Translate_Auto,
            this.RightClickMenu_Translate_EnglishToChinese,
            this.RightClickMenu_Translate_JapaneseToChinese,
            this.RightClickMenu_Translate_NoTranslate});
            this.RightClickMenu_Translate.Name = "RightClickMenu_Translate";
            this.RightClickMenu_Translate.Size = new System.Drawing.Size(124, 22);
            this.RightClickMenu_Translate.Text = "在线翻译";
            // 
            // RightClickMenu_Translate_Auto
            // 
            this.RightClickMenu_Translate_Auto.Checked = true;
            this.RightClickMenu_Translate_Auto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RightClickMenu_Translate_Auto.Name = "RightClickMenu_Translate_Auto";
            this.RightClickMenu_Translate_Auto.Size = new System.Drawing.Size(124, 22);
            this.RightClickMenu_Translate_Auto.Text = "检测语言";
            this.RightClickMenu_Translate_Auto.Click += new System.EventHandler(this.RightClickMenu_Translate_Auto_Click);
            // 
            // RightClickMenu_Translate_EnglishToChinese
            // 
            this.RightClickMenu_Translate_EnglishToChinese.Name = "RightClickMenu_Translate_EnglishToChinese";
            this.RightClickMenu_Translate_EnglishToChinese.Size = new System.Drawing.Size(124, 22);
            this.RightClickMenu_Translate_EnglishToChinese.Text = "英文译中";
            this.RightClickMenu_Translate_EnglishToChinese.Click += new System.EventHandler(this.RightClickMenu_Translate_EnglishToChinese_Click);
            // 
            // RightClickMenu_Translate_JapaneseToChinese
            // 
            this.RightClickMenu_Translate_JapaneseToChinese.Name = "RightClickMenu_Translate_JapaneseToChinese";
            this.RightClickMenu_Translate_JapaneseToChinese.Size = new System.Drawing.Size(124, 22);
            this.RightClickMenu_Translate_JapaneseToChinese.Text = "日文译中";
            this.RightClickMenu_Translate_JapaneseToChinese.Click += new System.EventHandler(this.RightClickMenu_Translate_JapaneseToChinese_Click);
            // 
            // RightClickMenu_Translate_NoTranslate
            // 
            this.RightClickMenu_Translate_NoTranslate.Name = "RightClickMenu_Translate_NoTranslate";
            this.RightClickMenu_Translate_NoTranslate.Size = new System.Drawing.Size(124, 22);
            this.RightClickMenu_Translate_NoTranslate.Text = "原始语言";
            this.RightClickMenu_Translate_NoTranslate.Click += new System.EventHandler(this.RightClickMenu_Translate_NoTranslate_Click);
            // 
            // RightClickMenu_TextSize
            // 
            this.RightClickMenu_TextSize.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RightClickMenu_TextSize_Big,
            this.RightClickMenu_TextSize_Medium,
            this.RightClickMenu_TextSize_Small});
            this.RightClickMenu_TextSize.Name = "RightClickMenu_TextSize";
            this.RightClickMenu_TextSize.Size = new System.Drawing.Size(124, 22);
            this.RightClickMenu_TextSize.Text = "文字大小";
            // 
            // RightClickMenu_TextSize_Big
            // 
            this.RightClickMenu_TextSize_Big.Name = "RightClickMenu_TextSize_Big";
            this.RightClickMenu_TextSize_Big.Size = new System.Drawing.Size(100, 22);
            this.RightClickMenu_TextSize_Big.Text = "大号";
            this.RightClickMenu_TextSize_Big.Click += new System.EventHandler(this.RightClickMenu_TextSize_Big_Click);
            // 
            // RightClickMenu_TextSize_Medium
            // 
            this.RightClickMenu_TextSize_Medium.Checked = true;
            this.RightClickMenu_TextSize_Medium.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RightClickMenu_TextSize_Medium.Name = "RightClickMenu_TextSize_Medium";
            this.RightClickMenu_TextSize_Medium.Size = new System.Drawing.Size(100, 22);
            this.RightClickMenu_TextSize_Medium.Text = "中号";
            this.RightClickMenu_TextSize_Medium.Click += new System.EventHandler(this.RightClickMenu_TextSize_Medium_Click);
            // 
            // RightClickMenu_TextSize_Small
            // 
            this.RightClickMenu_TextSize_Small.Name = "RightClickMenu_TextSize_Small";
            this.RightClickMenu_TextSize_Small.Size = new System.Drawing.Size(100, 22);
            this.RightClickMenu_TextSize_Small.Text = "小号";
            this.RightClickMenu_TextSize_Small.Click += new System.EventHandler(this.RightClickMenu_TextSize_Small_Click);
            // 
            // RightClickMenu_BGSet
            // 
            this.RightClickMenu_BGSet.Name = "RightClickMenu_BGSet";
            this.RightClickMenu_BGSet.Size = new System.Drawing.Size(124, 22);
            this.RightClickMenu_BGSet.Text = "背景透明";
            this.RightClickMenu_BGSet.Click += new System.EventHandler(this.RightClickMenu_BGSet_Click);
            // 
            // RightClickMenu_Extend
            // 
            this.RightClickMenu_Extend.Name = "RightClickMenu_Extend";
            this.RightClickMenu_Extend.Size = new System.Drawing.Size(124, 22);
            this.RightClickMenu_Extend.Text = "扩大区域";
            this.RightClickMenu_Extend.Click += new System.EventHandler(this.RightClickMenu_Extend_Click);
            // 
            // RightClickMenu_Reduce
            // 
            this.RightClickMenu_Reduce.Name = "RightClickMenu_Reduce";
            this.RightClickMenu_Reduce.Size = new System.Drawing.Size(124, 22);
            this.RightClickMenu_Reduce.Text = "缩小区域";
            this.RightClickMenu_Reduce.Click += new System.EventHandler(this.RightClickMenu_Reduce_Click);
            // 
            // RightClickMenu_Exit
            // 
            this.RightClickMenu_Exit.Name = "RightClickMenu_Exit";
            this.RightClickMenu_Exit.Size = new System.Drawing.Size(124, 22);
            this.RightClickMenu_Exit.Text = "退出程序";
            this.RightClickMenu_Exit.Click += new System.EventHandler(this.RightClickMenu_Exit_Click);
            // 
            // Label
            // 
            this.Label.BackColor = System.Drawing.Color.Transparent;
            this.Label.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label.ForeColor = System.Drawing.Color.LightBlue;
            this.Label.Location = new System.Drawing.Point(64, 0);
            this.Label.Margin = new System.Windows.Forms.Padding(0);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(1024, 64);
            this.Label.TabIndex = 1;
            this.Label.Text = "程序会自动翻译剪贴板内文本（Help：左侧图标，左键拖动窗口，右键设置菜单）";
            this.Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Label.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Label_MouseClick);
            // 
            // DTProc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1088, 64);
            this.Controls.Add(this.Label);
            this.Controls.Add(this.PictureMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DTProc";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DTProc";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.PictureMenu)).EndInit();
            this.RightClickMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureMenu;
        private System.Windows.Forms.Label Label;
        private System.Windows.Forms.ContextMenuStrip RightClickMenu;
        private System.Windows.Forms.ToolStripMenuItem RightClickMenu_Exit;
        private System.Windows.Forms.ToolStripMenuItem RightClickMenu_BGSet;
        private System.Windows.Forms.ToolStripMenuItem RightClickMenu_Extend;
        private System.Windows.Forms.ToolStripMenuItem RightClickMenu_TextSize;
        private System.Windows.Forms.ToolStripMenuItem RightClickMenu_TextSize_Small;
        private System.Windows.Forms.ToolStripMenuItem RightClickMenu_TextSize_Big;
        private System.Windows.Forms.ToolStripMenuItem RightClickMenu_TextSize_Medium;
        private System.Windows.Forms.ToolStripMenuItem RightClickMenu_Reduce;
        private System.Windows.Forms.ToolStripMenuItem RightClickMenu_Translate;
        private System.Windows.Forms.ToolStripMenuItem RightClickMenu_Translate_Auto;
        private System.Windows.Forms.ToolStripMenuItem RightClickMenu_Translate_EnglishToChinese;
        private System.Windows.Forms.ToolStripMenuItem RightClickMenu_Translate_JapaneseToChinese;
        private System.Windows.Forms.ToolStripMenuItem RightClickMenu_Translate_NoTranslate;
    }
}

