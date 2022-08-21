using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using System.Collections;

namespace EquipmentCheckOut
{
    class CPrintManifest : PrintDocument
    {
        CJob currentJob;
        Font font = new Font("Garamond", 10);
        Font casefont = new Font("Garamond", 12, FontStyle.Bold);
        Font descfont = new Font("Garamond", 9);
        float currY = 0;
        float ident = 20;
        int ManifestNo;

        int PrintingPage = 1;

        const float TOP_LIMIT = 50;
        const float START_MANIF = 110;
        const float SIGN_HEIGHT = 0;
        const float END_HEIGHT = 57;
        const float BOTTOM_LIMIT = 260;
        const float LINE_HEIGHT = 6;

        private Manifest manifest = new Manifest();
        private int manifestAdded = -1;
        private bool signaturesAdded = false;

        public CPrintManifest(CJob Job)
        {
            currentJob = Job;
            Job.Dispose();
            this.DocumentName = "Checkout Manifest - " + currentJob.Production + ", " + currentJob.Job;
            this.PrintPage += new PrintPageEventHandler(CPrintManifest_PrintPage);
            ManifestNo = 1000000 + currentJob.ID;
        }

        private void CPrintManifest_PrintPage(Object Sender, PrintPageEventArgs e)
        {
            e.Graphics.PageUnit = GraphicsUnit.Millimeter;

            if (manifest.Count == 0)
                LoadManifestData(e.Graphics);

            LetterHead(e.Graphics);
            DrawPageNo(e.Graphics, PrintingPage);

            currY = TOP_LIMIT;
            if (PrintingPage == 1)
                currY = DrawTitle(e.Graphics);

            e.HasMorePages = true;

            if (manifestAdded == manifest.Count-1)
            {
                if (signaturesAdded == false)
                {
                    currY = DrawSignatures(currY, e.Graphics);
                    if (currY < BOTTOM_LIMIT - END_HEIGHT)
                    {
                        currY = DrawEnd(currY, e.Graphics);
                        e.HasMorePages = false;
                    }
                }
                else
                {
                    currY = DrawEnd(currY, e.Graphics);
                    e.HasMorePages = false;
                }
            }
            else
            {
                currY = DrawHeader(currY, e.Graphics);
                foreach (Manifest.ManifestBlock mb in manifest)
                {
                    if (mb.Index > manifestAdded)
                    {
                        if ((mb.Height + currY) < BOTTOM_LIMIT)
                            currY = DrawItem(mb, currY, e.Graphics);
                        else
                            break;
                    }
                }
                
                if (currY + SIGN_HEIGHT < BOTTOM_LIMIT)
                {
                    currY = DrawSignatures(currY, e.Graphics);
                    if (currY  + END_HEIGHT< BOTTOM_LIMIT)
                    {
                        currY = DrawEnd(currY, e.Graphics);
                        e.HasMorePages = false;
                    }
                }
            }

            PrintingPage++;
        }

        private float LoadManifestData(Graphics g)
        {
            float totalHeight = 0;
            CCase c;
            int Pos = 1;
            int i = 0;
            DataTable cs = new CCases().CasesByJob(currentJob.ID);

            foreach (DataRow row in cs.Rows)
            {
                c = new CCase((int)row["ID"]);
                Manifest.ManifestBlock mbc = new Manifest.ManifestBlock();
                mbc.IsCase = true;
                mbc.ItemName = c.CaseName;
                mbc.SerialNo = c.ID.ToString();
                mbc.Height = LINE_HEIGHT;
                mbc.Index = i;
                manifest.Add(mbc);
                totalHeight += mbc.Height;
                i++;
                foreach (DataRow pos in new CMovements().MovementsByJobAndCase(currentJob.ID, c.ID).Rows)
                {
                    Manifest.ManifestBlock mbi = new Manifest.ManifestBlock();
                    mbi.Height = LINE_HEIGHT + g.MeasureString(pos["ItemIncluding"].ToString(), descfont).Height;
                    mbi.Position = Pos;
                    mbi.ItemName = pos["Name"].ToString();
                    if ((int)pos["Back"] == 1)
                        mbi.Back = true;
                    if (pos["Notes"].ToString().Length > 0)
                        mbi.Notes = true;
                    if ((int)pos["HasIssue"] == 1)
                        mbi.Problem = true;
                    mbi.Quantity = (int)pos["Quantity"];
                    mbi.Including = pos["ItemIncluding"].ToString();
                    mbi.SerialNo = pos["SerNo"].ToString();
                    mbi.Index = i;
                    manifest.Add(mbi);
                    totalHeight += mbi.Height;
                    Pos++;
                    i++;
                }
                c.Dispose();
            }
            cs.Dispose();
            return totalHeight;
        }

