#region © 2022 Aflac.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.Xml;

namespace JWWrap.Interface.Xml
{
    public interface IXmlDocumentFragment
    {
        XmlDocumentFragment Instance { get; }
        string Name { get; }
        string LocalName { get; }
        XmlNodeType NodeType { get; }
        XmlNode ParentNode { get; }
        XmlDocument OwnerDocument { get; }
        string InnerXml { get; set; }

        XmlNode CloneNode(bool deep);
        void WriteContentTo(XmlWriter w);
        void WriteTo(XmlWriter w);
    }
}
