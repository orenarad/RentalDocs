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
    class CPrintDocument : PrintDocument
    {
        CDocument currentDoc;
        Font font9 = new Font("Segoe UI", 8);
        Font font9b = new Font("Segoe UI", 8, FontStyle.Bold);
        Font font10 = new Font("Segoe UI", 9);
        Font font10b = new Font("Segoe UI", 9, FontStyle.Bold);
        Font font12 = new Font("Segoe UI", 10);
        Font font12b = new Font("Segoe UI", 10, FontStyle.Bold);
        Font font14b = new Font("Segoe UI", 12, FontStyle.Bold);

        float currY = 0;
        int DocumentNo;
        string docTitle;
        string docOriginal = "";
        string docTerms;
        int PrintingPage = 1;
        StringFormat drawFormat = new StringFormat();
        StringFormat drawFormatWrap = new StringFormat();

        const float TOP_LIMIT = 50;
        const float START_MANIF = 110;
        const float END_HEIGHT = 57;
        const float BOTTOM_LIMIT = 260;
        const float LINE_HEIGHT = 5;
        const float MID_A4 = 105;
        const float LEFT_MARGIN = 20;
        const float RIGHT_MARGIN = 190;

        private Manifest manifest = new Manifest();
        private int RowAdded = -1;
        private bool AddedTotal = false;
        private bool AddedNotes = false;
        private bool AddedTerms = false;
        private bool AddedSignature = false;

        private struct ColumnsWidths
        {
            public float ItemNo;
            public float RelatedDoc;
            public float ItemName;
            public float Price;
            public float Quantity;
            public float Days;
            public float Discount;
            public float Total;
        }

        private struct DocumentSpec
        {
            public bool ShowOriginal;
            public bool ShowTotal;
            public bool ShowTerms;
            public bool ShowSignature;
        }

        private ColumnsWidths DocumentColumnsWidths;
        private DocumentSpec DocumentSpecifications;

        public CPrintDocument(int DocID)
        {
            currentDoc = new CDocument(DocID, true);
            this.DocumentName = currentDoc.DocumentNumber.ToString();
            this.PrintPage += new PrintPageEventHandler(CPrintDocument_PrintPage);
            drawFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft;
            drawFormatWrap.FormatFlags = StringFormatFlags.DirectionRightToLeft | StringFormatFlags.LineLimit;
            using (CFolder fol = new CFolder((int)currentDoc.DocumentType))
            {
                docTerms = fol.DocTerms;
            }

            DocumentNo = currentDoc.DocumentNumber;
            DocumentColumnsWidths.ItemNo = 8;
            DocumentColumnsWidths.Quantity = 10;


            
            switch (currentDoc.DocumentType)
            {
                case DocumentType.Quotation:
                    docTitle = Properties.Settings.Default.TITLE_QUOTE;
                    DocumentColumnsWidths.RelatedDoc = 0;
                    DocumentColumnsWidths.ItemName = 92;
                    DocumentColumnsWidths.Price = 17;
                    DocumentColumnsWidths.Days = 10;
                    DocumentColumnsWidths.Discount = 14;
                    DocumentColumnsWidths.Total = 17;

                    DocumentSpecifications.ShowOriginal = false;
                    DocumentSpecifications.ShowTotal = true;
                    DocumentSpecifications.ShowTerms = true;
                    DocumentSpecifications.ShowSignature = true;
                    break;

                case DocumentType.ExitCertificate:
                    docTitle = Properties.Settings.Default.TITLE_SHIPMENT;
                    DocumentColumnsWidths.RelatedDoc = 17;
                    DocumentColumnsWidths.ItemName = 135;
                    DocumentColumnsWidths.Price = 0;
                    DocumentColumnsWidths.Days = 0;
                    DocumentColumnsWidths.Discount = 0;
                    DocumentColumnsWidths.Total = 0;

                    DocumentSpecifications.ShowOriginal = true;
                    DocumentSpecifications.ShowTotal = false;
                    DocumentSpecifications.ShowTerms = true;
                    DocumentSpecifications.ShowSignature = true;
                    break;

                case DocumentType.ReturnCertificate:
                    docTitle = Properties.Settings.Default.TITLE_RECEIVE;
                    DocumentColumnsWidths.RelatedDoc = 17;
                    DocumentColumnsWidths.ItemName = 135;
                    DocumentColumnsWidths.Price = 0;
                    DocumentColumnsWidths.Days = 0;
                    DocumentColumnsWidths.Discount = 0;
                    DocumentColumnsWidths.Total = 0;

                    DocumentSpecifications.ShowOriginal = true;
                    DocumentSpecifications.ShowTotal = false;
                    DocumentSpecifications.ShowTerms = false;
                    DocumentSpecifications.ShowSignature = false;
                    break;

                case DocumentType.Bill:
                    docTitle = Properties.Settings.Default.TITLE_BILL;
                    DocumentColumnsWidths.RelatedDoc = 17;
                    DocumentColumnsWidths.ItemName = 77;
                    DocumentColumnsWidths.Price = 17;
                    DocumentColumnsWidths.Days = 10;
                    DocumentColumnsWidths.Discount = 14;
                    DocumentColumnsWidths.Total = 17;

                    DocumentSpecifications.ShowOriginal = true;
                    DocumentSpecifications.ShowTotal = true;
                    DocumentSpecifications.ShowTerms = true;
                    DocumentSpecifications.ShowSignature = false;
                    break;
            }
            if (DocumentSpecifications.ShowOriginal == true)
                if (currentDoc.DocumentNumber == 0)
                    docOriginal = Properties.Settings.Default.DOC_DRAFT;
                else
                {
                    if (currentDoc.Printed == true)
                        docOriginal = Properties.Settings.Default.DOC_COPY;
                    else
                        docOriginal = Properties.Settings.Default.DOC_ORIGINAL;
                }
        }

        private void CPrintDocument_PrintPage(Object Sender, PrintPageEventArgs e)
        {
            e.Graphics.PageUnit = GraphicsUnit.Millimeter;

            // if this is the fisrt page than the document was not loaded yet.
            if (manifest.Count == 0)
                LoadDocumentData(e.Graphics);

            // draw these in a fixed location on the page.
            LetterHead(e.Graphics);
            DrawPageNo(e.Graphics);

            // set the "curser" at the top of the page
            currY = TOP_LIMIT;
            currY = DrawTitle(e.Graphics);

            e.HasMorePages = true;


            // add header if rows left to draw
            if (RowAdded < manifest.Count - 1)
                currY = DrawHeader(currY, e.Graphics);

            // add rows as long as the page permits
            for (int i = RowAdded+1; i < manifest.Count; i++ )
            {
                if (currY < BOTTOM_LIMIT)
                    currY = DrawItem(manifest[i], currY, e.Graphics);
                else
                    break;
            }

            // go through the specification and add pages as needed
            
            // test 1: was all rows drawn?
            if (RowAdded < manifest.Count - 1)     
            {
                DrawToBeContinued(e.Graphics);
                return;
            }

            // test 2: total needed and wasn't drawn?
            if (AddedTotal == false)    
            {
                float totalHeight = DrawTotal(currY, e.Graphics, false);
                if (totalHeight < BOTTOM_LIMIT)    // room for total?
                    currY = DrawTotal(currY, e.Graphics);
                else
                {
                    DrawToBeContinued(e.Graphics);
                    return;
                }
            }

            // test 3: notes needed and wasn't drawn?
            if (currentDoc.Notes.Length > 0 && AddedNotes == false)
            {
                float notesHeight = DrawNotes(currY, e.Graphics, false);
                if (notesHeight < BOTTOM_LIMIT)    // room for notes?
                    currY = DrawNotes(currY, e.Graphics);
                else
                {
                    DrawToBeContinued(e.Graphics);
                    return;
                }
            }

            // test 4: terms needed and wasn't drawn?
            if (AddedTerms == false)
            {
                float termsHeight = DrawTerms(currY, e.Graphics, false);
                if (termsHeight < BOTTOM_LIMIT)    // room for terms?
                    currY = DrawTerms(currY, e.Graphics);
                else
                {
                    DrawToBeContinued(e.Graphics);
                    return;
                }
            }

            // test 5: signature needed and wasnt drawn?
            if (DocumentSpecifications.ShowSignature == true && AddedSignature == false)
            {
                float signHeight = DrawSignatures(currY, e.Graphics, false);
                if (signHeight < BOTTOM_LIMIT)      // room for signature?
                    currY = DrawSignatures(currY, e.Graphics);
                else
                {
                    DrawToBeContinued(e.Graphics);
                    return;
                }
            }

            // if we reached here than the document is finished
            e.HasMorePages = false;
            DrawEnd(e.Graphics);
        }

        private void LoadDocumentData(Graphics g)
        {
            int i = 0;

            using (DataTable rows = currentDoc.GetDocumentRows())
            {
                foreach (DataRow row in rows.Rows)
                {
                    Manifest.DocumentRow docrow = new Manifest.DocumentRow();
                    docrow.Index = i;
                    docrow.No = (int)row["ProductID"];
                    try { docrow.RelatedDoc = (int)row["DocNumber"]; }
                    catch { }
                    docrow.ItemName = row["ProductName"].ToString();
                    try { docrow.Description = row["ProductDesc"].ToString(); }
                    catch { }
                    double price = double.Parse(row["SalesPrice"].ToString());
                    if (price > 0)
                        docrow.Price = double.Parse(row["SalesPrice"].ToString());
                    else
                        docrow.Price = double.Parse(row["RentalPrice"].ToString());
                    docrow.Quantity = (int)row["Quantity"];
                    docrow.Days = (int)row["Days"];
                    docrow.Discount = double.Parse(row["Discount"].ToString());

                    docrow.Total = docrow.Price * docrow.Days * docrow.Quantity * (1-docrow.Discount);
                    i++;
                    float descHeight = g.MeasureString(docrow.Description, 
                                                       font9, 
                                                       new SizeF(DocumentColumnsWidths.ItemName, 200F), 
                                                       drawFormat).Height;
                    docrow.Height = LINE_HEIGHT + descHeight;
                    manifest.Add(docrow);
                }
            }
        }

        private void LetterHead(Graphics g)
        {
            try
            {
                string letterHeadFile;
                using (CRecord lh = new CRecord("Settings"))
                {
                    letterHeadFile = lh.Table.Rows[0]["LHPath"].ToString();
                }
                try
                {
                    Image img = Image.FromFile(letterHeadFile);
                    g.DrawImage(img, new Rectangle(0,0,210,296));
                }
                catch { }

            }
            catch { };

            //g.DrawImage(EquipmentCheckOut.Properties.Resources.Movie_Large_Logo_Text__Custom___2_, 11, 5, 31, 39);
            g.DrawLine(new Pen(Brushes.Black, 0), new Point(192, 148), new Point(210, 148));
            //g.DrawImage(EquipmentCheckOut.Properties.Resources.Movie_Details_Text, 33, 270, 125, 15);
        }

        private float DrawTitle(Graphics g)
        {
            float y = TOP_LIMIT - 15;
            string str = docTitle + " מס':   " + DocumentNo.ToString();
            float wid;

            wid = g.MeasureString(docOriginal, font12).Width;
            g.DrawString(docOriginal, font12, Brushes.Black, MID_A4 + (wid / 2), y, drawFormat);
            y += 5;

            wid = g.MeasureString(str, font14b).Width;
            g.DrawString(str, font14b, Brushes.Black, MID_A4 + (wid / 2), y, drawFormat);
            y += 10;

            // Client name block:
            str = "לכבוד:";
            wid = g.MeasureString(str, font12).Width;
            g.DrawString(str, font12, Brushes.Black, RIGHT_MARGIN , y, drawFormat);
            y += 6;

            str = currentDoc.ClientName;
            g.DrawString(str, font10, Brushes.Black, RIGHT_MARGIN, y, drawFormat);
            y += 4;

            str = currentDoc.ClientDetails;
            g.DrawString(str, font10, Brushes.Black, RIGHT_MARGIN, y, drawFormat);
            y += 8;

            if (currentDoc.DocumentType == DocumentType.Quotation)
                str = currentDoc.ProjecName;
            else
                str = currentDoc.ProjecText;

            g.DrawString("פרויקט: " + str, font12, Brushes.Black, RIGHT_MARGIN, y, drawFormat);
            y += 4;

            str = currentDoc.Subject;
            g.DrawString("נושא: " + str, font14b, Brushes.Black, RIGHT_MARGIN, y, drawFormat);

            if (PrintingPage > 1)
            {
                int prevPage = PrintingPage - 1;
                str = "המשך מעמוד מס' " + prevPage.ToString();
                wid = g.MeasureString(str, font10).Width;
                g.DrawString(str, font10, Brushes.Black, RIGHT_MARGIN, y + 10, drawFormat);
            }
            y -= 16;

            // document details:
            str = currentDoc.Date1.ToShortDateString() + " " + currentDoc.Date1.ToShortTimeString();
            g.DrawString(str, font10, Brushes.Black, LEFT_MARGIN, y);
            g.DrawString("תאריך:", font10, Brushes.Black, LEFT_MARGIN + 45, y, drawFormat);
            y += 4;
            
            if (currentDoc.DocumentType != DocumentType.Bill)
            {
                str = currentDoc.Date2.ToShortDateString();
                g.DrawString(str, font10, Brushes.Black, LEFT_MARGIN, y);
                g.DrawString(currentDoc.Date2Name, font10, Brushes.Black, LEFT_MARGIN + 45, y, drawFormat);
                y += 4;
            }

            str = currentDoc.ClientHashavshevetNo.ToString();
            g.DrawString(str, font10, Brushes.Black, LEFT_MARGIN, y);
            g.DrawString("מס' לקוח:", font10, Brushes.Black, LEFT_MARGIN + 45, y, drawFormat);
            y += 4;

            str = currentDoc.UserName.ToString();
            g.DrawString(str, font10, Brushes.Black, LEFT_MARGIN, y);
            g.DrawString("נוצר ע''י:", font10, Brushes.Black, LEFT_MARGIN + 45, y, drawFormat);
            y += 4;

            return y + 16;
        }

        private float DrawHeader(float Y, Graphics g)
        {
            float xpos = RIGHT_MARGIN;
            g.DrawString("מס'", font9b, Brushes.Black, xpos, Y, drawFormat);
            xpos -= DocumentColumnsWidths.ItemNo;

            if (DocumentColumnsWidths.RelatedDoc > 0)
                g.DrawString("ממסמך", font9b, Brushes.Black, xpos, Y, drawFormat);
            xpos -= DocumentColumnsWidths.RelatedDoc;

            g.DrawString("פריט", font9b, Brushes.Black, xpos, Y, drawFormat);
            xpos -= DocumentColumnsWidths.ItemName;

            if (DocumentColumnsWidths.Price > 0)
                g.DrawString("מחיר", font9b, Brushes.Black, xpos - 1, Y, drawFormat);
            xpos -= DocumentColumnsWidths.Price;

            g.DrawString("כמות", font9b, Brushes.Black, xpos + 2, Y, drawFormat);
            xpos -= DocumentColumnsWidths.Quantity;

            if (DocumentColumnsWidths.Days > 0)
                g.DrawString("ימים", font9b, Brushes.Black, xpos, Y, drawFormat);
            xpos -= DocumentColumnsWidths.Days;

            if (DocumentColumnsWidths.Discount > 0)
                g.DrawString("הנחה", font9b, Brushes.Black, xpos - 2, Y, drawFormat);
            xpos -= DocumentColumnsWidths.Discount;

            if (DocumentColumnsWidths.Total > 0)
                g.DrawString("סה''כ", font9b, Brushes.Black, xpos - 5, Y, drawFormat);

            g.DrawLine(new Pen(Color.Black, 0), LEFT_MARGIN, Y + 4, RIGHT_MARGIN, Y + 4);
            return Y + 5;
        }

        private float DrawItem(Manifest.DocumentRow Block, float Y, Graphics g)
        {
            float y = Y;

            float xpos = RIGHT_MARGIN;
            g.DrawString(Block.No.ToString(), font9, Brushes.Black, xpos, Y, drawFormat);
            xpos -= DocumentColumnsWidths.ItemNo;

            if (DocumentColumnsWidths.RelatedDoc > 0)
                if (Block.RelatedDoc > 0)
                    g.DrawString(Block.RelatedDoc.ToString(), font10, Brushes.Black, xpos, Y, drawFormat);
            xpos -= DocumentColumnsWidths.RelatedDoc;

            g.DrawString(Block.ItemName, font10, Brushes.Black, xpos, Y, drawFormat);

            RectangleF descRect = new RectangleF(xpos - DocumentColumnsWidths.ItemName, 
                                                currY + LINE_HEIGHT - 1, 
                                                DocumentColumnsWidths.ItemName,
                                                Block.Height - LINE_HEIGHT);
            //g.DrawRectangle(Pens.Black, descRect);
            g.DrawString(Block.Description, font9, Brushes.Black, descRect, drawFormat);
            xpos -= DocumentColumnsWidths.ItemName;

            if (DocumentColumnsWidths.Price > 0)
            {
                float priceWidth = g.MeasureString(Block.Price.ToString("C"), font10).Width;
                g.DrawString(Block.Price.ToString("C"), font10, Brushes.Black, xpos - priceWidth, Y);

            }
            xpos -= DocumentColumnsWidths.Price;

            g.DrawString(Block.Quantity.ToString(), font10, Brushes.Black, xpos, Y, drawFormat);
            xpos -= DocumentColumnsWidths.Quantity;

            if (DocumentColumnsWidths.Days > 0)
                g.DrawString(Block.Days.ToString(), font10, Brushes.Black, xpos, Y, drawFormat);
            xpos -= DocumentColumnsWidths.Days;

            if (DocumentColumnsWidths.Discount > 0)
                g.DrawString(Block.Discount.ToString("P"), font10, Brushes.Black, xpos, Y, drawFormat);
            xpos -= DocumentColumnsWidths.Discount;

            if (DocumentColumnsWidths.Total > 0)
                g.DrawString(Block.Total.ToString("C"), font10, Brushes.Black, LEFT_MARGIN, Y);

            // line for stas
            g.DrawLine(new Pen(Color.Gray, 0), LEFT_MARGIN, Y + Block.Height, RIGHT_MARGIN, Y + Block.Height);

            RowAdded = Block.Index;
            return y + Block.Height;
        }

        private float DrawTotal(float Y, Graphics g, bool Draw = true)
        {
            float y = Y;
            double vat = (double)Properties.Settings.Default.VAT;

            if (Draw == true)
                g.DrawLine(new Pen(Color.Black, 0), LEFT_MARGIN, y , RIGHT_MARGIN, y);

            y += 2;
            if (DocumentSpecifications.ShowTotal == true)
            {
                if (Draw == true)
                {
                    g.DrawString(manifest.GetTotal.ToString("C"), font10, Brushes.Black, LEFT_MARGIN, y);
                    g.DrawString("סה''כ: ", font10, Brushes.Black, LEFT_MARGIN + DocumentColumnsWidths.Total + 40, y, drawFormat);
                }
                y += LINE_HEIGHT;
                if (Draw == true)
                {
                    vat = vat * manifest.GetTotal;
                    g.DrawString(vat.ToString("C"), font10, Brushes.Black, LEFT_MARGIN, y);
                    g.DrawString("מע''מ " + Properties.Settings.Default.VAT.ToString("P") + ":", font10, Brushes.Black, LEFT_MARGIN + DocumentColumnsWidths.Total + 40, y, drawFormat);
                }
                y += LINE_HEIGHT;
                if (Draw == true)
                {
                    vat = vat + manifest.GetTotal;
                    g.DrawString(vat.ToString("C"), font10b, Brushes.Black, LEFT_MARGIN, y);
                    g.DrawString("סה''כ כולל מע''מ:" , font10b, Brushes.Black, LEFT_MARGIN + DocumentColumnsWidths.Total + 40, y, drawFormat);
                    AddedTotal = true;
                }
                y += LINE_HEIGHT;
            }

            return y;
        }

        private void DrawToBeContinued(Graphics g)
        {
            int nextPage = PrintingPage + 1;
            string str = "המשך בעמוד מס' " + nextPage.ToString();
            float wid = g.MeasureString(str, font9).Width;
            g.DrawString(str, font9, Brushes.Black, RIGHT_MARGIN, BOTTOM_LIMIT + 3 , drawFormat);
            PrintingPage++;
        }

        private void DrawEnd(Graphics g)
        {
            int nextPage = PrintingPage + 1;
            string str = "סה''כ עמודים במסמך: " + PrintingPage;
            float wid = g.MeasureString(str, font9).Width;
            g.DrawString(str, font9, Brushes.Black, RIGHT_MARGIN, BOTTOM_LIMIT + 3, drawFormat);
            PrintingPage++;
        }

        private float DrawSignatures(float Y, Graphics g, bool Draw = true)
        {
            float y = Y + 5;
            if (Draw == true)
            {
                g.DrawLine(new Pen(Color.Black, 0), LEFT_MARGIN, y-1, RIGHT_MARGIN, y-1);

                float xpos = 25;
                string text = "חתימה + חותמת";
                g.DrawString(text,font10, Brushes.Black, xpos, y);

                xpos += 60;
                text = "טלפון";
                float txtWid = g.MeasureString(text, font10).Width;
                g.DrawString(text, font10, Brushes.Black, xpos + (txtWid / 2), y);

                xpos += 40;
                text = "תפקיד";
                txtWid = g.MeasureString(text, font10).Width;
                g.DrawString(text, font10, Brushes.Black, xpos + (txtWid / 2), y);

                xpos += 40;
                text = "שם מלא";
                txtWid = g.MeasureString(text, font10).Width;
                g.DrawString(text, font10, Brushes.Black, xpos + (txtWid / 2), y);

            }

            AddedSignature = true;
            return y + 15;
        }

        private void DrawPageNo(Graphics g)
        {
            string pg = "עמוד מס' " + PrintingPage.ToString();
            float txtwid = g.MeasureString(pg, font9).Width;
            g.DrawString(pg, font9, Brushes.Black, 105 - (txtwid / 2), 10);
        }

        private float DrawNotes(float Y, Graphics g, bool Draw = true)
        {
            float y = Y + 5;

            // Set maximum layout size.
            SizeF layoutSize = new SizeF(170F, 200.0F);
            // Set string format.
            StringFormat newStringFormat = new StringFormat();

            // Measure string.
            SizeF stringSize = new SizeF();
            stringSize = g.MeasureString(currentDoc.Notes, font9, layoutSize, drawFormat);

            if (Draw == true)
            {
                RectangleF rect = new RectangleF(LEFT_MARGIN + 10, y, RIGHT_MARGIN - LEFT_MARGIN - 20, stringSize.Height);
                g.DrawString(currentDoc.Notes, font9, Brushes.Black, rect, drawFormat);
            }

            y += stringSize.Height + 5;

            AddedNotes = true;
            return y;
        }

        private float DrawTerms(float Y, Graphics g, bool Draw = true)
        {
            float y = Y + 5;

            if (DocumentSpecifications.ShowTerms == true)
            {
                // Set maximum layout size.
                SizeF layoutSize = new SizeF(170F, 200.0F);
                // Set string format.
                StringFormat newStringFormat = new StringFormat();

                // Measure string.
                SizeF stringSize = new SizeF();
                stringSize = g.MeasureString(docTerms, font9, layoutSize, drawFormat);


                if (Draw == true)
                {
                    RectangleF rect = new RectangleF(LEFT_MARGIN + 10, y, RIGHT_MARGIN - LEFT_MARGIN - 20, stringSize.Height);
                    //g.DrawRectangle(Pens.Black,rect.X, rect.Y, rect.Width, rect.Height);
                    g.DrawString(docTerms, font9, Brushes.Black, rect, drawFormat);


                    AddedTerms = true;
                }
                y += stringSize.Height + 5;
            }
            return y;
        }

        public void ShowPreview()
        {
            PrintPreviewDialog pp = new PrintPreviewDialog();
            pp.Document = this;
            pp.ShowDialog();
        }

        private class Manifest : CollectionBase
        {
            public struct DocumentRow
            {
                public int Index;
                public int No;
                public int RelatedDoc;
                public string ItemName;
                public string Description;
                public double Price;
                public int Quantity;
                public int Days;
                public double Discount;
                public double Total;
                public float Height;
            }

            public Manifest()
            {
            }

            public DocumentRow this[int Index]
            {
                get
                {
                    return (DocumentRow)List[Index];
                }
                set
                {
                    this[Index] = value;
                }
            }

            public void Add(DocumentRow Block)
            {
                List.Add(Block);
            }

            public double GetTotal
            {
                get
                {
                    double total = 0;
                    foreach (DocumentRow row in this)
                    {
                        total += row.Total;
                    }
                    return total;
                }
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
            currentDoc.Dispose();
        }
    }
}