        private void LetterHead(Graphics g)
        {
            g.DrawImage(EquipmentCheckOut.Properties.Resources.Movie_Large_Logo_Text__Custom___2_, 11, 5, 31, 39);
            g.DrawLine(new Pen(Brushes.Black, 0), new Point(198, 148), new Point(210, 148));
            g.DrawImage(EquipmentCheckOut.Properties.Resources.Movie_Details_Text, 33, 270, 125, 15);
        }

        private float DrawTitle(Graphics g)
        {
            float y = TOP_LIMIT;
            g.DrawString("Check Out Manifest No. " + ManifestNo.ToString(), new Font("Garamond", 16), Brushes.Black, ident, y);
            y += 12;
            g.DrawString("Job Details", new Font("Garamond", 10, FontStyle.Bold), Brushes.Black, ident, y);
            y += 5;
            g.DrawString("Date:", font, Brushes.Black, ident, y);
            g.DrawString(currentJob.CheckOut.ToShortDateString(), font, Brushes.Black, ident + 38, y);
            y += 5;
            g.DrawString("Client:", font, Brushes.Black, ident, y);
            g.DrawString(currentJob.Production, new Font("David", 10), Brushes.Black, ident + 38, y);
            y += 5;
            g.DrawString("Crew:", font, Brushes.Black, ident, y);
            g.DrawString(currentJob.Crew, new Font("David", 10), Brushes.Black, ident + 38, y);
            y += 5;
            g.DrawString("Title:", font, Brushes.Black, ident, y);
            g.DrawString(currentJob.Job, new Font("David", 10), Brushes.Black, ident + 38, y);
            y += 5;
            g.DrawString("OpenDesk Doc No.:", font, Brushes.Black, ident, y);
            g.DrawString(currentJob.OpenDeskDocumentNo, new Font("David", 10), Brushes.Black, ident + 38, y);
            y += 7;
            g.DrawString("Planned Return:", font, Brushes.Black, ident, y);
            g.DrawString(currentJob.CheckIn.ToShortDateString(), font, Brushes.Black, ident + 38, y);

            return y + 10;
        }

        private float DrawHeader(float Y, Graphics g)
        {
            g.DrawString("Pos", font, Brushes.Black, ident, Y);
            float noWid = g.MeasureString("Quanitity", font).Width;
            g.DrawString("Quanitity", font, Brushes.Black, 36 - (noWid / 2), Y);
            g.DrawString("Item", font, Brushes.Black, 54, Y);
            noWid = g.MeasureString("Serial No", font).Width;
            g.DrawString("Serial No", font, Brushes.Black, 187 - noWid, Y);
            g.DrawLine(new Pen(Color.Black, 0), ident - 2, Y + 4, 189, Y + 4);
            return Y + 6;
        }

        private float DrawItem(Manifest.ManifestBlock Block, float Y, Graphics g)
        {
            float y = Y;
            float thisItemHeight = Block.Height;
            if (Block.IsCase == true)  // draw a case line
            {
                g.DrawString(Block.ItemName, casefont, Brushes.Black, ident - 2, y);
                g.DrawString(Block.SerialNo, casefont, Brushes.Black, 189 - g.MeasureString(Block.SerialNo, casefont).Width, y);
                y += Block.Height;
            }
            else     // draw an item line
            {
                Brush brsh = Brushes.Black;
                string tags = "";
                if (Block.Back) tags = "B";
                if (Block.Notes) tags += "C";
                if (Block.Problem) tags += "P";
                g.DrawString(Block.Position.ToString(), font, brsh, ident, y);
                g.DrawString(Block.Quantity.ToString(), font, brsh, 36 - (g.MeasureString(Block.Quantity.ToString(), font).Width / 2), y);
                g.DrawString(tags, new Font("Garamond", 9,FontStyle.Italic), brsh, ident -7, y);
                g.DrawString(Block.ItemName, font, brsh, 54, y);
                g.DrawString(Block.SerialNo, font, brsh, 187 - g.MeasureString(Block.SerialNo, font).Width, y);
                g.DrawString(Block.Including, descfont, brsh, 58, y + LINE_HEIGHT - 1);
                y += Block.Height;
            }
            manifestAdded = Block.Index;
            return y;
        }

