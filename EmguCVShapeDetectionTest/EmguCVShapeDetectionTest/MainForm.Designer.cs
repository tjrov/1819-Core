namespace EmguCVShapeDetectionTest {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.openFile = new System.Windows.Forms.Button();
            this.contours = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.square = new System.Windows.Forms.PictureBox();
            this.circle = new System.Windows.Forms.PictureBox();
            this.line = new System.Windows.Forms.PictureBox();
            this.triangle = new System.Windows.Forms.PictureBox();
            this.squareNum = new System.Windows.Forms.Label();
            this.circleNum = new System.Windows.Forms.Label();
            this.lineNum = new System.Windows.Forms.Label();
            this.triangleNum = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.imageOriginal = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.processedImage = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.finalImage = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.smoothGaussian = new System.Windows.Forms.TextBox();
            this.lower = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.inverse = new System.Windows.Forms.CheckBox();
            this.pyr = new System.Windows.Forms.CheckBox();
            this.messages = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.upper = new System.Windows.Forms.TextBox();
            this.approxValue = new System.Windows.Forms.TextBox();
            this.ratioValue = new System.Windows.Forms.TextBox();
            this.frame = new System.Windows.Forms.Button();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.videoSource = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.widthText = new System.Windows.Forms.TextBox();
            this.heightText = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.cropByPercentage = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
            this.top = new PlaceHolderTextBox();
            this.bottom = new PlaceHolderTextBox();
            this.left = new PlaceHolderTextBox();
            this.right = new PlaceHolderTextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.square)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.circle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.line)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.triangle)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageOriginal)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.processedImage)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.finalImage)).BeginInit();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.tableLayoutPanel12.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.openFile, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.contours, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel6, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel7, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.frame, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel9, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel11, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.cropByPercentage, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1507, 618);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // openFile
            // 
            this.openFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openFile.Location = new System.Drawing.Point(3, 3);
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(370, 86);
            this.openFile.TabIndex = 0;
            this.openFile.Text = "Open Image";
            this.openFile.UseVisualStyleBackColor = true;
            this.openFile.Click += new System.EventHandler(this.openFile_Click);
            // 
            // contours
            // 
            this.contours.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contours.Location = new System.Drawing.Point(755, 3);
            this.contours.Name = "contours";
            this.contours.Size = new System.Drawing.Size(370, 86);
            this.contours.TabIndex = 1;
            this.contours.Text = "Find \"Organisms\"";
            this.contours.UseVisualStyleBackColor = true;
            this.contours.Click += new System.EventHandler(this.contours_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.square, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.circle, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.line, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.triangle, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.squareNum, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.circleNum, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lineNum, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.triangleNum, 1, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(755, 465);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(370, 150);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // square
            // 
            this.square.Dock = System.Windows.Forms.DockStyle.Fill;
            this.square.Image = global::EmguCVShapeDetectionTest.Properties.Resources.triangle;
            this.square.Location = new System.Drawing.Point(3, 3);
            this.square.Name = "square";
            this.square.Size = new System.Drawing.Size(179, 31);
            this.square.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.square.TabIndex = 0;
            this.square.TabStop = false;
            // 
            // circle
            // 
            this.circle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.circle.Image = global::EmguCVShapeDetectionTest.Properties.Resources.circle;
            this.circle.Location = new System.Drawing.Point(3, 40);
            this.circle.Name = "circle";
            this.circle.Size = new System.Drawing.Size(179, 31);
            this.circle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.circle.TabIndex = 1;
            this.circle.TabStop = false;
            // 
            // line
            // 
            this.line.Dock = System.Windows.Forms.DockStyle.Fill;
            this.line.Image = global::EmguCVShapeDetectionTest.Properties.Resources.line;
            this.line.Location = new System.Drawing.Point(3, 77);
            this.line.Name = "line";
            this.line.Size = new System.Drawing.Size(179, 31);
            this.line.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.line.TabIndex = 2;
            this.line.TabStop = false;
            // 
            // triangle
            // 
            this.triangle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.triangle.Image = global::EmguCVShapeDetectionTest.Properties.Resources.triangleImage;
            this.triangle.Location = new System.Drawing.Point(3, 114);
            this.triangle.Name = "triangle";
            this.triangle.Size = new System.Drawing.Size(179, 33);
            this.triangle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.triangle.TabIndex = 3;
            this.triangle.TabStop = false;
            // 
            // squareNum
            // 
            this.squareNum.AutoSize = true;
            this.squareNum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.squareNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.squareNum.ForeColor = System.Drawing.Color.Red;
            this.squareNum.Location = new System.Drawing.Point(188, 0);
            this.squareNum.Name = "squareNum";
            this.squareNum.Size = new System.Drawing.Size(179, 37);
            this.squareNum.TabIndex = 4;
            this.squareNum.Text = "0";
            this.squareNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // circleNum
            // 
            this.circleNum.AutoSize = true;
            this.circleNum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.circleNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.circleNum.ForeColor = System.Drawing.Color.Red;
            this.circleNum.Location = new System.Drawing.Point(188, 37);
            this.circleNum.Name = "circleNum";
            this.circleNum.Size = new System.Drawing.Size(179, 37);
            this.circleNum.TabIndex = 5;
            this.circleNum.Text = "0";
            this.circleNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lineNum
            // 
            this.lineNum.AutoSize = true;
            this.lineNum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lineNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.lineNum.ForeColor = System.Drawing.Color.Red;
            this.lineNum.Location = new System.Drawing.Point(188, 74);
            this.lineNum.Name = "lineNum";
            this.lineNum.Size = new System.Drawing.Size(179, 37);
            this.lineNum.TabIndex = 6;
            this.lineNum.Text = "0";
            this.lineNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // triangleNum
            // 
            this.triangleNum.AutoSize = true;
            this.triangleNum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.triangleNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.triangleNum.ForeColor = System.Drawing.Color.Red;
            this.triangleNum.Location = new System.Drawing.Point(188, 111);
            this.triangleNum.Name = "triangleNum";
            this.triangleNum.Size = new System.Drawing.Size(179, 39);
            this.triangleNum.TabIndex = 7;
            this.triangleNum.Text = "0";
            this.triangleNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.imageOriginal, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 95);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(370, 364);
            this.tableLayoutPanel3.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(364, 72);
            this.label1.TabIndex = 0;
            this.label1.Text = "Image Source";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imageOriginal
            // 
            this.imageOriginal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageOriginal.Location = new System.Drawing.Point(3, 75);
            this.imageOriginal.Name = "imageOriginal";
            this.imageOriginal.Size = new System.Drawing.Size(364, 286);
            this.imageOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imageOriginal.TabIndex = 1;
            this.imageOriginal.TabStop = false;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.processedImage, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(379, 95);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(370, 364);
            this.tableLayoutPanel4.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(364, 72);
            this.label2.TabIndex = 0;
            this.label2.Text = "Processed Image";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // processedImage
            // 
            this.processedImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.processedImage.Location = new System.Drawing.Point(3, 75);
            this.processedImage.Name = "processedImage";
            this.processedImage.Size = new System.Drawing.Size(364, 286);
            this.processedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.processedImage.TabIndex = 1;
            this.processedImage.TabStop = false;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.finalImage, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(755, 95);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(370, 364);
            this.tableLayoutPanel5.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(364, 72);
            this.label3.TabIndex = 0;
            this.label3.Text = "Final Image";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // finalImage
            // 
            this.finalImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.finalImage.Location = new System.Drawing.Point(3, 75);
            this.finalImage.Name = "finalImage";
            this.finalImage.Size = new System.Drawing.Size(364, 286);
            this.finalImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.finalImage.TabIndex = 1;
            this.finalImage.TabStop = false;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 3;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel6.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.label5, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.label9, 2, 0);
            this.tableLayoutPanel6.Controls.Add(this.smoothGaussian, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.lower, 2, 1);
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel8, 1, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 465);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(370, 150);
            this.tableLayoutPanel6.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(117, 30);
            this.label4.TabIndex = 0;
            this.label4.Text = "Smooth Gaussian Parameter";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(126, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 30);
            this.label5.TabIndex = 1;
            this.label5.Text = "Threshold";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(249, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(118, 30);
            this.label9.TabIndex = 2;
            this.label9.Text = "Threshold Gray Lower Bound";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // smoothGaussian
            // 
            this.smoothGaussian.Dock = System.Windows.Forms.DockStyle.Top;
            this.smoothGaussian.Location = new System.Drawing.Point(3, 33);
            this.smoothGaussian.Name = "smoothGaussian";
            this.smoothGaussian.Size = new System.Drawing.Size(117, 20);
            this.smoothGaussian.TabIndex = 3;
            this.smoothGaussian.Text = "5";
            this.smoothGaussian.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lower
            // 
            this.lower.Dock = System.Windows.Forms.DockStyle.Top;
            this.lower.Location = new System.Drawing.Point(249, 33);
            this.lower.Name = "lower";
            this.lower.Size = new System.Drawing.Size(118, 20);
            this.lower.TabIndex = 4;
            this.lower.Text = "88";
            this.lower.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 1;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Controls.Add(this.inverse, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.pyr, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.messages, 0, 2);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(126, 33);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 3;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(117, 80);
            this.tableLayoutPanel8.TabIndex = 5;
            // 
            // inverse
            // 
            this.inverse.AutoSize = true;
            this.inverse.Checked = true;
            this.inverse.CheckState = System.Windows.Forms.CheckState.Checked;
            this.inverse.Location = new System.Drawing.Point(3, 3);
            this.inverse.Name = "inverse";
            this.inverse.Size = new System.Drawing.Size(61, 17);
            this.inverse.TabIndex = 0;
            this.inverse.Text = "Inverse";
            this.inverse.UseVisualStyleBackColor = true;
            // 
            // pyr
            // 
            this.pyr.AutoSize = true;
            this.pyr.Location = new System.Drawing.Point(3, 29);
            this.pyr.Name = "pyr";
            this.pyr.Size = new System.Drawing.Size(92, 17);
            this.pyr.TabIndex = 1;
            this.pyr.Text = "Noise Filtering";
            this.pyr.UseVisualStyleBackColor = true;
            // 
            // messages
            // 
            this.messages.AutoSize = true;
            this.messages.Dock = System.Windows.Forms.DockStyle.Top;
            this.messages.Location = new System.Drawing.Point(3, 55);
            this.messages.Name = "messages";
            this.messages.Size = new System.Drawing.Size(111, 17);
            this.messages.TabIndex = 2;
            this.messages.Text = "Identify Every Shape Individually";
            this.messages.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 3;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel7.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.label7, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.label8, 2, 0);
            this.tableLayoutPanel7.Controls.Add(this.upper, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.approxValue, 1, 1);
            this.tableLayoutPanel7.Controls.Add(this.ratioValue, 2, 1);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(379, 465);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 2;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(370, 150);
            this.tableLayoutPanel7.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 30);
            this.label6.TabIndex = 0;
            this.label6.Text = "Threshold Gray Higher Bound";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(126, 0);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label7.Size = new System.Drawing.Size(117, 30);
            this.label7.TabIndex = 1;
            this.label7.Text = "Approximation Accuracy";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(249, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 30);
            this.label8.TabIndex = 2;
            this.label8.Text = "Ratio";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // upper
            // 
            this.upper.Dock = System.Windows.Forms.DockStyle.Top;
            this.upper.Location = new System.Drawing.Point(3, 33);
            this.upper.Name = "upper";
            this.upper.Size = new System.Drawing.Size(117, 20);
            this.upper.TabIndex = 3;
            this.upper.Text = "255";
            this.upper.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // approxValue
            // 
            this.approxValue.Dock = System.Windows.Forms.DockStyle.Top;
            this.approxValue.Location = new System.Drawing.Point(126, 33);
            this.approxValue.Name = "approxValue";
            this.approxValue.Size = new System.Drawing.Size(117, 20);
            this.approxValue.TabIndex = 4;
            this.approxValue.Text = "0.05";
            this.approxValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ratioValue
            // 
            this.ratioValue.Dock = System.Windows.Forms.DockStyle.Top;
            this.ratioValue.Location = new System.Drawing.Point(249, 33);
            this.ratioValue.Name = "ratioValue";
            this.ratioValue.Size = new System.Drawing.Size(118, 20);
            this.ratioValue.TabIndex = 5;
            this.ratioValue.Text = "0.8";
            this.ratioValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frame
            // 
            this.frame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.frame.Location = new System.Drawing.Point(379, 3);
            this.frame.Name = "frame";
            this.frame.Size = new System.Drawing.Size(370, 86);
            this.frame.TabIndex = 11;
            this.frame.Text = "Grab Frame";
            this.frame.UseVisualStyleBackColor = true;
            this.frame.Click += new System.EventHandler(this.frame_Click);
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 3;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel9.Controls.Add(this.label10, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.videoSource, 0, 1);
            this.tableLayoutPanel9.Controls.Add(this.tableLayoutPanel10, 1, 1);
            this.tableLayoutPanel9.Controls.Add(this.label11, 1, 0);
            this.tableLayoutPanel9.Controls.Add(this.label12, 2, 0);
            this.tableLayoutPanel9.Controls.Add(this.tableLayoutPanel12, 2, 1);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(1131, 465);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 2;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(373, 150);
            this.tableLayoutPanel9.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(118, 30);
            this.label10.TabIndex = 0;
            this.label10.Text = "Video Source (0,1...)";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // videoSource
            // 
            this.videoSource.Dock = System.Windows.Forms.DockStyle.Top;
            this.videoSource.Location = new System.Drawing.Point(3, 33);
            this.videoSource.Name = "videoSource";
            this.videoSource.Size = new System.Drawing.Size(118, 20);
            this.videoSource.TabIndex = 1;
            this.videoSource.Text = "1";
            this.videoSource.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 1;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.Controls.Add(this.widthText, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.heightText, 0, 1);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(127, 33);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 2;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(118, 80);
            this.tableLayoutPanel10.TabIndex = 2;
            // 
            // widthText
            // 
            this.widthText.Dock = System.Windows.Forms.DockStyle.Top;
            this.widthText.Location = new System.Drawing.Point(3, 3);
            this.widthText.Name = "widthText";
            this.widthText.Size = new System.Drawing.Size(112, 20);
            this.widthText.TabIndex = 0;
            this.widthText.Text = "200";
            this.widthText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // heightText
            // 
            this.heightText.Dock = System.Windows.Forms.DockStyle.Top;
            this.heightText.Location = new System.Drawing.Point(3, 43);
            this.heightText.Name = "heightText";
            this.heightText.Size = new System.Drawing.Size(112, 20);
            this.heightText.TabIndex = 1;
            this.heightText.Text = "200";
            this.heightText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(127, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(118, 30);
            this.label11.TabIndex = 3;
            this.label11.Text = "Width, Height";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.ColumnCount = 1;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(1131, 95);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 2;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(373, 364);
            this.tableLayoutPanel11.TabIndex = 13;
            // 
            // cropByPercentage
            // 
            this.cropByPercentage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cropByPercentage.Location = new System.Drawing.Point(1131, 3);
            this.cropByPercentage.Name = "cropByPercentage";
            this.cropByPercentage.Size = new System.Drawing.Size(373, 86);
            this.cropByPercentage.TabIndex = 14;
            this.cropByPercentage.Text = "Crop Image (Fixed Width and Height)";
            this.cropByPercentage.UseVisualStyleBackColor = true;
            this.cropByPercentage.Click += new System.EventHandler(this.cropByPercentage_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(251, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(119, 30);
            this.label12.TabIndex = 4;
            this.label12.Text = "Crop Settings";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel12
            // 
            this.tableLayoutPanel12.ColumnCount = 1;
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel12.Controls.Add(this.top, 0, 0);
            this.tableLayoutPanel12.Controls.Add(this.bottom, 0, 1);
            this.tableLayoutPanel12.Controls.Add(this.left, 0, 2);
            this.tableLayoutPanel12.Controls.Add(this.right, 0, 3);
            this.tableLayoutPanel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel12.Location = new System.Drawing.Point(251, 33);
            this.tableLayoutPanel12.Name = "tableLayoutPanel12";
            this.tableLayoutPanel12.RowCount = 4;
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel12.Size = new System.Drawing.Size(119, 114);
            this.tableLayoutPanel12.TabIndex = 5;
            // 
            // top
            // 
            this.top.Dock = System.Windows.Forms.DockStyle.Fill;
            this.top.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic);
            this.top.ForeColor = System.Drawing.Color.Gray;
            this.top.Location = new System.Drawing.Point(3, 3);
            this.top.Name = "top";
            this.top.PlaceHolderText = null;
            this.top.Size = new System.Drawing.Size(113, 20);
            this.top.TabIndex = 0;
            this.top.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bottom
            // 
            this.bottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic);
            this.bottom.ForeColor = System.Drawing.Color.Gray;
            this.bottom.Location = new System.Drawing.Point(3, 31);
            this.bottom.Name = "bottom";
            this.bottom.PlaceHolderText = null;
            this.bottom.Size = new System.Drawing.Size(113, 20);
            this.bottom.TabIndex = 1;
            this.bottom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // left
            // 
            this.left.Dock = System.Windows.Forms.DockStyle.Fill;
            this.left.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic);
            this.left.ForeColor = System.Drawing.Color.Gray;
            this.left.Location = new System.Drawing.Point(3, 59);
            this.left.Name = "left";
            this.left.PlaceHolderText = null;
            this.left.Size = new System.Drawing.Size(113, 20);
            this.left.TabIndex = 2;
            this.left.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // right
            // 
            this.right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.right.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic);
            this.right.ForeColor = System.Drawing.Color.Gray;
            this.right.Location = new System.Drawing.Point(3, 87);
            this.right.Name = "right";
            this.right.PlaceHolderText = null;
            this.right.Size = new System.Drawing.Size(113, 20);
            this.right.TabIndex = 3;
            this.right.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1507, 618);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.square)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.circle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.line)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.triangle)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageOriginal)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.processedImage)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.finalImage)).EndInit();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            this.tableLayoutPanel12.ResumeLayout(false);
            this.tableLayoutPanel12.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button openFile;
        private System.Windows.Forms.Button contours;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox square;
        private System.Windows.Forms.PictureBox circle;
        private System.Windows.Forms.PictureBox line;
        private System.Windows.Forms.PictureBox triangle;
        private System.Windows.Forms.Label squareNum;
        private System.Windows.Forms.Label circleNum;
        private System.Windows.Forms.Label lineNum;
        private System.Windows.Forms.Label triangleNum;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox imageOriginal;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox processedImage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox finalImage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox smoothGaussian;
        private System.Windows.Forms.TextBox lower;
        private System.Windows.Forms.TextBox upper;
        private System.Windows.Forms.TextBox approxValue;
        private System.Windows.Forms.TextBox ratioValue;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.CheckBox inverse;
        private System.Windows.Forms.CheckBox pyr;
        private System.Windows.Forms.Button frame;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox videoSource;
        private System.Windows.Forms.CheckBox messages;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.TextBox widthText;
        private System.Windows.Forms.TextBox heightText;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private System.Windows.Forms.Button cropByPercentage;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel12;
        private PlaceHolderTextBox top;
        private PlaceHolderTextBox bottom;
        private PlaceHolderTextBox left;
        private PlaceHolderTextBox right;
    }
}