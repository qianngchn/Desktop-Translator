using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Runtime.InteropServices;

namespace DTProc
{
    public partial class DTProc : Form
    {
        [DllImport("user32.dll")]
        private extern static bool AddClipboardFormatListener(IntPtr hwnd);
        [DllImport("user32.dll")]
        private extern static bool RemoveClipboardFormatListener(IntPtr hwnd);
        private const int WM_CLIPBOARDUPDATE = 0x031D;

        public DTProc()
        {
            InitializeComponent();
            AddClipboardFormatListener(Handle);
        }

        private string translate = "auto";
        private string appid = String.Empty;
        private string password = String.Empty;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_CLIPBOARDUPDATE)
            {
                if (Clipboard.ContainsText())
                {
                    if (String.IsNullOrEmpty(appid) || String.IsNullOrEmpty(password))
                    {
                        try
                        {
                            XElement root = XElement.Load("Config.xml");
                            XElement node = (from target in root.Descendants("Translator") where target.Attribute("name").Value.Equals("baidu") select target).First();
                            appid = node.Attribute("appid").Value;
                            password = node.Attribute("password").Value;
                        }
                        catch
                        {
                            Label.Text = "Read Config.xml Error, Please ensure the file exists in the root directory!";
                            return;
                        }
                    }

                    switch (translate)
                    {
                        case "auto":
                            Label.Text = Translate.BaiduTranslate(Clipboard.GetText(), Translate.Language.auto, Translate.Language.zh, appid, password);
                            break;

                        case "en":
                            Label.Text = Translate.BaiduTranslate(Clipboard.GetText(), Translate.Language.en, Translate.Language.zh, appid, password);
                            break;

                        case "jp":
                            Label.Text = Translate.BaiduTranslate(Clipboard.GetText(), Translate.Language.jp, Translate.Language.zh, appid, password);
                            break;

                        default:
                            Label.Text = Clipboard.GetText();
                            break;
                    }
                    m.Result = new IntPtr(0);
                }
            }
            else
            {
                base.WndProc(ref m);
            }
        }

        private void RightClickMenu_Exit_Click(object sender, EventArgs e)
        {
            RemoveClipboardFormatListener(Handle);
            Application.Exit();
        }

        private bool isMouseDown = false;
        private Point formLocation;
        private Point formOffset;

        private void PictureMenu_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;
                formLocation = Location;
                formOffset = MousePosition;

                Label.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void PictureMenu_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;

            Label.BorderStyle = BorderStyle.None;
        }

        private void PictureMenu_MouseMove(object sender, MouseEventArgs e)
        {
            int px = 0;
            int py = 0;
            if (isMouseDown)
            {
                Point pt = MousePosition;
                px = formOffset.X - pt.X;
                py = formOffset.Y - pt.Y;
                Location = new Point(formLocation.X - px, formLocation.Y - py);
                Refresh();
            }
        }

        [DllImport("dwmapi.dll")]
        private extern static void DwmIsCompositionEnabled(ref int enabledptr);
        [DllImport("dwmapi.dll")]
        private extern static int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarinset);
        public struct MARGINS
        {
            public int Left { get; set; }
            public int Right { get; set; }
            public int Top { get; set; }
            public int Bottom { get; set; }
        }
        private bool isBackgroundSet = false;

        private void RightClickMenu_BGSet_Click(object sender, EventArgs e)
        {
            int flag = 0;
            if (!isBackgroundSet)
            {
                isBackgroundSet = true;
                RightClickMenu_BGSet.Checked = true;

                if (Environment.OSVersion.Version.Major >= 6)
                {
                    DwmIsCompositionEnabled(ref flag);
                    if (flag > 0)
                    {
                        MARGINS margins = new MARGINS() { Left = 0, Right = Label.Width, Top = 0, Bottom = 0 };
                        DwmExtendFrameIntoClientArea(Handle, ref margins);
                    }
                    else
                    {
                        TransparencyKey = BackColor;
                    }
                }
                else
                {
                    MessageBox.Show("Windows 7 and above is required!");
                }
            }
            else
            {
                isBackgroundSet = false;
                RightClickMenu_BGSet.Checked = false;

                if (Environment.OSVersion.Version.Major >= 6)
                {
                    DwmIsCompositionEnabled(ref flag);
                    if (flag > 0)
                    {
                        MARGINS margins = new MARGINS() { Left = 0, Right = 0, Top = 0, Bottom = 0 };
                        DwmExtendFrameIntoClientArea(Handle, ref margins);
                    }
                    else
                    {
                        TransparencyKey = DefaultBackColor;
                    }
                }
                else
                {
                    MessageBox.Show("Windows 7 and above is required!");
                }
            }
        }

        private void RightClickMenu_TextSize_Small_Click(object sender, EventArgs e)
        {
            RightClickMenu_TextSize_Small.Checked = false;
            RightClickMenu_TextSize_Medium.Checked = false;
            RightClickMenu_TextSize_Big.Checked = false;
            Label.Font = new Font(Label.Font.FontFamily, 12);
            RightClickMenu_TextSize_Small.Checked = true;
        }

        private void RightClickMenu_TextSize_Medium_Click(object sender, EventArgs e)
        {
            RightClickMenu_TextSize_Small.Checked = false;
            RightClickMenu_TextSize_Medium.Checked = false;
            RightClickMenu_TextSize_Big.Checked = false;
            Label.Font = new Font(Label.Font.FontFamily, 18);
            RightClickMenu_TextSize_Medium.Checked = true;
        }

        private void RightClickMenu_TextSize_Big_Click(object sender, EventArgs e)
        {
            RightClickMenu_TextSize_Small.Checked = false;
            RightClickMenu_TextSize_Medium.Checked = false;
            RightClickMenu_TextSize_Big.Checked = false;
            Label.Font = new Font(Label.Font.FontFamily, 36);
            RightClickMenu_TextSize_Big.Checked = true;
        }

        private const int minHeight = 64;
        private const int maxHeight = 8 * minHeight;
        private int lastHeight = minHeight;
        private void CheckResetLocation()
        {
            if (Location.X < 0)
                Location = new Point(0, Location.Y);
            if (Location.X > Screen.PrimaryScreen.Bounds.Width - Width)
                Location = new Point(Screen.PrimaryScreen.Bounds.Width - Width, Location.Y);
            if (Location.Y < 0)
                Location = new Point(Location.X, 0);
            if (Location.Y > Screen.PrimaryScreen.Bounds.Height - Height)
                Location = new Point(Location.X, Screen.PrimaryScreen.Bounds.Height - Height);
            Refresh();
        }

        private void RightClickMenu_Extend_Click(object sender, EventArgs e)
        {
            if (ClientSize.Height < maxHeight)
            {
                lastHeight = ClientSize.Height;
                ClientSize = new Size(ClientSize.Width, 2 * ClientSize.Height);
                PictureMenu.Size = new Size(PictureMenu.Width, 2 * PictureMenu.Height);
                Label.Size = new Size(Label.Width, 2 * Label.Height);
            }
            else
                Label.Text = "文本区域已经到达最大";
            CheckResetLocation();
        }

        private void RightClickMenu_Reduce_Click(object sender, EventArgs e)
        {
            if (ClientSize.Height > minHeight)
            {
                lastHeight = ClientSize.Height;
                ClientSize = new Size(ClientSize.Width, ClientSize.Height / 2);
                PictureMenu.Size = new Size(PictureMenu.Width, PictureMenu.Height / 2);
                Label.Size = new Size(Label.Width, Label.Height / 2);
            }
            else
                Label.Text = "文本区域已经到达最小";
            CheckResetLocation();
        }

        private void Label_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (ClientSize.Height < maxHeight)
                {
                    lastHeight = ClientSize.Height;
                    ClientSize = new Size(ClientSize.Width, maxHeight);
                    PictureMenu.Size = new Size(PictureMenu.Width, maxHeight);
                    Label.Size = new Size(Label.Width, maxHeight);
                }
                else
                {
                    ClientSize = new Size(ClientSize.Width, lastHeight);
                    PictureMenu.Size = new Size(PictureMenu.Width, lastHeight);
                    Label.Size = new Size(Label.Width, lastHeight);
                }
                CheckResetLocation();
            }
        }

        private void Label_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Label.BackColor);
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            GraphicsPath path = new GraphicsPath();
            StringFormat format = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            Pen pen = new Pen(Color.Blue);
            Brush brush = new SolidBrush(Color.White);
            path.AddString(Label.Text, Label.Font.FontFamily, (int)Label.Font.Style, e.Graphics.DpiX * Label.Font.SizeInPoints / 75, e.ClipRectangle, format);
            e.Graphics.DrawPath(pen, path);
            e.Graphics.FillPath(brush, path);
            format.Dispose();
            path.Dispose();
            pen.Dispose();
            brush.Dispose();
        }

        private void RightClickMenu_Translate_Auto_Click(object sender, EventArgs e)
        {
            RightClickMenu_Translate_Auto.Checked = false;
            RightClickMenu_Translate_EnglishToChinese.Checked = false;
            RightClickMenu_Translate_JapaneseToChinese.Checked = false;
            RightClickMenu_Translate_NoTranslate.Checked = false;
            translate = "auto";
            RightClickMenu_Translate_Auto.Checked = true;
        }

        private void RightClickMenu_Translate_EnglishToChinese_Click(object sender, EventArgs e)
        {
            RightClickMenu_Translate_Auto.Checked = false;
            RightClickMenu_Translate_EnglishToChinese.Checked = false;
            RightClickMenu_Translate_JapaneseToChinese.Checked = false;
            RightClickMenu_Translate_NoTranslate.Checked = false;
            translate = "en";
            RightClickMenu_Translate_EnglishToChinese.Checked = true;
        }

        private void RightClickMenu_Translate_JapaneseToChinese_Click(object sender, EventArgs e)
        {
            RightClickMenu_Translate_Auto.Checked = false;
            RightClickMenu_Translate_EnglishToChinese.Checked = false;
            RightClickMenu_Translate_JapaneseToChinese.Checked = false;
            RightClickMenu_Translate_NoTranslate.Checked = false;
            translate = "jp";
            RightClickMenu_Translate_JapaneseToChinese.Checked = true;
        }

        private void RightClickMenu_Translate_NoTranslate_Click(object sender, EventArgs e)
        {
            RightClickMenu_Translate_Auto.Checked = false;
            RightClickMenu_Translate_EnglishToChinese.Checked = false;
            RightClickMenu_Translate_JapaneseToChinese.Checked = false;
            RightClickMenu_Translate_NoTranslate.Checked = false;
            translate = String.Empty;
            RightClickMenu_Translate_NoTranslate.Checked = true;
        }
    }
}
