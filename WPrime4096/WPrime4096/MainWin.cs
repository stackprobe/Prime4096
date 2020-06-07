using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Charlotte.Tools;
using Charlotte.Chocomint.Dialogs;
using System.IO;
using System.Security.Permissions;

namespace Charlotte
{
	public partial class MainWin : Form
	{
		#region ALT_F4 抑止

		private bool XPressed = false;

		[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
		protected override void WndProc(ref Message m)
		{
			const int WM_SYSCOMMAND = 0x112;
			const long SC_CLOSE = 0xF060L;

			if (m.Msg == WM_SYSCOMMAND && (m.WParam.ToInt64() & 0xFFF0L) == SC_CLOSE)
			{
				this.XPressed = true;
				return;
			}
			base.WndProc(ref m);
		}

		#endregion

		public MainWin()
		{
			InitializeComponent();

			this.MinimumSize = this.Size;
		}

		private void MainWin_Load(object sender, EventArgs e)
		{
			// noop
		}

		private int Base_MainWin_H;
		private int Base_T1_H;
		private int Base_L2_T;
		private int Base_T2_T;
		private int Base_T2_H;

		private int Base2_T1_H;
		private int Base2_B1_T;
		private int Base2_T2_T;
		private int Base2_T2_H;

		private void MainWin_Shown(object sender, EventArgs e)
		{
			// -- 0001

			// TODO WriteLog = write to .log file

			ExtraTools.AntiWindowsDefenderSmartScreen();

			Prime4096.INIT();
			Prime53Lite.INIT();

			Prime53Lite.GeneratePrimeDat();

			this.Base_MainWin_H = this.Height;
			this.Base_T1_H = this.T出力_最小値.Height;
			this.Base_L2_T = this.L出力_最大値.Top;
			this.Base_T2_T = this.T出力_最大値.Top;
			this.Base_T2_H = this.T出力_最大値.Height;

			this.Base2_T1_H = this.T判定_入力.Height;
			this.Base2_B1_T = this.Btn判定.Top;
			this.Base2_T2_T = this.T判定_結果.Top;
			this.Base2_T2_H = this.T判定_結果.Height;

			// --

			this.T出力_最小値.Text = "" + 2;
			this.T出力_最大値.Text = "" + 10000000000;

			this.T判定_入力.Text = Consts.S2P1279_1;
			this.T判定_結果.Text = "";

			this.T探索_入力.Text = ("" + 1) + StringTools.Repeat("0", 400);
			this.T探索_結果.Text = "";

			this.T素因数分解_入力.Text = Consts.SMP1000;
			this.T素因数分解_結果.Text = "";

			this.T個数_最小値.Text = "" + 2;
			this.T個数_最大値.Text = "" + 10000000000;

			// --

			this.T出力_最小値.SelectAll();
			this.T出力_最大値.SelectAll();

			this.T判定_入力.SelectAll();

			this.T探索_入力.SelectAll();

			this.T素因数分解_入力.SelectAll();

			this.T個数_最小値.SelectAll();
			this.T個数_最大値.SelectAll();

			// --

			this.MainToolTip.SetToolTip(this.T出力_最小値, Utils.AutoInsertNewLine("0 以上 " + Consts.S2P4096_1 + " 以下の整数を入力して下さい。", Consts.MaxLineLen_ToolTip));
			this.MainToolTip.SetToolTip(this.T出力_最大値, Utils.AutoInsertNewLine("0 以上 " + Consts.S2P4096_1 + " 以下の整数を入力して下さい。", Consts.MaxLineLen_ToolTip));

			this.MainToolTip.SetToolTip(this.T判定_入力, Utils.AutoInsertNewLine("0 以上 " + Consts.S2P4096_1 + " 以下の整数を入力して下さい。", Consts.MaxLineLen_ToolTip));

			this.MainToolTip.SetToolTip(this.T探索_入力, Utils.AutoInsertNewLine("0 以上 " + Consts.S2P4096_1 + " 以下の整数を入力して下さい。", Consts.MaxLineLen_ToolTip));

			this.MainToolTip.SetToolTip(this.T素因数分解_入力, Utils.AutoInsertNewLine("1 以上 " + Consts.S2P4096_1 + " 以下の整数を入力して下さい。", Consts.MaxLineLen_ToolTip));

			this.MainToolTip.SetToolTip(this.T個数_最小値, Utils.AutoInsertNewLine("0 以上 " + Consts.S2P4096_1 + " 以下の整数を入力して下さい。", Consts.MaxLineLen_ToolTip));
			this.MainToolTip.SetToolTip(this.T個数_最大値, Utils.AutoInsertNewLine("0 以上 " + Consts.S2P4096_1 + " 以下の整数を入力して下さい。", Consts.MaxLineLen_ToolTip));

			// ----

			this.RefreshUI();

			ChocomintDialogsCommon.PostShown(this);

			// ----

			this.MTBusy.Leave();
		}

		private void MainWin_FormClosing(object sender, FormClosingEventArgs e)
		{
			// noop
		}

		private void MainWin_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.MTBusy.Enter(); // 2bs

			// ----

			// -- 9999
		}