        private float DrawSignatures(float Y, Graphics g)
        {
            //float y = Y + 5;
            //Rectangle rect = new Rectangle((int)ident - 2, (int)y, 75, 30);
            //g.DrawRectangle(new Pen(Color.Black, 0), rect);
            //rect.Inflate(-2, -2);
            //g.DrawString("Issued By:", font, Brushes.Black, rect);
            //rect.Inflate(2, 2);
            //rect.Offset(95, 0);
            //g.DrawRectangle(new Pen(Color.Black, 0), rect);
            //rect.Inflate(-2, -2);
            //g.DrawString("Received By:", font, Brushes.Black, rect);
            //signaturesAdded = true;
            //return Y + SIGN_HEIGHT;

            return Y;
        }

        private void DrawPageNo(Graphics g, int PageNo)
        {
            string pg = "Page " + PageNo.ToString();
            float txtwid = g.MeasureString(pg, font).Width;
            g.DrawString(pg, font, Brushes.Black, 105 - (txtwid / 2), 10);
        }

        private float DrawEnd(float Y, Graphics g)
        {
            float y = Y + 8;
            g.DrawLine(new Pen(Color.Black, 0), ident - 2, y, 189, y);
            y += 5;

            g.DrawString("Check Out Manifest No. " + ManifestNo.ToString(), new Font("Garamond", 12), Brushes.Black, ident, y);
            y += 8;
            g.DrawString("Issued By:", font, Brushes.Black, ident, y);
            g.DrawLine(new Pen(Color.Black, 0), ident + 25, y + 4, 150, y + 4);
            y += 8;
            g.DrawString("Time Left:", font, Brushes.Black, ident, y);
            g.DrawLine(new Pen(Color.Black, 0), ident + 25, y + 4, 150, y + 4);
            y += 8;
            g.DrawString("Picked Up By:", font, Brushes.Black, ident, y);
            g.DrawLine(new Pen(Color.Black, 0), ident + 25, y + 4, 150, y + 4);
            y += 8;
            g.DrawString("Time Returned:", font, Brushes.Black, ident, y);
            g.DrawLine(new Pen(Color.Black, 0), ident + 25, y + 4, 150, y + 4);
            y += 8;
            g.DrawString("Checked By:", font, Brushes.Black, ident, y);
            g.DrawLine(new Pen(Color.Black, 0), ident + 25, y + 4, 150, y + 4);
            return y + 4;
        }

        public void ShowPreview()
        {
            PrintPreviewDialog pp = new PrintPreviewDialog();
            pp.Document = this;
            pp.ShowDialog();
        }

        private class Manifest : CollectionBase
        {
            public struct ManifestBlock
            {
                public bool IsCase;
                public int Position;
                public int Quantity;
                public string ItemName;
                public string Including;
                public string SerialNo;
                public int Index;
                public float Height;
                public bool Back;
                public bool Notes;
                public bool Problem;
            }

            public Manifest()
            {
            }

            public ManifestBlock this[int Index]
            {
                get
                {
                    return (ManifestBlock)List[Index];
                }
                set
                {
                    this[Index] = value;
                }
            }

            public void Add(ManifestBlock Block)
            {
                List.Add(Block);
            }
        }

        private void InitializeComponent()
        {
            // 
            // CPrintManifest
            // 
            this.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.CPrintManifest_EndPrint);

        }

        private void CPrintManifest_EndPrint(object sender, PrintEventArgs e)
        {
            currentJob.Dispose();
        }
    }
}
