using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Printing;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

//credit to author Mark Pitman
//reference: http://www.codeproject.com/KB/printing/printtreeview.aspx


namespace Pitman.Printing
{
    public class PrintHelper
    {
        private PrintDocument _printDoc;
        private Point _lastPrintPosition;
        private Image _controlImage = null;
        private int _nodeHeight = 0;
        private PrintDirection _currentDir;
        private int _scrollBarHeight = 0;
        private int _scrollBarWidth = 0;
        private int _pageNumber = 0;
        private DateTime _date;
        private string _title = string.Empty;

        private enum PrintDirection
        {
            Horizontal,
            Vertical
        }

        public PrintHelper()
        {
            _lastPrintPosition = new Point(0, 0);
            this._printDoc = new PrintDocument();
            this._printDoc.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDoc_BeginPrint);
            this._printDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDoc_PrintPage);
            this._printDoc.EndPrint += new PrintEventHandler(_printDoc_EndPrint);
        }

        void _printDoc_EndPrint(object sender, PrintEventArgs e)
        {
            _controlImage.Dispose();
        }

        /// <summary>
        /// Shows a PrintPreview dialog displaying the Tree control passed in.
        /// </summary>
        /// <param name="tree">TreeView to print preview</param>
        public void PrintPreviewTree(TreeView tree, string title)
        {
            this._title = title;
            PrepareTreeImage((TreeView)tree);
            PrintPreviewDialog pp = new PrintPreviewDialog();
            pp.Document = this._printDoc;
            pp.Show();
        }

        /// <summary>
        /// Prints a tree
        /// </summary>
        /// <param name="tree">TreeView to print</param>
        public void PrintTree(TreeView tree, string title)
        {
            this._title = title;
            PrepareTreeImage((TreeView)tree);
            PrintDialog pd = new PrintDialog();
            pd.Document = this._printDoc;
            if (pd.ShowDialog() == DialogResult.OK)
            {
                this._printDoc.Print();
            }

        }

        /// <summary>
        /// Gets an image that shows the entire tree, not just what is visible on the form
        /// </summary>
        /// <param name="tree"></param>
        private void PrepareTreeImage(TreeView tree)
        {
            _scrollBarWidth = tree.Width - tree.ClientSize.Width;
            _scrollBarHeight = tree.Height - tree.ClientSize.Height;
            tree.Nodes[0].EnsureVisible();
            int height = tree.Nodes[0].Bounds.Height;
            this._nodeHeight = height;
            int width = tree.Nodes[0].Bounds.Right;
            TreeNode node = tree.Nodes[0].NextVisibleNode;
            while (node != null)
            {
                height += node.Bounds.Height;
                if (node.Bounds.Right > width)
                {
                    width = node.Bounds.Right;
                }
                node = node.NextVisibleNode;
            }
            //keep track of the original tree settings
            int tempHeight = tree.Height;
            int tempWidth = tree.Width;
            BorderStyle tempBorder = tree.BorderStyle;
            bool tempScrollable = tree.Scrollable;
            TreeNode selectedNode = tree.SelectedNode;
            //setup the tree to take the snapshot
            tree.SelectedNode = null;
            DockStyle tempDock = tree.Dock;
            tree.Height = height + _scrollBarHeight;
            tree.Width = width + _scrollBarWidth;
            tree.BorderStyle = BorderStyle.None;
            tree.Dock = DockStyle.None;
            //get the image of the tree

            // .Net 2.0 supports drawing controls onto bitmaps natively now
            // However, the full tree didn't get drawn when I tried it, so I am
            // sticking with the P/Invoke calls
            //_controlImage = new Bitmap(height, width);
            //Bitmap bmp = _controlImage as Bitmap;
            //tree.DrawToBitmap(bmp, tree.Bounds);

            this._controlImage = GetImage(tree.Handle, tree.Width, tree.Height);

            //reset the tree to its original settings
            tree.BorderStyle = tempBorder;
            tree.Width = tempWidth;
            tree.Height = tempHeight;
            tree.Dock = tempDock;
            tree.Scrollable = tempScrollable;
            tree.SelectedNode = selectedNode;
            //give the window time to update
            Application.DoEvents();
        }

        // Returns an image of the specified width and height, of a control represented by handle.
        private Image GetImage(IntPtr handle, int width, int height)
        {
            IntPtr screenDC = GetDC(IntPtr.Zero);
            IntPtr hbm = CreateCompatibleBitmap(screenDC, width, height);
            Image image = Bitmap.FromHbitmap(hbm);
            Graphics g = Graphics.FromImage(image);
            IntPtr hdc = g.GetHdc();
            SendMessage(handle, 0x0318 /*WM_PRINTCLIENT*/, hdc, (0x00000010 | 0x00000004 | 0x00000002));
            g.ReleaseHdc(hdc);
            ReleaseDC(IntPtr.Zero, screenDC);
            return image;
        }

        private void printDoc_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            _lastPrintPosition = new Point(0, 0);
            this._currentDir = PrintDirection.Horizontal;
            this._pageNumber = 0;
            this._date = DateTime.Now;
        }

        private void printDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            this._pageNumber++;
            Graphics g = e.Graphics;
            Rectangle sourceRect = new Rectangle(_lastPrintPosition, e.MarginBounds.Size);
            Rectangle destRect = e.MarginBounds;

            if ((sourceRect.Height % this._nodeHeight) > 0)
            {
                sourceRect.Height -= (sourceRect.Height % this._nodeHeight);
            }
            g.DrawImage(this._controlImage, destRect, sourceRect, GraphicsUnit.Pixel);
            //check to see if we need more pages
            if ((this._controlImage.Height - this._scrollBarHeight) > sourceRect.Bottom || (this._controlImage.Width - this._scrollBarWidth) > sourceRect.Right)
            {
                //need more pages
                e.HasMorePages = true;
            }
            if (this._currentDir == PrintDirection.Horizontal)
            {
                if (sourceRect.Right < (this._controlImage.Width - this._scrollBarWidth))
                {
                    //still need to print horizontally
                    _lastPrintPosition.X += (sourceRect.Width + 1);
                }
                else
                {
                    _lastPrintPosition.X = 0;
                    _lastPrintPosition.Y += (sourceRect.Height + 1);
                    this._currentDir = PrintDirection.Vertical;
                }
            }
            else if (this._currentDir == PrintDirection.Vertical && sourceRect.Right < (this._controlImage.Width - this._scrollBarWidth))
            {
                this._currentDir = PrintDirection.Horizontal;
                _lastPrintPosition.X += (sourceRect.Width + 1);
            }
            else
            {
                _lastPrintPosition.Y += (sourceRect.Height + 1);
            }

            //print footer
            Brush brush = new SolidBrush(Color.Black);
            string footer = this._pageNumber.ToString(System.Globalization.NumberFormatInfo.CurrentInfo);
            Font f = new Font(FontFamily.GenericSansSerif, 10f);
            SizeF footerSize = g.MeasureString(footer, f);
            PointF pageBottomCenter = new PointF(e.PageBounds.Width / 2, e.MarginBounds.Bottom + ((e.PageBounds.Bottom - e.MarginBounds.Bottom) / 2));
            PointF footerLocation = new PointF(pageBottomCenter.X - (footerSize.Width / 2), pageBottomCenter.Y - (footerSize.Height / 2));
            g.DrawString(footer, f, brush, footerLocation);

            //print header
            if (this._pageNumber == 1 && this._title.Length > 0)
            {
                Font headerFont = new Font(FontFamily.GenericSansSerif, 24f, FontStyle.Bold, GraphicsUnit.Point);
                SizeF headerSize = g.MeasureString(this._title, headerFont);
                PointF headerLocation = new PointF(e.MarginBounds.Left, ((e.MarginBounds.Top - e.PageBounds.Top) / 2) - (headerSize.Height / 2));
                g.DrawString(this._title, headerFont, brush, headerLocation);
            }
        }

        //External function declarations
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, int lParam);
        [DllImport("user32.dll")]
        private static extern IntPtr GetDC(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int width, int height);
    }
}
