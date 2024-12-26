namespace Hospital
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            менюToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            отделToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripSeparator();
            палатыToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripSeparator();
            лекарстваToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripSeparator();
            предписанияКЛекарствамToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem5 = new ToolStripSeparator();
            доктораToolStripMenuItem = new ToolStripMenuItem();
            пациентыToolStripMenuItem = new ToolStripMenuItem();
            персоналToolStripMenuItem = new ToolStripMenuItem();
            записиНаПриемToolStripMenuItem = new ToolStripMenuItem();
            платежиToolStripMenuItem = new ToolStripMenuItem();
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            groupBox1 = new GroupBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.ButtonHighlight;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { менюToolStripMenuItem, доктораToolStripMenuItem, пациентыToolStripMenuItem, персоналToolStripMenuItem, записиНаПриемToolStripMenuItem, платежиToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1361, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // менюToolStripMenuItem
            // 
            менюToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem1, отделToolStripMenuItem, toolStripMenuItem2, палатыToolStripMenuItem, toolStripMenuItem3, лекарстваToolStripMenuItem, toolStripMenuItem4, предписанияКЛекарствамToolStripMenuItem, toolStripMenuItem5 });
            менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            менюToolStripMenuItem.Size = new Size(65, 24);
            менюToolStripMenuItem.Text = "Меню";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(279, 6);
            // 
            // отделToolStripMenuItem
            // 
            отделToolStripMenuItem.Name = "отделToolStripMenuItem";
            отделToolStripMenuItem.Size = new Size(282, 26);
            отделToolStripMenuItem.Text = "Отделение";
            отделToolStripMenuItem.Click += отделToolStripMenuItem_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(279, 6);
            // 
            // палатыToolStripMenuItem
            // 
            палатыToolStripMenuItem.Name = "палатыToolStripMenuItem";
            палатыToolStripMenuItem.Size = new Size(282, 26);
            палатыToolStripMenuItem.Text = "Палаты";
            палатыToolStripMenuItem.Click += палатыToolStripMenuItem_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(279, 6);
            // 
            // лекарстваToolStripMenuItem
            // 
            лекарстваToolStripMenuItem.Name = "лекарстваToolStripMenuItem";
            лекарстваToolStripMenuItem.Size = new Size(282, 26);
            лекарстваToolStripMenuItem.Text = "Лекарства";
            лекарстваToolStripMenuItem.Click += лекарстваToolStripMenuItem_Click;
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(279, 6);
            // 
            // предписанияКЛекарствамToolStripMenuItem
            // 
            предписанияКЛекарствамToolStripMenuItem.Name = "предписанияКЛекарствамToolStripMenuItem";
            предписанияКЛекарствамToolStripMenuItem.Size = new Size(282, 26);
            предписанияКЛекарствамToolStripMenuItem.Text = "Предписания к лекарствам";
            предписанияКЛекарствамToolStripMenuItem.Click += предписанияКЛекарствамToolStripMenuItem_Click;
            // 
            // toolStripMenuItem5
            // 
            toolStripMenuItem5.Name = "toolStripMenuItem5";
            toolStripMenuItem5.Size = new Size(279, 6);
            // 
            // доктораToolStripMenuItem
            // 
            доктораToolStripMenuItem.Name = "доктораToolStripMenuItem";
            доктораToolStripMenuItem.Size = new Size(66, 24);
            доктораToolStripMenuItem.Text = "Врачи";
            доктораToolStripMenuItem.Click += доктораToolStripMenuItem_Click;
            // 
            // пациентыToolStripMenuItem
            // 
            пациентыToolStripMenuItem.Name = "пациентыToolStripMenuItem";
            пациентыToolStripMenuItem.Size = new Size(94, 24);
            пациентыToolStripMenuItem.Text = "Пациенты";
            пациентыToolStripMenuItem.Click += пациентыToolStripMenuItem_Click;
            // 
            // персоналToolStripMenuItem
            // 
            персоналToolStripMenuItem.Name = "персоналToolStripMenuItem";
            персоналToolStripMenuItem.Size = new Size(92, 24);
            персоналToolStripMenuItem.Text = "Персонал";
            персоналToolStripMenuItem.Click += персоналToolStripMenuItem_Click;
            // 
            // записиНаПриемToolStripMenuItem
            // 
            записиНаПриемToolStripMenuItem.Name = "записиНаПриемToolStripMenuItem";
            записиНаПриемToolStripMenuItem.Size = new Size(144, 24);
            записиНаПриемToolStripMenuItem.Text = "Записи на прием";
            записиНаПриемToolStripMenuItem.Click += записиНаПриемToolStripMenuItem_Click;
            // 
            // платежиToolStripMenuItem
            // 
            платежиToolStripMenuItem.Name = "платежиToolStripMenuItem";
            платежиToolStripMenuItem.Size = new Size(84, 24);
            платежиToolStripMenuItem.Text = "Платежи";
            платежиToolStripMenuItem.Click += платежиToolStripMenuItem_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5, Column6, Column7 });
            dataGridView1.Location = new Point(11, 41);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(954, 506);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            // 
            // Column1
            // 
            Column1.HeaderText = "ID";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.Visible = false;
            Column1.Width = 125;
            // 
            // Column2
            // 
            Column2.HeaderText = "Пациент";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.Width = 125;
            // 
            // Column3
            // 
            Column3.HeaderText = "Врач";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.Width = 125;
            // 
            // Column4
            // 
            Column4.HeaderText = "Дата визита";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.Width = 125;
            // 
            // Column5
            // 
            Column5.HeaderText = "Диагноз";
            Column5.MinimumWidth = 6;
            Column5.Name = "Column5";
            Column5.Width = 125;
            // 
            // Column6
            // 
            Column6.HeaderText = "План лечения";
            Column6.MinimumWidth = 6;
            Column6.Name = "Column6";
            Column6.Width = 200;
            // 
            // Column7
            // 
            Column7.HeaderText = "Записи";
            Column7.MinimumWidth = 6;
            Column7.Name = "Column7";
            Column7.Width = 200;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.ButtonHighlight;
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(dateTimePicker1);
            groupBox1.Controls.Add(comboBox2);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Location = new Point(975, 41);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(374, 449);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Поля для ввода";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 393);
            label6.Name = "label6";
            label6.Size = new Size(59, 20);
            label6.TabIndex = 11;
            label6.Text = "Записи";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 319);
            label5.Name = "label5";
            label5.Size = new Size(107, 20);
            label5.TabIndex = 10;
            label5.Text = "План лечения";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 238);
            label4.Name = "label4";
            label4.Size = new Size(67, 20);
            label4.TabIndex = 9;
            label4.Text = "Диагноз";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 167);
            label3.Name = "label3";
            label3.Size = new Size(92, 20);
            label3.TabIndex = 8;
            label3.Text = "Дата визита";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 94);
            label2.Name = "label2";
            label2.Size = new Size(43, 20);
            label2.TabIndex = 7;
            label2.Text = "Врач";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 29);
            label1.Name = "label1";
            label1.Size = new Size(69, 20);
            label1.TabIndex = 6;
            label1.Text = "Пациент";
            // 
            // textBox3
            // 
            textBox3.BackColor = SystemColors.ActiveCaption;
            textBox3.Location = new Point(6, 416);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(362, 27);
            textBox3.TabIndex = 5;
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.ActiveCaption;
            textBox2.Location = new Point(6, 342);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(362, 27);
            textBox2.TabIndex = 4;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.ActiveCaption;
            textBox1.Location = new Point(6, 261);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(362, 27);
            textBox1.TabIndex = 3;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(6, 190);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(362, 27);
            dateTimePicker1.TabIndex = 2;
            // 
            // comboBox2
            // 
            comboBox2.BackColor = SystemColors.ActiveCaption;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(6, 117);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(362, 28);
            comboBox2.TabIndex = 1;
            // 
            // comboBox1
            // 
            comboBox1.BackColor = SystemColors.ActiveCaption;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(6, 52);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(362, 28);
            comboBox1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(975, 496);
            button1.Name = "button1";
            button1.Size = new Size(119, 51);
            button1.TabIndex = 3;
            button1.Text = "Добавить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(1100, 496);
            button2.Name = "button2";
            button2.Size = new Size(124, 51);
            button2.TabIndex = 4;
            button2.Text = "Редактировать";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(1230, 496);
            button3.Name = "button3";
            button3.Size = new Size(119, 51);
            button3.TabIndex = 5;
            button3.Text = "Удалить";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1361, 554);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(groupBox1);
            Controls.Add(dataGridView1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "База данных \"Больница\"";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem менюToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem отделToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem палатыToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem3;
        private ToolStripMenuItem лекарстваToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem4;
        private ToolStripMenuItem доктораToolStripMenuItem;
        private ToolStripMenuItem пациентыToolStripMenuItem;
        private ToolStripMenuItem персоналToolStripMenuItem;
        private ToolStripMenuItem записиНаПриемToolStripMenuItem;
        private ToolStripMenuItem платежиToolStripMenuItem;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private GroupBox groupBox1;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private DateTimePicker dateTimePicker1;
        private ComboBox comboBox2;
        private ComboBox comboBox1;
        private Button button1;
        private Button button2;
        private Button button3;
        private ToolStripMenuItem предписанияКЛекарствамToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem5;
    }
}
