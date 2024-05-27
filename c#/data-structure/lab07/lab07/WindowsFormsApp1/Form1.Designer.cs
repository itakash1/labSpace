namespace WindowsFormsApp1
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.BinaryOutput = new System.Windows.Forms.TextBox();
            this.OutputBinaryButton = new System.Windows.Forms.Button();
            this.BinaryAcceptButton = new System.Windows.Forms.Button();
            this.BinaryInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TextOutput = new System.Windows.Forms.TextBox();
            this.TextOutputButton = new System.Windows.Forms.Button();
            this.TextInputButton = new System.Windows.Forms.Button();
            this.TextInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.SerializeOutput = new System.Windows.Forms.TextBox();
            this.SerializeOutputButton = new System.Windows.Forms.Button();
            this.SerializeInputButton = new System.Windows.Forms.Button();
            this.SerializeInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BinaryOutput);
            this.panel1.Controls.Add(this.OutputBinaryButton);
            this.panel1.Controls.Add(this.BinaryAcceptButton);
            this.panel1.Controls.Add(this.BinaryInput);
            this.panel1.Controls.Add(this.label1);
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(681, 178);
            this.panel1.TabIndex = 0;
            // 
            // BinaryOutput
            // 
            this.BinaryOutput.BackColor = System.Drawing.Color.Black;
            this.BinaryOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.BinaryOutput.ForeColor = System.Drawing.Color.White;
            this.BinaryOutput.Location = new System.Drawing.Point(282, 71);
            this.BinaryOutput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BinaryOutput.Name = "BinaryOutput";
            this.BinaryOutput.ReadOnly = true;
            this.BinaryOutput.Size = new System.Drawing.Size(390, 29);
            this.BinaryOutput.TabIndex = 5;
            // 
            // OutputBinaryButton
            // 
            this.OutputBinaryButton.BackColor = System.Drawing.Color.Black;
            this.OutputBinaryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.OutputBinaryButton.Location = new System.Drawing.Point(282, 22);
            this.OutputBinaryButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.OutputBinaryButton.Name = "OutputBinaryButton";
            this.OutputBinaryButton.Size = new System.Drawing.Size(155, 44);
            this.OutputBinaryButton.TabIndex = 3;
            this.OutputBinaryButton.Text = "Вывести";
            this.OutputBinaryButton.UseVisualStyleBackColor = false;
            this.OutputBinaryButton.Click += new System.EventHandler(this.OutputBinaryButton_Click);
            // 
            // BinaryAcceptButton
            // 
            this.BinaryAcceptButton.BackColor = System.Drawing.Color.Black;
            this.BinaryAcceptButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.BinaryAcceptButton.Location = new System.Drawing.Point(13, 92);
            this.BinaryAcceptButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BinaryAcceptButton.Name = "BinaryAcceptButton";
            this.BinaryAcceptButton.Size = new System.Drawing.Size(222, 67);
            this.BinaryAcceptButton.TabIndex = 2;
            this.BinaryAcceptButton.Text = "Записать";
            this.BinaryAcceptButton.UseVisualStyleBackColor = false;
            this.BinaryAcceptButton.Click += new System.EventHandler(this.BinaryAcceptButton_Click);
            // 
            // BinaryInput
            // 
            this.BinaryInput.BackColor = System.Drawing.Color.Black;
            this.BinaryInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.BinaryInput.ForeColor = System.Drawing.Color.White;
            this.BinaryInput.Location = new System.Drawing.Point(13, 44);
            this.BinaryInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BinaryInput.Name = "BinaryInput";
            this.BinaryInput.Size = new System.Drawing.Size(223, 29);
            this.BinaryInput.TabIndex = 1;
            this.BinaryInput.TextChanged += new System.EventHandler(this.BinaryInput_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Бинарный ввод вектора:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.TextOutput);
            this.panel2.Controls.Add(this.TextOutputButton);
            this.panel2.Controls.Add(this.TextInputButton);
            this.panel2.Controls.Add(this.TextInput);
            this.panel2.Controls.Add(this.label2);
            this.panel2.ForeColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(0, 183);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(681, 178);
            this.panel2.TabIndex = 6;
            // 
            // TextOutput
            // 
            this.TextOutput.BackColor = System.Drawing.Color.Black;
            this.TextOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.TextOutput.ForeColor = System.Drawing.Color.White;
            this.TextOutput.Location = new System.Drawing.Point(282, 71);
            this.TextOutput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TextOutput.Name = "TextOutput";
            this.TextOutput.ReadOnly = true;
            this.TextOutput.Size = new System.Drawing.Size(390, 29);
            this.TextOutput.TabIndex = 5;
            // 
            // TextOutputButton
            // 
            this.TextOutputButton.BackColor = System.Drawing.Color.Black;
            this.TextOutputButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.TextOutputButton.Location = new System.Drawing.Point(282, 22);
            this.TextOutputButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TextOutputButton.Name = "TextOutputButton";
            this.TextOutputButton.Size = new System.Drawing.Size(155, 44);
            this.TextOutputButton.TabIndex = 3;
            this.TextOutputButton.Text = "Вывести";
            this.TextOutputButton.UseVisualStyleBackColor = false;
            this.TextOutputButton.Click += new System.EventHandler(this.TextOutputButton_Click);
            // 
            // TextInputButton
            // 
            this.TextInputButton.BackColor = System.Drawing.Color.Black;
            this.TextInputButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.TextInputButton.Location = new System.Drawing.Point(13, 92);
            this.TextInputButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TextInputButton.Name = "TextInputButton";
            this.TextInputButton.Size = new System.Drawing.Size(222, 67);
            this.TextInputButton.TabIndex = 2;
            this.TextInputButton.Text = "Записать";
            this.TextInputButton.UseVisualStyleBackColor = false;
            this.TextInputButton.Click += new System.EventHandler(this.TextInputButton_Click);
            // 
            // TextInput
            // 
            this.TextInput.BackColor = System.Drawing.Color.Black;
            this.TextInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.TextInput.ForeColor = System.Drawing.Color.White;
            this.TextInput.Location = new System.Drawing.Point(13, 44);
            this.TextInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TextInput.Name = "TextInput";
            this.TextInput.Size = new System.Drawing.Size(223, 29);
            this.TextInput.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label2.Location = new System.Drawing.Point(9, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(241, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Текстовый ввод вектора:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.SerializeOutput);
            this.panel3.Controls.Add(this.SerializeOutputButton);
            this.panel3.Controls.Add(this.SerializeInputButton);
            this.panel3.Controls.Add(this.SerializeInput);
            this.panel3.Controls.Add(this.label3);
            this.panel3.ForeColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(0, 366);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(681, 178);
            this.panel3.TabIndex = 6;
            // 
            // SerializeOutput
            // 
            this.SerializeOutput.BackColor = System.Drawing.Color.Black;
            this.SerializeOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.SerializeOutput.ForeColor = System.Drawing.Color.White;
            this.SerializeOutput.Location = new System.Drawing.Point(282, 71);
            this.SerializeOutput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SerializeOutput.Name = "SerializeOutput";
            this.SerializeOutput.ReadOnly = true;
            this.SerializeOutput.Size = new System.Drawing.Size(390, 29);
            this.SerializeOutput.TabIndex = 5;
            // 
            // SerializeOutputButton
            // 
            this.SerializeOutputButton.BackColor = System.Drawing.Color.Black;
            this.SerializeOutputButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.SerializeOutputButton.Location = new System.Drawing.Point(282, 22);
            this.SerializeOutputButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SerializeOutputButton.Name = "SerializeOutputButton";
            this.SerializeOutputButton.Size = new System.Drawing.Size(155, 44);
            this.SerializeOutputButton.TabIndex = 3;
            this.SerializeOutputButton.Text = "Вывести";
            this.SerializeOutputButton.UseVisualStyleBackColor = false;
            this.SerializeOutputButton.Click += new System.EventHandler(this.SerializeOutputButton_Click);
            // 
            // SerializeInputButton
            // 
            this.SerializeInputButton.BackColor = System.Drawing.Color.Black;
            this.SerializeInputButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.SerializeInputButton.Location = new System.Drawing.Point(13, 92);
            this.SerializeInputButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SerializeInputButton.Name = "SerializeInputButton";
            this.SerializeInputButton.Size = new System.Drawing.Size(222, 67);
            this.SerializeInputButton.TabIndex = 2;
            this.SerializeInputButton.Text = "Записать";
            this.SerializeInputButton.UseVisualStyleBackColor = false;
            this.SerializeInputButton.Click += new System.EventHandler(this.SerializeInputButton_Click);
            // 
            // SerializeInput
            // 
            this.SerializeInput.BackColor = System.Drawing.Color.Black;
            this.SerializeInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.SerializeInput.ForeColor = System.Drawing.Color.White;
            this.SerializeInput.Location = new System.Drawing.Point(13, 44);
            this.SerializeInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SerializeInput.Name = "SerializeInput";
            this.SerializeInput.Size = new System.Drawing.Size(223, 29);
            this.SerializeInput.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label3.Location = new System.Drawing.Point(9, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Сериализация:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.ClientSize = new System.Drawing.Size(680, 560);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "SerializationForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox BinaryInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BinaryAcceptButton;
        private System.Windows.Forms.Button OutputBinaryButton;
        private System.Windows.Forms.TextBox BinaryOutput;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox TextOutput;
        private System.Windows.Forms.Button TextOutputButton;
        private System.Windows.Forms.Button TextInputButton;
        private System.Windows.Forms.TextBox TextInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox SerializeOutput;
        private System.Windows.Forms.Button SerializeOutputButton;
        private System.Windows.Forms.Button SerializeInputButton;
        private System.Windows.Forms.TextBox SerializeInput;
        private System.Windows.Forms.Label label3;
    }
}