		private void CloseWindow()
		{
			using (this.MTBusy.Section())
			{
				try
				{
					// -- 9000

					BusyDlgTools.Show("Prime4096", "アプリケーションを終了しています...", () =>
					{
						Prime53Lite.RemovePrimeDat();
					},
					true
					);

					Ground.Destroy();

					// ----
				}
				catch (Exception e)
				{
					MessageBox.Show("" + e, "Error @ CloseWindow()", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				this.MTBusy.Enter();
				this.Close();
			}
		}

		private VisitorCounter MTBusy = new VisitorCounter(1);
		private long MTCount;

		private void MainTimer_Tick(object sender, EventArgs e)
		{
			if (this.MTBusy.HasVisitor())
				return;

			this.MTBusy.Enter();
			try
			{
				// -- 3001

				if (this.XPressed)
				{
					this.XPressed = false;
					this.CloseWindow();
					return;
				}
				if (this.MTCount % 600 == 0) // per minute
				{
					GC.Collect();
				}
			}
			catch (Exception ex)
			{
				ProcMain.WriteLog(ex);
			}
			finally
			{
				this.MTBusy.Leave();
				this.MTCount++;
			}
		}

		private void MainWin_Resize(object sender, EventArgs e)
		{
			// noop
		}

		private void MainWin_ResizeBegin(object sender, EventArgs e)
		{
			//this.SetControlVisible(false); // old -- ちらつきが無い様なので廃止
		}

		private void MainWin_ResizeEnd(object sender, EventArgs e)
		{
			//this.RefreshUI(); // old -- moved -> _SizeChanged
			//this.SetControlVisible(true); // old
		}

		private void MainWin_SizeChanged(object sender, EventArgs e)
		{
			if (
				this.WindowState == FormWindowState.Maximized ||
				this.WindowState == FormWindowState.Normal
				)
				this.RefreshUI();
		}

		private void RefreshUI()
		{
			try
			{
				int d = this.Height - this.Base_MainWin_H;
				int d2 = d / 2;
				int d3 = d / 3;

				this.T出力_最小値.Height = this.Base_T1_H + d2;
				this.L出力_最大値.Top = this.Base_L2_T + d2;
				this.T出力_最大値.Top = this.Base_T2_T + d2;
				this.T出力_最大値.Height = this.Base_T2_H + d2;

				this.T判定_入力.Height = this.Base2_T1_H + d3;
				this.Btn判定.Top = this.Base2_B1_T + d3;
				this.T判定_結果.Top = this.Base2_T2_T + d3;
				this.T判定_結果.Height = this.Base2_T2_H + (d - d3);

				this.T探索_入力.Height = this.Base2_T1_H + d3;
				this.Btn探索.Top = this.Base2_B1_T + d3;
				this.T探索_結果.Top = this.Base2_T2_T + d3;
				this.T探索_結果.Height = this.Base2_T2_H + (d - d3);

				this.T素因数分解_入力.Height = this.Base2_T1_H + d3;
				this.Btn素因数分解.Top = this.Base2_B1_T + d3;
				this.T素因数分解_結果.Top = this.Base2_T2_T + d3;
				this.T素因数分解_結果.Height = this.Base2_T2_H + (d - d3);

				this.T個数_最小値.Height = this.Base_T1_H + d2;
				this.L個数_最大値.Top = this.Base_L2_T + d2;
				this.T個数_最大値.Top = this.Base_T2_T + d2;
				this.T個数_最大値.Height = this.Base_T2_H + d2;
			}
			catch
			{ }
		}

		private void SetControlVisible(bool flag)
		{
			this.L出力_最小値.Visible = flag;
			this.T出力_最小値.Visible = flag;
			this.L出力_最大値.Visible = flag;
			this.T出力_最大値.Visible = flag;

			this.T判定_入力.Visible = flag;
			this.Btn判定.Visible = flag;
			this.T判定_結果.Visible = flag;

			this.T探索_入力.Visible = flag;
			this.Btn探索.Visible = flag;
			this.T探索_結果.Visible = flag;

			this.T素因数分解_入力.Visible = flag;
			this.Btn素因数分解.Visible = flag;
			this.T素因数分解_結果.Visible = flag;

			this.L個数_最小値.Visible = flag;
			this.T個数_最小値.Visible = flag;
			this.L個数_最大値.Visible = flag;
			this.T個数_最大値.Visible = flag;
		}

		private void T判定_結果_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 1) // ctrl_a
			{
				this.T判定_結果.SelectAll();
				e.Handled = true;
			}
		}

