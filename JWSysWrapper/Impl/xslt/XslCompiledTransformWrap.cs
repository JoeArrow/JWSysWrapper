#region © 2020 Aflac.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

namespace JWWrap.Impl.Xslt
{
    using System;
    using System.IO;
    using System.Xml;
    using System.Xml.Xsl;
    using System.Xml.XPath;
    using System.Reflection;
    using System.CodeDom.Compiler;

    using JWWrap.Interface.Xslt;

    // ----------------------------------------------------
    /// <summary>
    ///     XslCompiledTransformWrap Description
    /// </summary>

    public class XslCompiledTransformWrap : IXslCompiledTransform
    {
        private readonly XslCompiledTransform instance;
     
        // ------------------------------------------------

        public XslCompiledTransformWrap()
        {
            instance = new XslCompiledTransform();
        }
     
        // ------------------------------------------------

        public XslCompiledTransformWrap(bool enableDebug)
        {
            instance = new XslCompiledTransform(enableDebug);
        }

        public XmlWriterSettings OutputSettings => instance.OutputSettings;

        public TempFileCollection TemporaryFiles => instance.TemporaryFiles;

        // ------------------------------------------------

        public void Load(IXPathNavigable stylesheet)
        {
            instance.Load(stylesheet);
        }

        // ------------------------------------------------

        public void Load(IXPathNavigable stylesheet, XsltSettings settings, XmlResolver stylesheetResolver)
        {
            instance.Load(stylesheet, settings, stylesheetResolver);
        }

        // ------------------------------------------------

        public void Load(string stylesheetUri)
        {
            instance.Load(stylesheetUri);
        }

        // ------------------------------------------------

        public void Load(string stylesheetUri, XsltSettings settings, XmlResolver stylesheetResolver)
        {
            instance.Load(stylesheetUri, settings, stylesheetResolver);
        }

        // ------------------------------------------------

        public void Load(Type compiledStylesheet)
        {
            instance.Load(compiledStylesheet);
        }

        // ------------------------------------------------

        public void Load(MethodInfo executeMethod, byte[] queryData, Type[] earlyBoundTypes)
        {
            instance.Load(executeMethod, queryData, earlyBoundTypes);
        }

        // ------------------------------------------------

        public void Load(XmlReader stylesheet)
        {
            instance.Load(stylesheet);
        }

        // ------------------------------------------------

        public void Load(XmlReader stylesheet, XsltSettings settings, XmlResolver stylesheetResolver)
        {
            instance.Load(stylesheet, settings, stylesheetResolver);
        }

        // ------------------------------------------------

        public void Transform(IXPathNavigable input, XsltArgumentList arguments, XmlWriter results, XmlResolver documentResolver)
        {
            instance.Transform(input, arguments, results, documentResolver);
        }

        // ------------------------------------------------

        public void Transform(XmlReader input, XsltArgumentList arguments, XmlWriter results, XmlResolver documentResolver)
        {
            instance.Transform(input, arguments, results, documentResolver);
        }

        // ------------------------------------------------

        public void Transform(string inputUri, string resultsFile)
        {
            instance.Transform(inputUri, resultsFile);
        }

        // ------------------------------------------------

        public void Transform(string inputUri, XsltArgumentList arguments, Stream results)
        {
            instance.Transform(inputUri, arguments, results);
        }

        // ------------------------------------------------

        public void Transform(string inputUri, XsltArgumentList arguments, TextWriter results)
        {
            instance.Transform(inputUri, arguments, results);
        }

        // ------------------------------------------------

        public void Transform(string inputUri, XsltArgumentList arguments, XmlWriter results)
        {
            instance.Transform(inputUri, arguments, results);
        }

        // ------------------------------------------------

        public void Transform(XmlReader input, XmlWriter results)
        {
            instance.Transform(input, results);
        }

        // ------------------------------------------------

        public void Transform(XmlReader input, XsltArgumentList arguments, Stream results)
        {
            instance.Transform(input, arguments, results);
        }

        // ------------------------------------------------

        public void Transform(XmlReader input, XsltArgumentList arguments, TextWriter results)
        {
            instance.Transform(input, arguments, results);
        }

        // ------------------------------------------------

        public void Transform(XmlReader input, XsltArgumentList arguments, XmlWriter results)
        {
            instance.Transform(input, arguments, results);
        }

        // ------------------------------------------------

        public void Transform(IXPathNavigable input, XsltArgumentList arguments, Stream results)
        {
            instance.Transform(input, arguments, results);
        }

        // ------------------------------------------------

        public void Transform(IXPathNavigable input, XsltArgumentList arguments, XmlWriter results)
        {
            instance.Transform(input, arguments, results);
        }

        // ------------------------------------------------

        public void Transform(IXPathNavigable input, XmlWriter results)
        {
            instance.Transform(input, results);
        }

        // ------------------------------------------------

        public void Transform(string inputUri, XmlWriter results)
        {
            instance.Transform(inputUri, results);
        }

        // ------------------------------------------------

        public void Transform(IXPathNavigable input, XsltArgumentList arguments, TextWriter results)
        {
            instance.Transform(input, arguments, results);
        }
    }
}
