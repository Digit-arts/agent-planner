using System;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp.tool.xml.html;
using iTextSharp.tool.xml.parser;
using iTextSharp.tool.xml.pipeline.css;
using iTextSharp.tool.xml.pipeline.end;
using iTextSharp.tool.xml.pipeline.html;
using RazorEngine;
using RazorEngine.Templating;
// For extension methods.

namespace AgentPlanner.Services
{
    public class PdfGenerationService
    {
        public byte[] GeneratePdf(string templatePath, object model, string key, Type type, string []cssResources)
        {
            var template = File.ReadAllText(templatePath);
            string output;
            if (Engine.Razor.IsTemplateCached(key, type))
            {
                output = Engine.Razor.Run(key, type, model);
            }
            else
            {
                output = Engine.Razor.RunCompile(template, key, type, model);
            }
            return createPDF(output,cssResources).ToArray();
        }


        private MemoryStream createPDF(string html, string[] cssResources)
        {
            var msOutput = new MemoryStream();

            // step 1: creation of a document-object
            var document = new Document(PageSize.A3, 20, 20,20,20);

            // step 2:
            // we create a writer that listens to the document
            // and directs a XML-stream to a file
            var writer = PdfWriter.GetInstance(document, msOutput);

            // Set factories
            var htmlContext = new HtmlPipelineContext(null);
            htmlContext.SetTagFactory(Tags.GetHtmlTagProcessorFactory());

            // Set css
            ICSSResolver cssResolver = XMLWorkerHelper.GetInstance().GetDefaultCssResolver(false);

            IPipeline pipeline = new CssResolverPipeline(cssResolver,
                new HtmlPipeline(htmlContext, new PdfWriterPipeline(document, writer)));
            foreach (var cssResource in cssResources)
            {
                cssResolver.AddCssFile(cssResource, true);
            }
            var worker = new XMLWorker(pipeline, true);
            var xmlParse = new XMLParser(true, worker);

            // step 4: we open document and start the worker on the document
            document.Open();

            var sr = new StringReader(html);
            xmlParse.Parse(sr);

            // step 6: close the document and the worker
            worker.Close();
            document.Close();

            return msOutput;
        }
    }
}
