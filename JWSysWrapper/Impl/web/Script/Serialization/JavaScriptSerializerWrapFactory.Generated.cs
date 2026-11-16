#pragma warning disable 1591

namespace JWWrap.Impl.Script.Serialization
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Web.Script.Serialization;

    using JWWrap.Attributes;
    using JWWrap.Web.Script.Serialization;

    /// <summary>
    /// The implementation for the factory generating <see cref="JWWrap.Impl.Script.Serialization.JavaScriptSerializerWrap" /> instances.
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("DeveloperInTheFlow.FactoryGenerator", "1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public partial class JavaScriptSerializerWrapFactory : JWWrap.Web.Script.Serialization.IJavaScriptSerializerFactory
    {
        #region Public Factory Methods

        public JWWrap.Web.Script.Serialization.IJavaScriptSerializer Create()
        {
            return new JWWrap.Impl.Script.Serialization.JavaScriptSerializerWrap();
        }

        public JWWrap.Web.Script.Serialization.IJavaScriptSerializer Create(System.Web.Script.Serialization.JavaScriptTypeResolver resolver)
        {
            return new JWWrap.Impl.Script.Serialization.JavaScriptSerializerWrap(resolver);
        }

        #endregion
    }
}