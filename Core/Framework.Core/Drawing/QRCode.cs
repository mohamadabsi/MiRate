﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QRCode.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
#region usings
using Framework.Core.Extensions;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using ZXing.QrCode.Internal;
using ZXing.Rendering;
#endregion
namespace Framework.Core.Drawing
{
    /// <summary>
    ///     The QR code util.
    /// </summary>
    public static class QRCode
    {
        public static byte[] ToQRCode(this string content, string logoPath = "")
        {
            var width_size = 100;
         
            var hight_size = 100;

            BarcodeWriter barCodeWriter = new BarcodeWriter();

            EncodingOptions opetions = new EncodingOptions() { Width = width_size, Height = hight_size, PureBarcode = false, Margin = 0 };

            opetions.Hints.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.H);

            barCodeWriter.Renderer = new BitmapRenderer();

            barCodeWriter.Options = opetions;

            barCodeWriter.Format = BarcodeFormat.QR_CODE;

            Bitmap qRBitMap = barCodeWriter.Write(content);

            var bytes = qRBitMap.ToByteArray();

            return bytes;

        }
        

        /// <summary> 
        /// The generate simple string qr code.
        /// </summary>
        /// <param name="stringToEncode">
        /// The string to encode.
        /// </param>
        /// <param name="height">
        /// The height.
        /// </param>
        /// <param name="width">
        /// The width.
        /// </param>
        /// <returns>
        /// The <see cref="byte[]"/>.
        /// </returns>
        public static byte[] GenerateSimpleStringQrCode(this string stringToEncode, int height, int width)
        {
            // instantiate a writer object
            var barcodeWriter = new BarcodeWriterPixelData
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new QrCodeEncodingOptions
                {
                    DisableECI = true,
                    CharacterSet = "UTF-8",
                    Height = height,
                    Width = width,
                    Margin = 5
                }
            };

            var image = barcodeWriter.Write(stringToEncode);

            return image.Pixels;
        }



        /// <summary>
        /// The generate vcard qr code.
        /// </summary>
        /// <param name="cardInfo">
        /// The card info.
        /// </param>
        /// <param name="width">
        /// The width.
        /// </param>
        /// <param name="height">
        /// The height.
        /// </param>
        /// <returns>
        /// The <see cref="byte[]"/>.
        /// </returns>
        public static byte[] GenerateVcardQRCode(VCard cardInfo, int width, int height)
        {
            // Sample VCard

            // BEGIN:VCARD
            // VERSION:2.1
            // FN:Usama Nada
            // N:Nada;Usama
            // TITLE:Lead Software Engineer
            // TEL;CELL:0566254284
            // EMAIL;HOME;INTERNET:usama_nada@hotmail.com
            // EMAIL;WORK;INTERNET:unada@sure.com.sa
            // URL:http://linkedin.com/in/usamanada
            // ADR:;;Al-Hayat Center, Building B, I;Riyadh;;11372;Saudi Arabia
            // ORG:Sure Technology & Consulting
            // END:VCARD
            var qrValue = $@"BEGIN:VCARD
VERSION:2.1
FN:{cardInfo.FullName}
N:{cardInfo.FirstName};{cardInfo.LastName}
TITLE:{cardInfo.Title}
TEL;CELL:{cardInfo.Mobile}
EMAIL;HOME;INTERNET:{cardInfo.EmailPersonal}
EMAIL;WORK;INTERNET:{cardInfo.EmailWork}
URL:{cardInfo.Url}
ADR:;;{cardInfo.StreetAddress};{cardInfo.City};;{cardInfo.PostalCode};{cardInfo.Country}
ORG:{cardInfo.Company}
END:VCARD";

            // 12
            var barcodeWriter = new BarcodeWriterPixelData
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new QrCodeEncodingOptions
                {
                    DisableECI = true,
                    CharacterSet = "UTF-8",
                    Height = height,
                    Width = width,
                    Margin = 5
                }
            };

            var image = barcodeWriter.Write(qrValue);

            return image.Pixels;
        }

        /// <summary>
        /// The decode qr code.
        /// </summary>
        /// <param name="image">
        /// The image.
        /// </param>
        /// <param name="width">
        /// The width.
        /// </param>
        /// <param name="height">
        /// The height.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string DecodeQrCode(this byte[] image, int width, int height)
        {
            var source = new RGBLuminanceSource(image, width, height);
            var bitmap = new BinaryBitmap(new HybridBinarizer(source));
            var result = new MultiFormatReader().decode(bitmap);
            return result?.Text;
        }
    }
}