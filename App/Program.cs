using App;
using iText.Forms;
using iText.Forms.Fields;
using iText.Html2pdf;
using iText.IO.Image;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

var writer = new PdfWriter("../../../../test-pdf.pdf");
var pdf = new PdfDocument(writer);
var document = new Document(pdf);

// Add a header element.
document.Add(
    new Paragraph("This Is A Header!")
        .SetTextAlignment(TextAlignment.CENTER)
        .SetFontSize(25));

// Add a normal paragraph.
document.Add(
    new Paragraph("This is some normal text!")
    .SetTextAlignment(TextAlignment.LEFT)
    .SetFontSize(12));

// Add a table
var numOfColumns = 3;

document.Add(
    new Table(numOfColumns)
        .UseAllAvailableWidth()        
        .AddCell("Some data.")
        .AddCell("Some more data.")
        .AddCell("Some more data again.")
        .AddCell("Here's more.")
        .AddCell("Here's more again.")
        .AddCell("Hello!"));

// Add a line break
document.AddSpacer();

// Add an image
var img = new Image(ImageDataFactory.Create("../../../../bird.jpg"));
document.Add(img.SetAutoScale(true));

// Add a form
var form = PdfAcroForm.GetAcroForm(pdf, true);

var firstName = PdfFormField
    .CreateText(pdf, new Rectangle(10, 200, 200, 50), "first-name")
    .SetValue("First Name");

var secondName = PdfFormField
    .CreateText(pdf, new Rectangle(10, 140, 200, 50), "last-name")
    .SetValue("Last Name");

form.AddField(firstName);
form.AddField(secondName);

document.Close();


// **************************
// Create using HTML template
// **************************

var destination = "../../../../html-template.pdf";
var source = "../../../template.html";

HtmlConverter.ConvertToPdf(File.ReadAllText(source), new FileStream(destination, FileMode.OpenOrCreate));