		private void T探索_結果_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 1) // ctrl_a
			{
				this.T探索_結果.SelectAll();
				e.Handled = true;
			}
		}

		private void T素因数分解_結果_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 1) // ctrl_a
			{
				this.T素因数分解_結果.SelectAll();
				e.Handled = true;
			}
		}

		private void Btn出力_Click(object sender, EventArgs e)
		{
			InputFileDlg.FAT32 = true;

			using (this.MTBusy.Section())
			{
				try
				{
					string minval = this.T出力_最小値.Text;
					string maxval = this.T出力_最大値.Text;

					if (minval == "")
						throw new Exception("最小値 が 未入力です。");

					if (maxval == "")
						throw new Exception("最大値 が 未入力です。");

					if (StringTools.LiteValidate(minval, StringTools.DECIMAL) == false)
						throw new Exception("最小値 に [0-9] 以外の文字が含まれています。");

					if (StringTools.LiteValidate(minval, StringTools.DECIMAL) == false)
						throw new Exception("最大値 に [0-9] 以外の文字が含まれています。");

					if (Ground.TCalc_Int.Calc(Consts.S2P4096_1, "-", minval)[0] == '-')
						throw new LongMessageException(Utils.AutoInsertNewLine("最小値 には 0 以上 " + Consts.S2P4096_1 + " 以下の整数を入力して下さい。", Consts.MaxLineLen_LongMessageDlg));

					if (Ground.TCalc_Int.Calc(Consts.S2P4096_1, "-", maxval)[0] == '-')
						throw new LongMessageException(Utils.AutoInsertNewLine("最大値 には 0 以上 " + Consts.S2P4096_1 + " 以下の整数を入力して下さい。", Consts.MaxLineLen_LongMessageDlg));

					if (Ground.TCalc_Int.Calc(maxval, "-", minval)[0] == '-')
						throw new Exception("最大値 < 最小値 になっています。");

					string outFile = "Prime_" + minval + "-" + maxval + ".txt";

					if (Consts.OutputLocalFileLenMax < outFile.Length)
						//outFile = "Prime.txt";
						outFile = "Prime_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";

					//outFile = Path.Combine(ProcMain.SelfDir, outFile);
					outFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), outFile);

					outFile = InputFileDlgTools.Save(
						"Prime4096",
						"出力ファイルを選択して下さい。",
						true,
						outFile,
						null,
						"txt"
						);

					if (outFile == null)
						throw new Returning();

					bool[] cancelledBox = new bool[1];

					this.Visible = false;
					this.CommonInterlude_INIT(currValue => string.Format("{0} あたりの素数を出力しています...", currValue));

					WaitDlgTools.Show(
						"Prime4096",
						"出力しています...",
						() => Prime4096.FindPrimes(minval, maxval, outFile, () => cancelledBox[0] == false),
						this.CommonInterlude,
						() => cancelledBox[0] = true
						);

					if (WaitDlg.LastCancelled)
					{
						// memo: Prime4096.exe, Prime53.exe は ABORTED 行を出力する。

						MessageDlgTools.Show(MessageDlg.Mode_e.Warning, "Prime4096", "中止しました。\r\n出力ファイルの内容は正しくない可能性があります。");
					}
					else
						MessageDlgTools.Information("Prime4096", "完了しました。");
				}
				catch (Exception ex)
				{
					this.CommonCought(ex);
				}
			}
			InputFileDlg.FAT32 = false; // 復元
			this.Visible = true; // 復元
		}

		private void Btn判定_Click(object sender, EventArgs e)
		{
			string text = "";

			using (this.MTBusy.Section())
			{
				try
				{
					string value = this.T判定_入力.Text;

					if (value == "")
						throw new Exception("未入力です。");

					if (StringTools.LiteValidate(value, StringTools.DECIMAL) == false)
						throw new Exception("[0-9] 以外の文字が含まれています。");

					if (Ground.TCalc_Int.Calc(Consts.S2P4096_1, "-", value)[0] == '-')
						throw new LongMessageException(Utils.AutoInsertNewLine("0 以上 " + Consts.S2P4096_1 + " 以下の整数を入力して下さい。", Consts.MaxLineLen_LongMessageDlg));

					this.Visible = false;

					BusyDlgTools.Show("Prime4096", "素数かどうか判定しています...", () =>
					{
						text = value + "\r\n----> " + (Prime4096.IsPrime(value) ? "素数です。" : "素数ではありません。");
					}
					);
				}
				catch (Exception ex)
				{
					this.CommonCought(ex);
				}
			}
			this.Visible = true; // 復元

			this.T判定_結果.Text = text;
			this.T判定_結果.SelectionStart = this.T判定_結果.TextLength;
			this.T判定_結果.ScrollToCaret();
		}

		private void Btn探索_Click(object sender, EventArgs e)
		{
			string text = "";

			using (this.MTBusy.Section())
			{
				try
				{
					string value = this.T探索_入力.Text;

					if (value == "")
						throw new Exception("未入力です。");

					if (StringTools.LiteValidate(value, StringTools.DECIMAL) == false)
						throw new Exception("[0-9] 以外の文字が含まれています。");

					if (Ground.TCalc_Int.Calc(Consts.S2P4096_1, "-", value)[0] == '-')
						throw new LongMessageException(Utils.AutoInsertNewLine("0 以上 " + Consts.S2P4096_1 + " 以下の整数を入力して下さい。", Consts.MaxLineLen_LongMessageDlg));

					bool[] cancelledBox = new bool[1];

					this.Visible = false;
					this.CommonInterlude_INIT();

					WaitDlgTools.Show(
						"Prime4096",
						"最寄りの素数を探しています...",
						() =>
						{
							//WaitDlg.MessagePost.Post("最寄りの素数を探しています... (小さい方)");
							this.WD_ProgressRate = 0.333;
							string lowerPrime = Prime4096.GetLowerPrime(value, () => cancelledBox[0] == false);
							//WaitDlg.MessagePost.Post("最寄りの素数を探しています... (大きい方)");
							this.WD_ProgressRate = 0.666;
							string higherPrime = Prime4096.GetHigherPrime(value, () => cancelledBox[0] == false);

							if (lowerPrime == "0")
								lowerPrime = "none";

							text = string.Join("\r\n",
								"元の数より小さい最大の素数 ---->",
								lowerPrime,
								"",
								"元の数より大きい最小の素数 ---->",
								higherPrime,
								"",
								"元の数 ---->",
								value
								);
						},
						this.CommonInterlude,
						() => cancelledBox[0] = true
						);

					if (WaitDlg.LastCancelled)
						text = "中止しました。";
				}
				catch (Exception ex)
				{
					this.CommonCought(ex);
				}
			}
			this.Visible = true; // 復元

			this.T探索_結果.Text = text;
			//this.T探索_結果.SelectionStart = this.T探索_結果.TextLength;
			//this.T探索_結果.ScrollToCaret();
		}

		private void Btn素因数分解_Click(object sender, EventArgs e)
		{
			string text = "";

			using (this.MTBusy.Section())
			{
				try
				{
					string value = this.T素因数分解_入力.Text;

					if (value == "")
						throw new Exception("未入力です。");

					if (StringTools.LiteValidate(value, StringTools.DECIMAL) == false)
						throw new Exception("[0-9] 以外の文字が含まれています。");

					if (
						Ground.TCalc_Int.Calc(value, "-", "1")[0] == '-' ||
						Ground.TCalc_Int.Calc(Consts.S2P4096_1, "-", value)[0] == '-'
						)
						throw new LongMessageException(Utils.AutoInsertNewLine("1 以上 " + Consts.S2P4096_1 + " 以下の整数を入力して下さい。", Consts.MaxLineLen_LongMessageDlg));

					bool[] cancelledBox = new bool[1];

					this.Visible = false;
					this.CommonInterlude_INIT(currValue => string.Format("素因数分解しています... {0}", currValue));

					WaitDlgTools.Show(
						"Prime4096",
						"素因数分解しています...",
						() => text = string.Join("\r\n", Prime4096.Factorization(value, () => cancelledBox[0] == false)),
						this.CommonInterlude,
						() => cancelledBox[0] = true
						);

					if (WaitDlg.LastCancelled)
					{
						//text += "\r\n中止しました。この出力結果は正しくない可能性があります。"; // old

						text =
							"中止しました。\r\n" +
							"この出力結果は正しくない可能性があります。\r\n" +
							text;
					}
				}
				catch (Exception ex)
				{
					this.CommonCought(ex);
				}
			}
			this.Visible = true; // 復元

			this.T素因数分解_結果.Text = text;
			//this.T素因数分解_結果.SelectionStart = this.T素因数分解_結果.TextLength;
			//this.T素因数分解_結果.ScrollToCaret();
		}

		private void Btn個数_Click(object sender, EventArgs e)
		{
			using (this.MTBusy.Section())
			{
				try
				{
					string minval = this.T個数_最小値.Text;
					string maxval = this.T個数_最大値.Text;

					if (minval == "")
						throw new Exception("最小値 が 未入力です。");

					if (maxval == "")
						throw new Exception("最大値 が 未入力です。");

					if (StringTools.LiteValidate(minval, StringTools.DECIMAL) == false)
						throw new Exception("最小値 に [0-9] 以外の文字が含まれています。");

					if (StringTools.LiteValidate(minval, StringTools.DECIMAL) == false)
						throw new Exception("最大値 に [0-9] 以外の文字が含まれています。");

					if (Ground.TCalc_Int.Calc(Consts.S2P4096_1, "-", minval)[0] == '-')
						throw new LongMessageException(Utils.AutoInsertNewLine("最小値 には 0 以上 " + Consts.S2P4096_1 + " 以下の整数を入力して下さい。", Consts.MaxLineLen_LongMessageDlg));

					if (Ground.TCalc_Int.Calc(Consts.S2P4096_1, "-", maxval)[0] == '-')
						throw new LongMessageException(Utils.AutoInsertNewLine("最大値 には 0 以上 " + Consts.S2P4096_1 + " 以下の整数を入力して下さい。", Consts.MaxLineLen_LongMessageDlg));

					if (Ground.TCalc_Int.Calc(maxval, "-", minval)[0] == '-')
						throw new Exception("最大値 < 最小値 になっています。");

					string outFile = "PrimeCount_" + minval + "-" + maxval + ".txt";

					if (Consts.OutputLocalFileLenMax < outFile.Length)
						//outFile = "PrimeCount.txt";
						outFile = "PrimeCount_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";

					//outFile = Path.Combine(ProcMain.SelfDir, outFile);
					outFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), outFile);

					outFile = InputFileDlgTools.Save(
						"Prime4096",
						"出力ファイルを選択して下さい。",
						true,
						outFile,
						null,
						"txt"
						);

					if (outFile == null)
						throw new Returning();

					bool[] cancelledBox = new bool[1];

					this.Visible = false;
					this.CommonInterlude_INIT(currValue => string.Format("{0} あたりの素数を数えています...", currValue));

					WaitDlgTools.Show(
						"Prime4096",
						"数えています...",
						() => Prime4096.WritePrimeCount(minval, maxval, outFile, () => cancelledBox[0] == false),
						this.CommonInterlude,
						() => cancelledBox[0] = true
						);

					if (WaitDlg.LastCancelled)
					{
						// memo: Prime4096.exe, Prime53.exe は ABORTED 行等を出力しない。

						File.WriteAllText(
							outFile,
							File.ReadAllText(outFile, Encoding.ASCII).Trim() + "\n中止しました。この出力結果は正しくない可能性があります。",
							StringTools.ENCODING_SJIS
							);

						MessageDlgTools.Show(MessageDlg.Mode_e.Warning, "Prime4096", "中止しました。\r\n出力ファイルの内容は正しくない可能性があります。");
					}
					else
						MessageDlgTools.Information("Prime4096", "完了しました。");
				}
				catch (Exception ex)
				{
					this.CommonCought(ex);
				}
			}
			this.Visible = true; // 復元
		}

		private void CommonCought(Exception e)
		{
			Exception te = Utils.GetTrueException(e);

			if (te is Returning)
				return;

			if (te is CUIError)
			{
				MessageDlgTools.Error("Prime4096 エラー", e, this.Visible);
			}
			else if (te is LongMessageException)
			{
				LongMessageDlgTools.Warning("Prime4096", e.Message, Consts.LongMessageDlg_Size, this.Visible);
			}
			else
			{
				MessageDlgTools.Warning("Prime4096", e, this.Visible);
			}
		}

		private double WD_ProgressRate;
		private Func<string, string> WD_GetMessage;

		private void CommonInterlude_INIT(Func<string, string> getMessage = null)
		{
			this.WD_ProgressRate = 0.0;
			this.WD_GetMessage = getMessage;
		}

		private double CommonInterlude()
		{
			Report report = Ground.ReportMgr.GetReport();

			if (report != null)
			{
				this.WD_ProgressRate = report.ProgressRate;

				if (this.WD_GetMessage != null)
				{
					WaitDlg.MessagePost.Post(this.WD_GetMessage(report.CurrentValue));
				}
			}
			return this.WD_ProgressRate;
		}

		private void T出力_最小値_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)13) // enter
			{
				this.T出力_最大値.Focus();
				e.Handled = true;
			}
		}

		private void T出力_最大値_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)13) // enter
			{
				this.Btn出力.Focus();
				e.Handled = true;
			}
		}

		private void T判定_入力_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)13) // enter
			{
				this.Btn判定.Focus();
				e.Handled = true;
			}
		}

		private void T探索_入力_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)13) // enter
			{
				this.Btn探索.Focus();
				e.Handled = true;
			}
		}

		private void T素因数分解_入力_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)13) // enter
			{
				this.Btn素因数分解.Focus();
				e.Handled = true;
			}
		}

		private void T個数_最小値_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)13) // enter
			{
				this.T個数_最大値.Focus();
				e.Handled = true;
			}
		}

		private void T個数_最大値_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)13) // enter
			{
				this.Btn個数.Focus();
				e.Handled = true;
			}
		}

		private void T出力_最小値_TextChanged(object sender, EventArgs e)
		{
			this.CommonInputValueChanged(this.T出力_最小値);
		}

		private void T出力_最大値_TextChanged(object sender, EventArgs e)
		{
			this.CommonInputValueChanged(this.T出力_最大値);
		}

		private void T判定_入力_TextChanged(object sender, EventArgs e)
		{
			this.CommonInputValueChanged(this.T判定_入力);
		}

		private void T探索_入力_TextChanged(object sender, EventArgs e)
		{
			this.CommonInputValueChanged(this.T探索_入力);
		}

		private void T素因数分解_入力_TextChanged(object sender, EventArgs e)
		{
			this.CommonInputValueChanged(this.T素因数分解_入力);
		}

		private void T個数_最小値_TextChanged(object sender, EventArgs e)
		{
			this.CommonInputValueChanged(this.T個数_最小値);
		}

		private void T個数_最大値_TextChanged(object sender, EventArgs e)
		{
			this.CommonInputValueChanged(this.T個数_最大値);
		}

		private void CommonInputValueChanged(TextBox tb)
		{
			string text = new string(tb.Text.Where(chr => StringTools.DECIMAL.Contains(chr)).ToArray());

			if (tb.Text != text)
			{
				tb.Text = text;
				tb.SelectionStart = tb.TextLength;
			}
		}
	}
}
