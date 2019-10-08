namespace Charlotte
{
	partial class MainWin
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWin));
			this.MainTimer = new System.Windows.Forms.Timer(this.components);
			this.MainToolTip = new System.Windows.Forms.ToolTip(this.components);
			this.TabPage個数 = new System.Windows.Forms.TabPage();
			this.Btn個数 = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.L個数_最大値 = new System.Windows.Forms.Label();
			this.L個数_最小値 = new System.Windows.Forms.Label();
			this.T個数_最大値 = new System.Windows.Forms.TextBox();
			this.T個数_最小値 = new System.Windows.Forms.TextBox();
			this.TabPage素因数分解 = new System.Windows.Forms.TabPage();
			this.T素因数分解_結果 = new System.Windows.Forms.TextBox();
			this.T素因数分解_入力 = new System.Windows.Forms.TextBox();
			this.Btn素因数分解 = new System.Windows.Forms.Button();
			this.TabPage判定 = new System.Windows.Forms.TabPage();
			this.T判定_結果 = new System.Windows.Forms.TextBox();
			this.T判定_入力 = new System.Windows.Forms.TextBox();
			this.Btn判定 = new System.Windows.Forms.Button();
			this.TabPage出力 = new System.Windows.Forms.TabPage();
			this.Btn出力 = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.L出力_最大値 = new System.Windows.Forms.Label();
			this.L出力_最小値 = new System.Windows.Forms.Label();
			this.T出力_最大値 = new System.Windows.Forms.TextBox();
			this.T出力_最小値 = new System.Windows.Forms.TextBox();
			this.MainTab = new System.Windows.Forms.TabControl();
			this.TabPage最寄りの素数 = new System.Windows.Forms.TabPage();
			this.Btn探索 = new System.Windows.Forms.Button();
			this.T探索_結果 = new System.Windows.Forms.TextBox();
			this.T探索_入力 = new System.Windows.Forms.TextBox();
			this.TabPage個数.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.TabPage素因数分解.SuspendLayout();
			this.TabPage判定.SuspendLayout();
			this.TabPage出力.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.MainTab.SuspendLayout();
			this.TabPage最寄りの素数.SuspendLayout();
			this.SuspendLayout();
			// 
			// MainTimer
			// 
			this.MainTimer.Enabled = true;
			this.MainTimer.Tick += new System.EventHandler(this.MainTimer_Tick);
			// 
			// MainToolTip
			// 
			this.MainToolTip.AutoPopDelay = 20000;
			this.MainToolTip.InitialDelay = 500;
			this.MainToolTip.ReshowDelay = 100;
			// 
			// TabPage個数
			// 
			this.TabPage個数.Controls.Add(this.Btn個数);
			this.TabPage個数.Controls.Add(this.groupBox2);
			this.TabPage個数.Location = new System.Drawing.Point(4, 29);
			this.TabPage個数.Name = "TabPage個数";
			this.TabPage個数.Size = new System.Drawing.Size(652, 404);
			this.TabPage個数.TabIndex = 3;
			this.TabPage個数.Text = "個数";
			this.TabPage個数.UseVisualStyleBackColor = true;
			// 
			// Btn個数
			// 
			this.Btn個数.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Btn個数.Location = new System.Drawing.Point(265, 340);
			this.Btn個数.Name = "Btn個数";
			this.Btn個数.Size = new System.Drawing.Size(370, 50);
			this.Btn個数.TabIndex = 1;
			this.Btn個数.Text = "指定された範囲の素数の「個数」をファイルに出力する";
			this.Btn個数.UseVisualStyleBackColor = true;
			this.Btn個数.Click += new System.EventHandler(this.Btn個数_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.L個数_最大値);
			this.groupBox2.Controls.Add(this.L個数_最小値);
			this.groupBox2.Controls.Add(this.T個数_最大値);
			this.groupBox2.Controls.Add(this.T個数_最小値);
			this.groupBox2.Location = new System.Drawing.Point(15, 15);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(620, 319);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "検索する範囲";
			// 
			// L個数_最大値
			// 
			this.L個数_最大値.AutoSize = true;
			this.L個数_最大値.Location = new System.Drawing.Point(11, 165);
			this.L個数_最大値.Name = "L個数_最大値";
			this.L個数_最大値.Size = new System.Drawing.Size(48, 20);
			this.L個数_最大値.TabIndex = 2;
			this.L個数_最大値.Text = "最大値";
			// 
			// L個数_最小値
			// 
			this.L個数_最小値.AutoSize = true;
			this.L個数_最小値.Location = new System.Drawing.Point(11, 23);
			this.L個数_最小値.Name = "L個数_最小値";
			this.L個数_最小値.Size = new System.Drawing.Size(48, 20);
			this.L個数_最小値.TabIndex = 0;
			this.L個数_最小値.Text = "最小値";
			// 
			// T個数_最大値
			// 
			this.T個数_最大値.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.T個数_最大値.Location = new System.Drawing.Point(15, 188);
			this.T個数_最大値.MaxLength = 1234;
			this.T個数_最大値.Multiline = true;
			this.T個数_最大値.Name = "T個数_最大値";
			this.T個数_最大値.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.T個数_最大値.Size = new System.Drawing.Size(588, 106);
			this.T個数_最大値.TabIndex = 3;
			this.T個数_最大値.Text = "1行目\r\n2行目\r\n3行目\r\n4行目\r\n5行目";
			// 
			// T個数_最小値
			// 
			this.T個数_最小値.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.T個数_最小値.Location = new System.Drawing.Point(15, 46);
			this.T個数_最小値.MaxLength = 1234;
			this.T個数_最小値.Multiline = true;
			this.T個数_最小値.Name = "T個数_最小値";
			this.T個数_最小値.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.T個数_最小値.Size = new System.Drawing.Size(588, 106);
			this.T個数_最小値.TabIndex = 1;
			this.T個数_最小値.Text = "1行目\r\n2行目\r\n3行目\r\n4行目\r\n5行目";
			// 
			// TabPage素因数分解
			// 
			this.TabPage素因数分解.Controls.Add(this.T素因数分解_結果);
			this.TabPage素因数分解.Controls.Add(this.T素因数分解_入力);
			this.TabPage素因数分解.Controls.Add(this.Btn素因数分解);
			this.TabPage素因数分解.Location = new System.Drawing.Point(4, 29);
			this.TabPage素因数分解.Name = "TabPage素因数分解";
			this.TabPage素因数分解.Size = new System.Drawing.Size(652, 404);
			this.TabPage素因数分解.TabIndex = 2;
			this.TabPage素因数分解.Text = "素因数分解";
			this.TabPage素因数分解.UseVisualStyleBackColor = true;
			// 
			// T素因数分解_結果
			// 
			this.T素因数分解_結果.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.T素因数分解_結果.Location = new System.Drawing.Point(15, 203);
			this.T素因数分解_結果.Multiline = true;
			this.T素因数分解_結果.Name = "T素因数分解_結果";
			this.T素因数分解_結果.ReadOnly = true;
			this.T素因数分解_結果.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.T素因数分解_結果.Size = new System.Drawing.Size(620, 186);
			this.T素因数分解_結果.TabIndex = 2;
			this.T素因数分解_結果.Text = "1行目\r\n2行目\r\n3行目\r\n4行目\r\n5行目\r\n6行目\r\n7行目\r\n8行目\r\n9行目";
			this.T素因数分解_結果.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.T素因数分解_結果_KeyPress);
			// 
			// T素因数分解_入力
			// 
			this.T素因数分解_入力.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.T素因数分解_入力.Location = new System.Drawing.Point(15, 15);
			this.T素因数分解_入力.MaxLength = 1234;
			this.T素因数分解_入力.Multiline = true;
			this.T素因数分解_入力.Name = "T素因数分解_入力";
			this.T素因数分解_入力.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.T素因数分解_入力.Size = new System.Drawing.Size(620, 126);
			this.T素因数分解_入力.TabIndex = 0;
			this.T素因数分解_入力.Text = "1行目\r\n2行目\r\n3行目\r\n4行目\r\n5行目\r\n6行目";
			// 
			// Btn素因数分解
			// 
			this.Btn素因数分解.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Btn素因数分解.Location = new System.Drawing.Point(455, 147);
			this.Btn素因数分解.Name = "Btn素因数分解";
			this.Btn素因数分解.Size = new System.Drawing.Size(180, 50);
			this.Btn素因数分解.TabIndex = 1;
			this.Btn素因数分解.Text = "素因数分解";
			this.Btn素因数分解.UseVisualStyleBackColor = true;
			this.Btn素因数分解.Click += new System.EventHandler(this.Btn素因数分解_Click);
			// 
			// TabPage判定
			// 
			this.TabPage判定.Controls.Add(this.T判定_結果);
			this.TabPage判定.Controls.Add(this.T判定_入力);
			this.TabPage判定.Controls.Add(this.Btn判定);
			this.TabPage判定.Location = new System.Drawing.Point(4, 29);
			this.TabPage判定.Name = "TabPage判定";
			this.TabPage判定.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage判定.Size = new System.Drawing.Size(652, 404);
			this.TabPage判定.TabIndex = 1;
			this.TabPage判定.Text = "判定";
			this.TabPage判定.UseVisualStyleBackColor = true;
			// 
			// T判定_結果
			// 
			this.T判定_結果.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.T判定_結果.Location = new System.Drawing.Point(15, 203);
			this.T判定_結果.Multiline = true;
			this.T判定_結果.Name = "T判定_結果";
			this.T判定_結果.ReadOnly = true;
			this.T判定_結果.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.T判定_結果.Size = new System.Drawing.Size(620, 186);
			this.T判定_結果.TabIndex = 3;
			this.T判定_結果.Text = "1行目\r\n2行目\r\n3行目\r\n4行目\r\n5行目\r\n6行目\r\n7行目\r\n8行目\r\n9行目";
			this.T判定_結果.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.T判定_結果_KeyPress);
			// 
			// T判定_入力
			// 
			this.T判定_入力.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.T判定_入力.Location = new System.Drawing.Point(15, 15);
			this.T判定_入力.MaxLength = 1234;
			this.T判定_入力.Multiline = true;
			this.T判定_入力.Name = "T判定_入力";
			this.T判定_入力.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.T判定_入力.Size = new System.Drawing.Size(620, 126);
			this.T判定_入力.TabIndex = 0;
			this.T判定_入力.Text = "1行目\r\n2行目\r\n3行目\r\n4行目\r\n5行目\r\n6行目";
			// 
			// Btn判定
			// 
			this.Btn判定.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Btn判定.Location = new System.Drawing.Point(455, 147);
			this.Btn判定.Name = "Btn判定";
			this.Btn判定.Size = new System.Drawing.Size(180, 50);
			this.Btn判定.TabIndex = 1;
			this.Btn判定.Text = "素数かどうか判定する";
			this.Btn判定.UseVisualStyleBackColor = true;
			this.Btn判定.Click += new System.EventHandler(this.Btn判定_Click);
			// 
			// TabPage出力
			// 
			this.TabPage出力.Controls.Add(this.Btn出力);
			this.TabPage出力.Controls.Add(this.groupBox1);
			this.TabPage出力.Location = new System.Drawing.Point(4, 29);
			this.TabPage出力.Name = "TabPage出力";
			this.TabPage出力.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage出力.Size = new System.Drawing.Size(652, 404);
			this.TabPage出力.TabIndex = 0;
			this.TabPage出力.Text = "出力";
			this.TabPage出力.UseVisualStyleBackColor = true;
			// 
			// Btn出力
			// 
			this.Btn出力.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Btn出力.Location = new System.Drawing.Point(335, 340);
			this.Btn出力.Name = "Btn出力";
			this.Btn出力.Size = new System.Drawing.Size(300, 50);
			this.Btn出力.TabIndex = 2;
			this.Btn出力.Text = "指定された範囲の素数をファイルに出力";
			this.Btn出力.UseVisualStyleBackColor = true;
			this.Btn出力.Click += new System.EventHandler(this.Btn出力_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.L出力_最大値);
			this.groupBox1.Controls.Add(this.L出力_最小値);
			this.groupBox1.Controls.Add(this.T出力_最大値);
			this.groupBox1.Controls.Add(this.T出力_最小値);
			this.groupBox1.Location = new System.Drawing.Point(15, 15);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(620, 319);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "出力する範囲";
			// 
			// L出力_最大値
			// 
			this.L出力_最大値.AutoSize = true;
			this.L出力_最大値.Location = new System.Drawing.Point(11, 165);
			this.L出力_最大値.Name = "L出力_最大値";
			this.L出力_最大値.Size = new System.Drawing.Size(48, 20);
			this.L出力_最大値.TabIndex = 2;
			this.L出力_最大値.Text = "最大値";
			// 
			// L出力_最小値
			// 
			this.L出力_最小値.AutoSize = true;
			this.L出力_最小値.Location = new System.Drawing.Point(11, 23);
			this.L出力_最小値.Name = "L出力_最小値";
			this.L出力_最小値.Size = new System.Drawing.Size(48, 20);
			this.L出力_最小値.TabIndex = 0;
			this.L出力_最小値.Text = "最小値";
			// 
			// T出力_最大値
			// 
			this.T出力_最大値.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.T出力_最大値.Location = new System.Drawing.Point(15, 188);
			this.T出力_最大値.MaxLength = 1234;
			this.T出力_最大値.Multiline = true;
			this.T出力_最大値.Name = "T出力_最大値";
			this.T出力_最大値.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.T出力_最大値.Size = new System.Drawing.Size(588, 106);
			this.T出力_最大値.TabIndex = 3;
			this.T出力_最大値.Text = "1行目\r\n2行目\r\n3行目\r\n4行目\r\n5行目";
			// 
			// T出力_最小値
			// 
			this.T出力_最小値.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.T出力_最小値.Location = new System.Drawing.Point(15, 46);
			this.T出力_最小値.MaxLength = 1234;
			this.T出力_最小値.Multiline = true;
			this.T出力_最小値.Name = "T出力_最小値";
			this.T出力_最小値.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.T出力_最小値.Size = new System.Drawing.Size(588, 106);
			this.T出力_最小値.TabIndex = 1;
			this.T出力_最小値.Text = "1行目\r\n2行目\r\n3行目\r\n4行目\r\n5行目";
			// 
			// MainTab
			// 
			this.MainTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.MainTab.Controls.Add(this.TabPage出力);
			this.MainTab.Controls.Add(this.TabPage判定);
			this.MainTab.Controls.Add(this.TabPage最寄りの素数);
			this.MainTab.Controls.Add(this.TabPage素因数分解);
			this.MainTab.Controls.Add(this.TabPage個数);
			this.MainTab.Location = new System.Drawing.Point(12, 12);
			this.MainTab.Name = "MainTab";
			this.MainTab.SelectedIndex = 0;
			this.MainTab.Size = new System.Drawing.Size(660, 437);
			this.MainTab.TabIndex = 0;
			// 
			// TabPage最寄りの素数
			// 
			this.TabPage最寄りの素数.Controls.Add(this.Btn探索);
			this.TabPage最寄りの素数.Controls.Add(this.T探索_結果);
			this.TabPage最寄りの素数.Controls.Add(this.T探索_入力);
			this.TabPage最寄りの素数.Location = new System.Drawing.Point(4, 29);
			this.TabPage最寄りの素数.Name = "TabPage最寄りの素数";
			this.TabPage最寄りの素数.Size = new System.Drawing.Size(652, 404);
			this.TabPage最寄りの素数.TabIndex = 4;
			this.TabPage最寄りの素数.Text = "最寄りの素数";
			this.TabPage最寄りの素数.UseVisualStyleBackColor = true;
			// 
			// Btn探索
			// 
			this.Btn探索.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Btn探索.Location = new System.Drawing.Point(455, 147);
			this.Btn探索.Name = "Btn探索";
			this.Btn探索.Size = new System.Drawing.Size(180, 50);
			this.Btn探索.TabIndex = 1;
			this.Btn探索.Text = "最寄りの素数を探す";
			this.Btn探索.UseVisualStyleBackColor = true;
			this.Btn探索.Click += new System.EventHandler(this.Btn探索_Click);
			// 
			// T探索_結果
			// 
			this.T探索_結果.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.T探索_結果.Location = new System.Drawing.Point(15, 203);
			this.T探索_結果.Multiline = true;
			this.T探索_結果.Name = "T探索_結果";
			this.T探索_結果.ReadOnly = true;
			this.T探索_結果.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.T探索_結果.Size = new System.Drawing.Size(620, 186);
			this.T探索_結果.TabIndex = 2;
			this.T探索_結果.Text = "1行目\r\n2行目\r\n3行目\r\n4行目\r\n5行目\r\n6行目\r\n7行目\r\n8行目\r\n9行目";
			this.T探索_結果.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.T探索_結果_KeyPress);
			// 
			// T探索_入力
			// 
			this.T探索_入力.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.T探索_入力.Location = new System.Drawing.Point(15, 15);
			this.T探索_入力.MaxLength = 1234;
			this.T探索_入力.Multiline = true;
			this.T探索_入力.Name = "T探索_入力";
			this.T探索_入力.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.T探索_入力.Size = new System.Drawing.Size(620, 126);
			this.T探索_入力.TabIndex = 0;
			this.T探索_入力.Text = "1行目\r\n2行目\r\n3行目\r\n4行目\r\n5行目\r\n6行目";
			// 
			// MainWin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(684, 461);
			this.Controls.Add(this.MainTab);
			this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "MainWin";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Prime4096";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWin_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWin_FormClosed);
			this.Load += new System.EventHandler(this.MainWin_Load);
			this.Shown += new System.EventHandler(this.MainWin_Shown);
			this.ResizeBegin += new System.EventHandler(this.MainWin_ResizeBegin);
			this.ResizeEnd += new System.EventHandler(this.MainWin_ResizeEnd);
			this.SizeChanged += new System.EventHandler(this.MainWin_SizeChanged);
			this.Resize += new System.EventHandler(this.MainWin_Resize);
			this.TabPage個数.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.TabPage素因数分解.ResumeLayout(false);
			this.TabPage素因数分解.PerformLayout();
			this.TabPage判定.ResumeLayout(false);
			this.TabPage判定.PerformLayout();
			this.TabPage出力.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.MainTab.ResumeLayout(false);
			this.TabPage最寄りの素数.ResumeLayout(false);
			this.TabPage最寄りの素数.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Timer MainTimer;
		private System.Windows.Forms.ToolTip MainToolTip;
		private System.Windows.Forms.TabPage TabPage個数;
		private System.Windows.Forms.Button Btn個数;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label L個数_最大値;
		private System.Windows.Forms.Label L個数_最小値;
		private System.Windows.Forms.TextBox T個数_最大値;
		private System.Windows.Forms.TextBox T個数_最小値;
		private System.Windows.Forms.TabPage TabPage素因数分解;
		private System.Windows.Forms.TextBox T素因数分解_結果;
		private System.Windows.Forms.TextBox T素因数分解_入力;
		private System.Windows.Forms.Button Btn素因数分解;
		private System.Windows.Forms.TabPage TabPage判定;
		private System.Windows.Forms.TextBox T判定_結果;
		private System.Windows.Forms.TextBox T判定_入力;
		private System.Windows.Forms.Button Btn判定;
		private System.Windows.Forms.TabPage TabPage出力;
		private System.Windows.Forms.Button Btn出力;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label L出力_最大値;
		private System.Windows.Forms.Label L出力_最小値;
		private System.Windows.Forms.TextBox T出力_最大値;
		private System.Windows.Forms.TextBox T出力_最小値;
		private System.Windows.Forms.TabControl MainTab;
		private System.Windows.Forms.TabPage TabPage最寄りの素数;
		private System.Windows.Forms.Button Btn探索;
		private System.Windows.Forms.TextBox T探索_結果;
		private System.Windows.Forms.TextBox T探索_入力;
	}
}

