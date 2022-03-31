using System.Collections.Generic;

namespace WkHtmlConverter
{
    public class PdfPaperSize
    {
        /// <summary>
        /// Paper sizes from http://msdn.microsoft.com/en-us/library/system.drawing.printing.PdfPaperKind.aspx
        /// </summary>
        private static readonly Dictionary<PdfPaperKind, PdfPaperSize> Dictionary = new()
        {
            { PdfPaperKind.Letter, new PdfPaperSize("8.5in", "11in") },
            { PdfPaperKind.Legal, new PdfPaperSize("8.5in", "14in") },
            { PdfPaperKind.A4, new PdfPaperSize("210mm", "297mm") },
            { PdfPaperKind.CSheet, new PdfPaperSize("17in", "22in") },
            { PdfPaperKind.DSheet, new PdfPaperSize("22in", "34in") },
            { PdfPaperKind.ESheet, new PdfPaperSize("34in", "44in") },
            { PdfPaperKind.LetterSmall, new PdfPaperSize("8.5in", "11in") },
            { PdfPaperKind.Tabloid, new PdfPaperSize("11in", "17in") },
            { PdfPaperKind.Ledger, new PdfPaperSize("17in", "11in") },
            { PdfPaperKind.Statement, new PdfPaperSize("5.5in", "8.5in") },
            { PdfPaperKind.Executive, new PdfPaperSize("7.25in", "10.5in") },
            { PdfPaperKind.A3, new PdfPaperSize("297mm", "420mm") },
            { PdfPaperKind.A4Small, new PdfPaperSize("210mm", "297mm") },
            { PdfPaperKind.A5, new PdfPaperSize("148mm", "210mm") },
            { PdfPaperKind.B4, new PdfPaperSize("250mm", "353mm") },
            { PdfPaperKind.B5, new PdfPaperSize("176mm", "250mm") },
            { PdfPaperKind.Folio, new PdfPaperSize("8.5in", "13in") },
            { PdfPaperKind.Quarto, new PdfPaperSize("215mm", "275mm") },
            { PdfPaperKind.Standard10x14, new PdfPaperSize("10in", "14in") },
            { PdfPaperKind.Standard11x17, new PdfPaperSize("11in", "17in") },
            { PdfPaperKind.Note, new PdfPaperSize("8.5in", "11in") },
            { PdfPaperKind.Number9Envelope, new PdfPaperSize("3.875in", "8.875in") },
            { PdfPaperKind.Number10Envelope, new PdfPaperSize("4.125in", "9.5in") },
            { PdfPaperKind.Number11Envelope, new PdfPaperSize("4.5in", "10.375in") },
            { PdfPaperKind.Number12Envelope, new PdfPaperSize("4.75in", "11in") },
            { PdfPaperKind.Number14Envelope, new PdfPaperSize("5in", "11.5in") },
            { PdfPaperKind.DLEnvelope, new PdfPaperSize("110mm", "220mm") },
            { PdfPaperKind.C5Envelope, new PdfPaperSize("162mm", "229mm") },
            { PdfPaperKind.C3Envelope, new PdfPaperSize("324mm", "458mm") },
            { PdfPaperKind.C4Envelope, new PdfPaperSize("229mm", "324mm") },
            { PdfPaperKind.C6Envelope, new PdfPaperSize("114mm", "162mm") },
            { PdfPaperKind.C65Envelope, new PdfPaperSize("114mm", "229mm") },
            { PdfPaperKind.B4Envelope, new PdfPaperSize("250mm", "353mm") },
            { PdfPaperKind.B5Envelope, new PdfPaperSize("176mm", "250mm") },
            { PdfPaperKind.B6Envelope, new PdfPaperSize("176mm", "125mm") },
            { PdfPaperKind.ItalyEnvelope, new PdfPaperSize("110mm", "230mm") },
            { PdfPaperKind.MonarchEnvelope, new PdfPaperSize("3.875in", "7.5in") },
            { PdfPaperKind.PersonalEnvelope, new PdfPaperSize("3.625in", "6.5in") },
            { PdfPaperKind.USStandardFanfold, new PdfPaperSize("14.875in", "11in") },
            { PdfPaperKind.GermanStandardFanfold, new PdfPaperSize("8.5in", "12in") },
            { PdfPaperKind.GermanLegalFanfold, new PdfPaperSize("8.5in", "13in") },
            { PdfPaperKind.IsoB4, new PdfPaperSize("250mm", "353mm") },
            { PdfPaperKind.JapanesePostcard, new PdfPaperSize("100mm", "148mm") },
            { PdfPaperKind.Standard9x11, new PdfPaperSize("9in", "11in") },
            { PdfPaperKind.Standard10x11, new PdfPaperSize("10in", "11in") },
            { PdfPaperKind.Standard15x11, new PdfPaperSize("15in", "11in") },
            { PdfPaperKind.InviteEnvelope, new PdfPaperSize("220mm", "220mm") },
            { PdfPaperKind.LetterExtra, new PdfPaperSize("9.275in", "12in") },
            { PdfPaperKind.LegalExtra, new PdfPaperSize("9.275in", "15in") },
            { PdfPaperKind.TabloidExtra, new PdfPaperSize("11.69in", "18in") },
            { PdfPaperKind.A4Extra, new PdfPaperSize("236mm", "322mm") },
            { PdfPaperKind.LetterTransverse, new PdfPaperSize("8.275in", "11in") },
            { PdfPaperKind.A4Transverse, new PdfPaperSize("210mm", "297mm") },
            { PdfPaperKind.LetterExtraTransverse, new PdfPaperSize("9.275in", "12in") },
            { PdfPaperKind.APlus, new PdfPaperSize("227mm", "356mm") },
            { PdfPaperKind.BPlus, new PdfPaperSize("305mm", "487mm") },
            { PdfPaperKind.LetterPlus, new PdfPaperSize("8.5in", "12.69in") },
            { PdfPaperKind.A4Plus, new PdfPaperSize("210mm", "330mm") },
            { PdfPaperKind.A5Transverse, new PdfPaperSize("148mm", "210mm") },
            { PdfPaperKind.B5Transverse, new PdfPaperSize("182mm", "257mm") },
            { PdfPaperKind.A3Extra, new PdfPaperSize("322mm", "445mm") },
            { PdfPaperKind.A5Extra, new PdfPaperSize("174mm", "235mm") },
            { PdfPaperKind.B5Extra, new PdfPaperSize("201mm", "276mm") },
            { PdfPaperKind.A2, new PdfPaperSize("420mm", "594mm") },
            { PdfPaperKind.A3Transverse, new PdfPaperSize("297mm", "420mm") },
            { PdfPaperKind.A3ExtraTransverse, new PdfPaperSize("322mm", "445mm") },
            { PdfPaperKind.JapaneseDoublePostcard, new PdfPaperSize("200mm", "148mm") },
            { PdfPaperKind.A6, new PdfPaperSize("105mm", "148mm") },
            { PdfPaperKind.LetterRotated, new PdfPaperSize("11in", "8.5in") },
            { PdfPaperKind.A3Rotated, new PdfPaperSize("420mm", "297mm") },
            { PdfPaperKind.A4Rotated, new PdfPaperSize("297mm", "210mm") },
            { PdfPaperKind.A5Rotated, new PdfPaperSize("210mm", "148mm") },
            { PdfPaperKind.B4JisRotated, new PdfPaperSize("364mm", "257mm") },
            { PdfPaperKind.B5JisRotated, new PdfPaperSize("257mm", "182mm") },
            { PdfPaperKind.JapanesePostcardRotated, new PdfPaperSize("148mm", "100mm") },
            { PdfPaperKind.JapaneseDoublePostcardRotated, new PdfPaperSize("148mm", "200mm") },
            { PdfPaperKind.A6Rotated, new PdfPaperSize("148mm", "105mm") },
            { PdfPaperKind.B6Jis, new PdfPaperSize("128mm", "182mm") },
            { PdfPaperKind.B6JisRotated, new PdfPaperSize("182mm", "128mm") },
            { PdfPaperKind.Standard12x11, new PdfPaperSize("12in", "11in") },
            { PdfPaperKind.Prc16K, new PdfPaperSize("146mm", "215mm") },
            { PdfPaperKind.Prc32K, new PdfPaperSize("97mm", "151mm") },
            { PdfPaperKind.Prc32KBig, new PdfPaperSize("97mm", "151mm") },
            { PdfPaperKind.PrcEnvelopeNumber1, new PdfPaperSize("102mm", "165mm") },
            { PdfPaperKind.PrcEnvelopeNumber2, new PdfPaperSize("102mm", "176mm") },
            { PdfPaperKind.PrcEnvelopeNumber3, new PdfPaperSize("125mm", "176mm") },
            { PdfPaperKind.PrcEnvelopeNumber4, new PdfPaperSize("110mm", "208mm") },
            { PdfPaperKind.PrcEnvelopeNumber5, new PdfPaperSize("110mm", "220mm") },
            { PdfPaperKind.PrcEnvelopeNumber6, new PdfPaperSize("120mm", "230mm") },
            { PdfPaperKind.PrcEnvelopeNumber7, new PdfPaperSize("160mm", "230mm") },
            { PdfPaperKind.PrcEnvelopeNumber8, new PdfPaperSize("120mm", "309mm") },
            { PdfPaperKind.PrcEnvelopeNumber9, new PdfPaperSize("229mm", "324mm") },
            { PdfPaperKind.PrcEnvelopeNumber10, new PdfPaperSize("324mm", "458mm") },
            { PdfPaperKind.Prc16KRotated, new PdfPaperSize("146mm", "215mm") },
            { PdfPaperKind.Prc32KRotated, new PdfPaperSize("97mm", "151mm") },
            { PdfPaperKind.Prc32KBigRotated, new PdfPaperSize("97mm", "151mm") },
            { PdfPaperKind.PrcEnvelopeNumber1Rotated, new PdfPaperSize("165mm", "102mm") },
            { PdfPaperKind.PrcEnvelopeNumber2Rotated, new PdfPaperSize("176mm", "102mm") },
            { PdfPaperKind.PrcEnvelopeNumber3Rotated, new PdfPaperSize("176mm", "125mm") },
            { PdfPaperKind.PrcEnvelopeNumber4Rotated, new PdfPaperSize("208mm", "110mm") },
            { PdfPaperKind.PrcEnvelopeNumber5Rotated, new PdfPaperSize("220mm", "110mm") },
            { PdfPaperKind.PrcEnvelopeNumber6Rotated, new PdfPaperSize("230mm", "120mm") },
            { PdfPaperKind.PrcEnvelopeNumber7Rotated, new PdfPaperSize("230mm", "160mm") },
            { PdfPaperKind.PrcEnvelopeNumber8Rotated, new PdfPaperSize("309mm", "120mm") },
            { PdfPaperKind.PrcEnvelopeNumber9Rotated, new PdfPaperSize("324mm", "229mm") },
            { PdfPaperKind.PrcEnvelopeNumber10Rotated, new PdfPaperSize("458mm", "324mm") },
        };

        private PdfPaperSize(string width, string height)
        {
            Width = width;
            Height = height;
        }

        public string Height { get; set; }

        public string Width { get; set; }

        public static implicit operator PdfPaperSize(PdfPaperKind pdfPaperKind)
        {
            return Dictionary[pdfPaperKind];
        }
    }
}