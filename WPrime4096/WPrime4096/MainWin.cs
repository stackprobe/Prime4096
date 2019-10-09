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

namespace Charlotte
{
	public partial class MainWin : Form
	{
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

			Prime4096.INIT();

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
			this.MTBusy.Enter();

			// ----

			// -- 9999
		}

		private void CloseWindow()
		{
			using (this.MTBusy.Section())
			{
				// -- 9000

				// ----

				this.MTBusy.Enter(); // 終了確定

				// ----

				// -- 9900

				// ----

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
			this.SetControlVisible(false);
		}

		private void MainWin_ResizeEnd(object sender, EventArgs e)
		{
			this.RefreshUI();
			this.SetControlVisible(true);
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
			this.Visible = false;

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

					if (100 < outFile.Length)
						outFile = "Prime.txt";

					//outFile = Path.Combine(ProcMain.SelfDir, outFile);
					outFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), outFile);

					outFile = InputFileDlgTools.Save(
						"Prime4096",
						"出力ファイルを選択して下さい。",
						false,
						outFile
						);

					if (outFile == null)
						throw new Returning();

					bool[] cancelledBox = new bool[1];

					WaitDlgTools.Show(
						"Prime4096",
						"出力しています...",
						() => Prime4096.FindPrimes(minval, maxval, outFile, () => cancelledBox[0] == false),
						() => 0.5, // TODO
						() => cancelledBox[0] = true
						);
				}
				catch (Returning)
				{ }
				catch (LongMessageException ex)
				{
					LongMessageDlgTools.Warning("Prime4096", ex.Message, Consts.LongMessageDlg_Size);
				}
				catch (Exception ex)
				{
					MessageDlgTools.Warning("Prime4096", ex);
				}
			}
			this.Visible = true;
		}

		private void Btn判定_Click(object sender, EventArgs e)
		{
			string text = "";

			this.Visible = false;

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

					BusyDlgTools.Show("Prime4096", "素数かどうか判定しています...", () =>
					{
						text = value + "\r\n===> " + (Prime4096.IsPrime(value) ? "素数です。" : "素数ではありません。");
					}
					);
				}
				catch (LongMessageException ex)
				{
					LongMessageDlgTools.Warning("Prime4096", ex.Message, Consts.LongMessageDlg_Size);
				}
				catch (Exception ex)
				{
					MessageDlgTools.Warning("Prime4096", ex);
				}
			}
			this.Visible = true;

			this.T判定_結果.Text = text;
			this.T判定_結果.SelectionStart = this.T判定_結果.TextLength;
			this.T判定_結果.ScrollToCaret();
		}

		private void Btn探索_Click(object sender, EventArgs e)
		{
			using (this.MTBusy.Section())
			{
				MessageDlgTools.Show(MessageDlg.Mode_e.Warning, "エラー", "未実装", true);
			}
		}

		private void Btn素因数分解_Click(object sender, EventArgs e)
		{
			using (this.MTBusy.Section())
			{
				MessageDlgTools.Show(MessageDlg.Mode_e.Warning, "エラー", "未実装", true);
			}
		}

		private void Btn個数_Click(object sender, EventArgs e)
		{
			using (this.MTBusy.Section())
			{
				MessageDlgTools.Show(MessageDlg.Mode_e.Warning, "エラー", "未実装", true);
			}
		}
	}
}
