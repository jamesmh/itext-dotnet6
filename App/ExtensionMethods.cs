using iText.Layout;
using iText.Layout.Element;

namespace App
{
    public static class ExtensionMethods
    {
        public static Document AddSpacer(this Document document) =>
            document.Add(new Paragraph().SetMinHeight(20));
    }
}
