namespace Parser_API_WF_
{
    partial class Form_Parser_api
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.ListData = new System.Windows.Forms.ListBox();
            this.ButtonStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ListData
            // 
            this.ListData.FormattingEnabled = true;
            this.ListData.Location = new System.Drawing.Point(12, 27);
            this.ListData.Name = "ListData";
            this.ListData.Size = new System.Drawing.Size(207, 186);
            this.ListData.TabIndex = 0;
            // 
            // ButtonStart
            // 
            this.ButtonStart.Location = new System.Drawing.Point(282, 27);
            this.ButtonStart.Name = "ButtonStart";
            this.ButtonStart.Size = new System.Drawing.Size(75, 23);
            this.ButtonStart.TabIndex = 1;
            this.ButtonStart.Text = "Start";
            this.ButtonStart.UseVisualStyleBackColor = true;
            this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // Form_Parser_api
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 261);
            this.Controls.Add(this.ButtonStart);
            this.Controls.Add(this.ListData);
            this.Name = "Form_Parser_api";
            this.Text = "Parser_API";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ListData;
        private System.Windows.Forms.Button ButtonStart;
    }
}

