namespace CertificateGenerator
{
    partial class MainForm
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
            lastNameLabel = new Label();
            StudyClassLabel = new Label();
            loginSGLabel = new Label();
            lastNameTextBox = new TextBox();
            StudyClassTextBox = new TextBox();
            loginSGTextBox = new TextBox();
            menuStrip1 = new MenuStrip();
            выходToolStripMenuItem = new ToolStripMenuItem();
            label9 = new Label();
            CerticateGeneratorButton = new Button();
            folderBrowserDialog1 = new FolderBrowserDialog();
            buttonOlimpiadsSelectFolder = new Button();
            OlimpiadsSelectedFolderLabel = new TextBox();
            labelOlimpiadsSelectedFolder = new Label();
            firstNameTextBox = new TextBox();
            firstNameLabel = new Label();
            secondNameTextBox = new TextBox();
            secondNameLabel = new Label();
            KidsSexBox = new GroupBox();
            FemaleRadioButton = new RadioButton();
            MaleRadioButton = new RadioButton();
            SertificateLabel = new Label();
            CertificateSelectedFolderLabel = new TextBox();
            buttonCertificateSelectedFolder = new Button();
            FilesProgressBar = new ProgressBar();
            EmployeeComboBox = new ComboBox();
            EmployeeGroupBox = new GroupBox();
            EmployeeTextBox = new TextBox();
            label1 = new Label();
            SudentIDGroupBox = new GroupBox();
            StudentIDTextBox = new TextBox();
            menuStrip1.SuspendLayout();
            KidsSexBox.SuspendLayout();
            EmployeeGroupBox.SuspendLayout();
            SudentIDGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // lastNameLabel
            // 
            lastNameLabel.AutoSize = true;
            lastNameLabel.Font = new Font("Segoe UI", 12F);
            lastNameLabel.Location = new Point(12, 202);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new Size(75, 21);
            lastNameLabel.TabIndex = 0;
            lastNameLabel.Text = "Фамилия";
            // 
            // StudyClassLabel
            // 
            StudyClassLabel.AutoSize = true;
            StudyClassLabel.Font = new Font("Segoe UI", 12F);
            StudyClassLabel.Location = new Point(12, 300);
            StudyClassLabel.Name = "StudyClassLabel";
            StudyClassLabel.Size = new Size(122, 21);
            StudyClassLabel.TabIndex = 1;
            StudyClassLabel.Text = "Класс обучения";
            // 
            // loginSGLabel
            // 
            loginSGLabel.AutoSize = true;
            loginSGLabel.Font = new Font("Segoe UI", 12F);
            loginSGLabel.Location = new Point(12, 333);
            loginSGLabel.Name = "loginSGLabel";
            loginSGLabel.Size = new Size(82, 21);
            loginSGLabel.TabIndex = 2;
            loginSGLabel.Text = "Логин ОО";
            // 
            // lastNameTextBox
            // 
            lastNameTextBox.Font = new Font("Segoe UI", 12F);
            lastNameTextBox.Location = new Point(191, 196);
            lastNameTextBox.Margin = new Padding(3, 2, 3, 2);
            lastNameTextBox.Name = "lastNameTextBox";
            lastNameTextBox.Size = new Size(110, 29);
            lastNameTextBox.TabIndex = 1;
            // 
            // StudyClassTextBox
            // 
            StudyClassTextBox.Font = new Font("Segoe UI", 12F);
            StudyClassTextBox.Location = new Point(191, 295);
            StudyClassTextBox.Margin = new Padding(3, 2, 3, 2);
            StudyClassTextBox.Name = "StudyClassTextBox";
            StudyClassTextBox.Size = new Size(110, 29);
            StudyClassTextBox.TabIndex = 4;
            // 
            // loginSGTextBox
            // 
            loginSGTextBox.Font = new Font("Segoe UI", 12F);
            loginSGTextBox.Location = new Point(191, 328);
            loginSGTextBox.Margin = new Padding(3, 2, 3, 2);
            loginSGTextBox.Name = "loginSGTextBox";
            loginSGTextBox.Size = new Size(110, 29);
            loginSGTextBox.TabIndex = 5;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { выходToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.Size = new Size(652, 24);
            menuStrip1.TabIndex = 16;
            menuStrip1.Text = "menuStrip1";
            // 
            // выходToolStripMenuItem
            // 
            выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            выходToolStripMenuItem.Size = new Size(53, 20);
            выходToolStripMenuItem.Text = "Выход";
            выходToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 21F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label9.Location = new Point(173, 53);
            label9.Name = "label9";
            label9.Size = new Size(313, 38);
            label9.TabIndex = 17;
            label9.Text = "Генератор справок ШЭ";
            // 
            // CerticateGeneratorButton
            // 
            CerticateGeneratorButton.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            CerticateGeneratorButton.Location = new Point(353, 444);
            CerticateGeneratorButton.Margin = new Padding(3, 2, 3, 2);
            CerticateGeneratorButton.Name = "CerticateGeneratorButton";
            CerticateGeneratorButton.Size = new Size(289, 50);
            CerticateGeneratorButton.TabIndex = 11;
            CerticateGeneratorButton.Text = "Сформировать справку";
            CerticateGeneratorButton.UseVisualStyleBackColor = true;
            CerticateGeneratorButton.Click += CerticateGeneratorButton_ClickAsync;
            // 
            // folderBrowserDialog1
            // 
            folderBrowserDialog1.Description = "Выберите папку";
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
            folderBrowserDialog1.SelectedPath = "D:\\Supernatural";
            folderBrowserDialog1.ShowHiddenFiles = true;
            folderBrowserDialog1.ShowNewFolderButton = false;
            // 
            // buttonOlimpiadsSelectFolder
            // 
            buttonOlimpiadsSelectFolder.Font = new Font("Segoe UI", 12F);
            buttonOlimpiadsSelectFolder.Location = new Point(351, 253);
            buttonOlimpiadsSelectFolder.Name = "buttonOlimpiadsSelectFolder";
            buttonOlimpiadsSelectFolder.Size = new Size(289, 50);
            buttonOlimpiadsSelectFolder.TabIndex = 9;
            buttonOlimpiadsSelectFolder.Text = "Выберите папку с результатами";
            buttonOlimpiadsSelectFolder.UseVisualStyleBackColor = true;
            buttonOlimpiadsSelectFolder.Click += buttonOlimpiadsSelectFolder_Click;
            // 
            // OlimpiadsSelectedFolderLabel
            // 
            OlimpiadsSelectedFolderLabel.Location = new Point(351, 218);
            OlimpiadsSelectedFolderLabel.Name = "OlimpiadsSelectedFolderLabel";
            OlimpiadsSelectedFolderLabel.ReadOnly = true;
            OlimpiadsSelectedFolderLabel.Size = new Size(289, 23);
            OlimpiadsSelectedFolderLabel.TabIndex = 20;
            // 
            // labelOlimpiadsSelectedFolder
            // 
            labelOlimpiadsSelectedFolder.AutoSize = true;
            labelOlimpiadsSelectedFolder.Font = new Font("Segoe UI", 12F);
            labelOlimpiadsSelectedFolder.Location = new Point(351, 194);
            labelOlimpiadsSelectedFolder.Name = "labelOlimpiadsSelectedFolder";
            labelOlimpiadsSelectedFolder.Size = new Size(133, 21);
            labelOlimpiadsSelectedFolder.TabIndex = 21;
            labelOlimpiadsSelectedFolder.Text = "Папка олимпиад:";
            // 
            // firstNameTextBox
            // 
            firstNameTextBox.Font = new Font("Segoe UI", 12F);
            firstNameTextBox.Location = new Point(191, 229);
            firstNameTextBox.Margin = new Padding(3, 2, 3, 2);
            firstNameTextBox.Name = "firstNameTextBox";
            firstNameTextBox.Size = new Size(110, 29);
            firstNameTextBox.TabIndex = 2;
            // 
            // firstNameLabel
            // 
            firstNameLabel.AutoSize = true;
            firstNameLabel.Font = new Font("Segoe UI", 12F);
            firstNameLabel.Location = new Point(12, 235);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new Size(41, 21);
            firstNameLabel.TabIndex = 22;
            firstNameLabel.Text = "Имя";
            // 
            // secondNameTextBox
            // 
            secondNameTextBox.Font = new Font("Segoe UI", 12F);
            secondNameTextBox.Location = new Point(191, 262);
            secondNameTextBox.Margin = new Padding(3, 2, 3, 2);
            secondNameTextBox.Name = "secondNameTextBox";
            secondNameTextBox.Size = new Size(110, 29);
            secondNameTextBox.TabIndex = 3;
            // 
            // secondNameLabel
            // 
            secondNameLabel.AutoSize = true;
            secondNameLabel.Font = new Font("Segoe UI", 12F);
            secondNameLabel.Location = new Point(12, 268);
            secondNameLabel.Name = "secondNameLabel";
            secondNameLabel.Size = new Size(77, 21);
            secondNameLabel.TabIndex = 24;
            secondNameLabel.Text = "Отчество";
            // 
            // KidsSexBox
            // 
            KidsSexBox.Controls.Add(FemaleRadioButton);
            KidsSexBox.Controls.Add(MaleRadioButton);
            KidsSexBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            KidsSexBox.Location = new Point(12, 367);
            KidsSexBox.Name = "KidsSexBox";
            KidsSexBox.Size = new Size(289, 66);
            KidsSexBox.TabIndex = 26;
            KidsSexBox.TabStop = false;
            KidsSexBox.Text = "Пол ребенка";
            // 
            // FemaleRadioButton
            // 
            FemaleRadioButton.AutoSize = true;
            FemaleRadioButton.Location = new Point(179, 30);
            FemaleRadioButton.Name = "FemaleRadioButton";
            FemaleRadioButton.Size = new Size(92, 25);
            FemaleRadioButton.TabIndex = 6;
            FemaleRadioButton.TabStop = true;
            FemaleRadioButton.Text = "Женский";
            FemaleRadioButton.UseVisualStyleBackColor = true;
            // 
            // MaleRadioButton
            // 
            MaleRadioButton.AutoSize = true;
            MaleRadioButton.Location = new Point(14, 30);
            MaleRadioButton.Name = "MaleRadioButton";
            MaleRadioButton.Size = new Size(95, 25);
            MaleRadioButton.TabIndex = 0;
            MaleRadioButton.TabStop = true;
            MaleRadioButton.Text = "Мужской";
            MaleRadioButton.UseVisualStyleBackColor = true;
            // 
            // SertificateLabel
            // 
            SertificateLabel.AutoSize = true;
            SertificateLabel.Font = new Font("Segoe UI", 12F);
            SertificateLabel.Location = new Point(353, 313);
            SertificateLabel.Name = "SertificateLabel";
            SertificateLabel.Size = new Size(148, 21);
            SertificateLabel.TabIndex = 29;
            SertificateLabel.Text = "Папка для справки:";
            // 
            // CertificateSelectedFolderLabel
            // 
            CertificateSelectedFolderLabel.Location = new Point(353, 337);
            CertificateSelectedFolderLabel.Name = "CertificateSelectedFolderLabel";
            CertificateSelectedFolderLabel.ReadOnly = true;
            CertificateSelectedFolderLabel.Size = new Size(289, 23);
            CertificateSelectedFolderLabel.TabIndex = 28;
            // 
            // buttonCertificateSelectedFolder
            // 
            buttonCertificateSelectedFolder.Font = new Font("Segoe UI", 12F);
            buttonCertificateSelectedFolder.Location = new Point(353, 372);
            buttonCertificateSelectedFolder.Name = "buttonCertificateSelectedFolder";
            buttonCertificateSelectedFolder.Size = new Size(289, 50);
            buttonCertificateSelectedFolder.TabIndex = 10;
            buttonCertificateSelectedFolder.Text = "Выберите папку для справки";
            buttonCertificateSelectedFolder.UseVisualStyleBackColor = true;
            buttonCertificateSelectedFolder.Click += buttonCertificateSelectedFolder_Click;
            // 
            // FilesProgressBar
            // 
            FilesProgressBar.Location = new Point(12, 557);
            FilesProgressBar.Name = "FilesProgressBar";
            FilesProgressBar.Size = new Size(630, 23);
            FilesProgressBar.TabIndex = 30;
            // 
            // EmployeeComboBox
            // 
            EmployeeComboBox.FormattingEnabled = true;
            EmployeeComboBox.Location = new Point(162, 22);
            EmployeeComboBox.Name = "EmployeeComboBox";
            EmployeeComboBox.Size = new Size(121, 23);
            EmployeeComboBox.TabIndex = 7;
            // 
            // EmployeeGroupBox
            // 
            EmployeeGroupBox.Controls.Add(EmployeeTextBox);
            EmployeeGroupBox.Controls.Add(EmployeeComboBox);
            EmployeeGroupBox.Location = new Point(12, 439);
            EmployeeGroupBox.Name = "EmployeeGroupBox";
            EmployeeGroupBox.Size = new Size(289, 55);
            EmployeeGroupBox.TabIndex = 32;
            EmployeeGroupBox.TabStop = false;
            EmployeeGroupBox.Text = "Сотрудник";
            // 
            // EmployeeTextBox
            // 
            EmployeeTextBox.Location = new Point(6, 22);
            EmployeeTextBox.Name = "EmployeeTextBox";
            EmployeeTextBox.ReadOnly = true;
            EmployeeTextBox.Size = new Size(150, 23);
            EmployeeTextBox.TabIndex = 33;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 21F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(148, 106);
            label1.Name = "label1";
            label1.Size = new Size(353, 38);
            label1.TabIndex = 33;
            label1.Text = "за 2024-2025 учебный год";
            // 
            // SudentIDGroupBox
            // 
            SudentIDGroupBox.Controls.Add(StudentIDTextBox);
            SudentIDGroupBox.Location = new Point(12, 500);
            SudentIDGroupBox.Name = "SudentIDGroupBox";
            SudentIDGroupBox.Size = new Size(289, 51);
            SudentIDGroupBox.TabIndex = 34;
            SudentIDGroupBox.TabStop = false;
            SudentIDGroupBox.Text = "МЭШ ID";
            // 
            // StudentIDTextBox
            // 
            StudentIDTextBox.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            StudentIDTextBox.Location = new Point(6, 17);
            StudentIDTextBox.Margin = new Padding(3, 2, 3, 2);
            StudentIDTextBox.Name = "StudentIDTextBox";
            StudentIDTextBox.Size = new Size(277, 27);
            StudentIDTextBox.TabIndex = 8;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(652, 592);
            Controls.Add(SudentIDGroupBox);
            Controls.Add(label1);
            Controls.Add(EmployeeGroupBox);
            Controls.Add(FilesProgressBar);
            Controls.Add(SertificateLabel);
            Controls.Add(CertificateSelectedFolderLabel);
            Controls.Add(buttonCertificateSelectedFolder);
            Controls.Add(KidsSexBox);
            Controls.Add(secondNameTextBox);
            Controls.Add(secondNameLabel);
            Controls.Add(firstNameTextBox);
            Controls.Add(firstNameLabel);
            Controls.Add(labelOlimpiadsSelectedFolder);
            Controls.Add(OlimpiadsSelectedFolderLabel);
            Controls.Add(buttonOlimpiadsSelectFolder);
            Controls.Add(CerticateGeneratorButton);
            Controls.Add(label9);
            Controls.Add(loginSGTextBox);
            Controls.Add(StudyClassTextBox);
            Controls.Add(lastNameTextBox);
            Controls.Add(loginSGLabel);
            Controls.Add(StudyClassLabel);
            Controls.Add(lastNameLabel);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainForm";
            Text = "Генератор справок";
            Load += MainForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            KidsSexBox.ResumeLayout(false);
            KidsSexBox.PerformLayout();
            EmployeeGroupBox.ResumeLayout(false);
            EmployeeGroupBox.PerformLayout();
            SudentIDGroupBox.ResumeLayout(false);
            SudentIDGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lastNameLabel;
        private Label StudyClassLabel;
        private Label loginSGLabel;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem выходToolStripMenuItem;
        private Label label9;
        private Button CerticateGeneratorButton;
        public TextBox lastNameTextBox;
        public TextBox StudyClassTextBox;
        public TextBox loginSGTextBox;
        private FolderBrowserDialog folderBrowserDialog1;
        private Button buttonOlimpiadsSelectFolder;
        private TextBox OlimpiadsSelectedFolderLabel;
        private Label labelOlimpiadsSelectedFolder;
        public TextBox firstNameTextBox;
        private Label firstNameLabel;
        public TextBox secondNameTextBox;
        private Label secondNameLabel;
        private GroupBox KidsSexBox;
        private RadioButton FemaleRadioButton;
        private RadioButton MaleRadioButton;
        private Label SertificateLabel;
        private TextBox CertificateSelectedFolderLabel;
        private Button buttonCertificateSelectedFolder;
        private ComboBox EmployeeComboBox;
        private GroupBox EmployeeGroupBox;
        private TextBox EmployeeTextBox;
        private Label label1;
        public ProgressBar FilesProgressBar;
        private GroupBox SudentIDGroupBox;
        public TextBox StudentIDTextBox;
    }
}
