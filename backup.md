public static void CreateDocx()
        {
            using (WordprocessingDocument document = WordprocessingDocument.Create(_docFilePath, WordprocessingDocumentType.Document, autoSave: true))
            {
                var paragraphHelper = new AddBody();
                MainDocumentPart mainPart = document.AddMainDocumentPart();
                mainPart.Document = new Document(new Body());

                HeaderPart headerPart = mainPart.AddNewPart<HeaderPart>();
                string headerId = mainPart.GetIdOfPart(headerPart);

                Header header = new Header(
                    new Paragraph(BuildLogo(headerPart)
                    ),
                    new Paragraph(
                        new ParagraphProperties(new Justification { Val = JustificationValues.Center }),
                        new Run(new RunProperties(new FontSize { Val = "17" }), new Text(_headerText))
                        )
                    );

                headerPart.Header = header;

                var sectionProps = mainPart.Document.Descendants<SectionProperties>().FirstOrDefault();
                if (sectionProps == null)
                {
                    sectionProps = new SectionProperties();
                    mainPart.Document.Append(sectionProps);
                }
                sectionProps.Append(new HeaderReference
                {
                    Type = HeaderFooterValues.Default,
                    Id = mainPart.GetIdOfPart(headerPart)
                });

                //headerPart.Header = new Header(AddIMGHeader.BuildLogo(headerPart, _imagePath));

                /*headerPart.Header = new Header(new Paragraph(
                    new ParagraphProperties(new Justification { Val = JustificationValues.Center }),
                    new Run(new RunProperties(new FontSize { Val = "18" }), new Text(_headerText))));

                SectionProperties sectionProps = new SectionProperties(
                    new HeaderReference { Type = HeaderFooterValues.Default, Id = mainPart.GetIdOfPart(headerPart) }
                );*/

                //headerPart.Header.Append(BuildLogo(headerPart));
                //mainPart.Document.Body.Append(sectionProps);

                paragraphHelper.AddCaptionParagraph(document.MainDocumentPart.Document.Body, _certificateCaptionText);
                paragraphHelper.AddMainParagraph(document.MainDocumentPart.Document.Body, _certificateBodyText);
                document.Save();
            }
            //using var document = WordprocessingDocument.Create(_docFilePath, WordprocessingDocumentType.Document, autoSave: true);

            //var mainPart = document.AddMainDocumentPart();

            //mainPart.Document = new Document();
            //mainPart.Document.Body = new Body();

            //var paragraphHelper = new AddBody();
            /*var headerHelper = new AddHeader();
            var headerPart = document.MainDocumentPart!.AddNewPart<HeaderPart>();

            var rId = document.MainDocumentPart.GetIdOfPart(headerPart);

            headerPart.Header = new Header(new Paragraph(
                new ParagraphProperties(new Justification { Val = JustificationValues.Center }),
                new Run(new RunProperties(new FontSize { Val = "18" }), new Text(_headerText))));

            var sectionProps = new SectionProperties(
                new HeaderReference { Type = HeaderFooterValues.Default, Id = rId });

            document.MainDocumentPart.Document.Body.Append(sectionProps);
            //headerHelper.AddHeaderText(document, _headerText);

            paragraphHelper.AddCaptionParagraph(document.MainDocumentPart.Document.Body, _certificateCaptionText);
            paragraphHelper.AddMainParagraph(document.MainDocumentPart.Document.Body, _certificateBodyText);

            document.Save();*/
        }

        private static WordprocessingDocument InitDocument(string filePath)
        {
            var document = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document, autoSave: true);

            var mainPart = document.AddMainDocumentPart();

            mainPart.Document = new Document();
            mainPart.Document.Body = new Body();

            if (mainPart.DocumentSettingsPart == null)
            {
                mainPart.AddNewPart<DocumentSettingsPart>();
            }

            return document;
        }
        private static Paragraph BuildLogo(HeaderPart headerPart)
        {
            int CmToEmu(float cmValue)
            {
                return Convert.ToInt32(Math.Ceiling(cmValue * 360000));
            }

            var imagePart = headerPart.AddImagePart(ImagePartType.Png);
            using (var memoryStream = new MemoryStream(File.ReadAllBytes(_imagePath)))
            {
                imagePart.FeedData(memoryStream);
            }

            var imageRelId = headerPart.GetIdOfPart(imagePart);

            var sizes = (w: CmToEmu(4.8f), h: CmToEmu(3f));
            var offset = (x: CmToEmu(6.1f), y: 0);

            var imgId = 1u;
            var imgName = $"Изображение{imgId}";

            var nvPicPr = new NonVisualPictureProperties(new NonVisualDrawingProperties
            {
                Id = imgId,
                Name = imgName
            },
                new NonVisualPictureDrawingProperties
                {
                    PictureLocks = new PictureLocks
                    {
                        NoChangeAspect = true,
                        NoChangeArrowheads = true
                    }
                });

            var blipFill = new BlipFill(new Stretch(new FillRectangle()))
            {
                Blip = new Blip
                {
                    Embed = imageRelId
                }
            };

            var spPr = new ShapeProperties(new TransformGroup
            {
                Offset = new Offset
                {
                    X = offset.x,
                    Y = offset.y
                },
                Rotation = 0,
                Extents = new Extents { Cx = sizes.w, Cy = sizes.h }
            },
                new PresetGeometry { Preset = ShapeTypeValues.Rectangle });

            var pic = new Picture(nvPicPr, blipFill, spPr);

            var graphic = new Graphic
            {
                GraphicData = new GraphicData(pic)
                {
                    Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture"
                }
            };
            var inline = new Inline(
                new DocProperties { Id = imgId, Name = imgName },
                graphic)
            {
                DistanceFromTop = 0,
                DistanceFromBottom = 0,
                DistanceFromLeft = 0,
                DistanceFromRight = 0,
                Extent = new Extent
                {
                    Cx = sizes.w + offset.x,
                    Cy = sizes.h + offset.y,
                },
                EffectExtent = new EffectExtent
                {
                    TopEdge = 0,
                    BottomEdge = 0,
                    RightEdge = 0,
                    LeftEdge = 0
                }
            };

            var drawing = new Drawing(inline);

            var run = new Run(drawing) { RunProperties = new RunProperties() };
            return new Paragraph(run)
            {
                ParagraphProperties = new ParagraphProperties
                {
                    Justification = new Justification
                    {
                        Val = JustificationValues.Left
                    }
                }
            };
        }

        
        public static string GetFIO()
        { return _fisrtNameText; }
        private static void SetFIO(string newFIO)
        { _fisrtNameText = newFIO; }

        public static string GetStudyClass()
        { return _studyClass; }
        private static void SetStudyClass(string newFIO)
        { _studyClass = newFIO; }

        public static string GetOOName()
        { return _OOName; }
        private static void SetOOName(string newOOName)
        { _OOName = newOOName; }

        public static string GetParticipationClass()
        { return _participationClass; }
        private static void SetParticipationClass(string newParticipationClass)
        { _participationClass = newParticipationClass; }

        public static string GetSubject()
        { return _subject; }
        private static void SetSubject(string newSubject)
        { _subject = newSubject; }

        public static string GetResult()
        { return _result; }
        private static void SetResult(string newResult)
        { _result = newResult; }

        public static string GetStatus()
        { return _status; }
        private static void SetStatus(string newStatus)
        { _status = newStatus; }

        
            SetFIO(lastNameTextBox.Text);
            SetStudyClass(StudyClassTextBox.Text);
            SetOOName(OONameTextBox.Text);
            SetParticipationClass(ParticipationClassTextBox.Text);
            SetSubject(SubjectTextBox.Text);
            SetResult(ResultTextBox.Text);
            SetStatus(StatusTextBox.Text);