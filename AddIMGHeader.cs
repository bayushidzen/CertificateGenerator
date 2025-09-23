using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using D = DocumentFormat.OpenXml.Drawing;
using DW = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using PIC = DocumentFormat.OpenXml.Drawing.Pictures;

namespace CertificateGenerator
{
    public class AddIMGHeader
    {
        public static readonly long widthPixels = 700;
        public static readonly long heightPixels = 70;

        public static Drawing AddLogo(WordprocessingDocument doc, string imagePath)
        {
            HeaderPart headerPart = doc.MainDocumentPart.HeaderParts.First();
            ImagePart imagePart = headerPart.AddImagePart(ImagePartType.Png);
            using (FileStream stream = new FileStream(imagePath, FileMode.Open))
            {
                imagePart.FeedData(stream);
            }
            string imageId = headerPart.GetIdOfPart(imagePart);
            long widthEmu = widthPixels * 9525;
            long heightEmu = heightPixels * 9525;
            return CreateDrawingElement(imageId, widthEmu, heightEmu);
        }

        private static Drawing CreateDrawingElement(string imageId, long widthEmu, long heightEmu)
        {
            var drawing = new Drawing();
            var inline = new DW.Inline()
            {
                DistanceFromTop = 0,
                DistanceFromBottom = 0,
                DistanceFromLeft = 0,
                DistanceFromRight = 0,
                AnchorId = "0"
            };
            inline.Append(new DW.Extent() { Cx = widthEmu, Cy = heightEmu });
            inline.Append(new DW.DocProperties() { Id = 1, Name = "Header Image" });
            var graphic = new D.Graphic();
            inline.Append(graphic);
            var graphicData = new D.GraphicData()
            {
                Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture"
            };
            graphic.Append(graphicData);
            var picture = new PIC.Picture();
            graphicData.Append(picture);
            var nvPicProps = new PIC.NonVisualPictureProperties();
            nvPicProps.Append(new PIC.NonVisualDrawingProperties()
            {
                Id = 0,
                Name = "Image"
            });
            nvPicProps.Append(new PIC.NonVisualPictureDrawingProperties());
            picture.Append(nvPicProps);
            var blipFill = new PIC.BlipFill();
            var blip = new D.Blip()
            {
                Embed = imageId,
                CompressionState = D.BlipCompressionValues.Print
            };
            var blipExtList = new D.BlipExtensionList();
            blipExtList.Append(new D.BlipExtension()
            {
                Uri = "{28A0092B-C50C-407E-A947-70E740481C1C}"
            });
            blip.Append(blipExtList);
            blipFill.Append(blip);
            blipFill.Append(new D.Stretch(new D.FillRectangle()));
            picture.Append(blipFill);
            var shapeProps = new PIC.ShapeProperties();
            shapeProps.Append(new D.Transform2D(
                new D.Offset() { X = 0, Y = 0 },
                new D.Extents() { Cx = widthEmu, Cy = heightEmu }));
            shapeProps.Append(new D.PresetGeometry(new D.AdjustValueList())
            {
                Preset = D.ShapeTypeValues.Rectangle
            });
            picture.Append(shapeProps);
            drawing.Append(inline);
            return drawing;
        }
    }

}
