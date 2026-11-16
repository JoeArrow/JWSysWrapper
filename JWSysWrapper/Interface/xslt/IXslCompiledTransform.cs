using System;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Reflection;
using System.CodeDom.Compiler;

namespace JWWrap.Interface.Xslt
{
    public interface IXslCompiledTransform
    {
        XmlWriterSettings OutputSettings { get; }
        TempFileCollection TemporaryFiles { get; }

        void Load(IXPathNavigable stylesheet);
        void Load(IXPathNavigable stylesheet, XsltSettings settings, XmlResolver stylesheetResolver);
        void Load(string stylesheetUri);
        void Load(string stylesheetUri, XsltSettings settings, XmlResolver stylesheetResolver);
        void Load(Type compiledStylesheet);
        void Load(MethodInfo executeMethod, byte[] queryData, Type[] earlyBoundTypes);
        void Load(XmlReader stylesheet);
        void Load(XmlReader stylesheet, XsltSettings settings, XmlResolver stylesheetResolver);
        void Transform(IXPathNavigable input, XsltArgumentList arguments, XmlWriter results, XmlResolver documentResolver);
        void Transform(XmlReader input, XsltArgumentList arguments, XmlWriter results, XmlResolver documentResolver);
        void Transform(string inputUri, string resultsFile);
        void Transform(string inputUri, XsltArgumentList arguments, Stream results);
        void Transform(string inputUri, XsltArgumentList arguments, TextWriter results);
        void Transform(string inputUri, XsltArgumentList arguments, XmlWriter results);
        void Transform(XmlReader input, XmlWriter results);
        void Transform(XmlReader input, XsltArgumentList arguments, Stream results);
        void Transform(XmlReader input, XsltArgumentList arguments, TextWriter results);
        void Transform(XmlReader input, XsltArgumentList arguments, XmlWriter results);
        void Transform(IXPathNavigable input, XsltArgumentList arguments, Stream results);
        void Transform(IXPathNavigable input, XsltArgumentList arguments, XmlWriter results);
        void Transform(IXPathNavigable input, XmlWriter results);
        void Transform(string inputUri, XmlWriter results);
        void Transform(IXPathNavigable input, XsltArgumentList arguments, TextWriter results);
    }
}
