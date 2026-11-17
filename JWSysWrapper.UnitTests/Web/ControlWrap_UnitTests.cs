#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.IO;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl.Web;

namespace JWWrap.UnitTests.Web
{
    // ----------------------------------------------------
    /// <summary>
    ///     ControlWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class ControlWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void ID_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var control = new Control();
            var sut = new ControlWrap(control);

            // ---
            // Act

            sut.ID = "abc";

            // ------
            // Assert

            Assert.AreEqual("abc", sut.ID);
            Assert.AreEqual("abc", control.ID);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ClientID_IdSet_ReturnsId()
        {
            // -------
            // Arrange

            var control = new Control();
            var sut = new ControlWrap(control);

            control.ID = "abc";

            // ---
            // Act

            var result = sut.ClientID;

            // ------
            // Assert

            Assert.AreEqual("abc", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void UniqueID_IdSet_ReturnsId()
        {
            // -------
            // Arrange

            var control = new Control();
            var sut = new ControlWrap(control);

            control.ID = "abc";

            // ---
            // Act

            var result = sut.UniqueID;

            // ------
            // Assert

            Assert.AreEqual("abc", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void EnableTheming_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var control = new Control();
            var sut = new ControlWrap(control);

            // ---
            // Act

            sut.EnableTheming = false;

            // ------
            // Assert

            Assert.AreEqual(false, sut.EnableTheming);
            Assert.AreEqual(false, control.EnableTheming);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SkinID_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var control = new Control();
            var sut = new ControlWrap(control);

            // ---
            // Act

            sut.SkinID = "Skin";

            // ------
            // Assert

            Assert.AreEqual("Skin", sut.SkinID);
            Assert.AreEqual("Skin", control.SkinID);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void EnableViewState_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var control = new Control();
            var sut = new ControlWrap(control);

            // ---
            // Act

            sut.EnableViewState = false;

            // ------
            // Assert

            Assert.AreEqual(false, sut.EnableViewState);
            Assert.AreEqual(false, control.EnableViewState);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ViewStateMode_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var control = new Control();
            var sut = new ControlWrap(control);

            // ---
            // Act

            sut.ViewStateMode = ViewStateMode.Disabled;

            // ------
            // Assert

            Assert.AreEqual(ViewStateMode.Disabled, sut.ViewStateMode);
            Assert.AreEqual(ViewStateMode.Disabled, control.ViewStateMode);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ClientIDMode_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var control = new Control();
            var sut = new ControlWrap(control);

            // ---
            // Act

            sut.ClientIDMode = ClientIDMode.Static;

            // ------
            // Assert

            Assert.AreEqual(ClientIDMode.Static, sut.ClientIDMode);
            Assert.AreEqual(ClientIDMode.Static, control.ClientIDMode);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RenderingCompatibility_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var control = new Control();
            var sut = new ControlWrap(control);

            // ---
            // Act

            sut.RenderingCompatibility = new Version(4, 0);

            // ------
            // Assert

            Assert.AreEqual(new Version(4, 0), sut.RenderingCompatibility);
            Assert.AreEqual(new Version(4, 0), control.RenderingCompatibility);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Visible_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var control = new Control();
            var sut = new ControlWrap(control);

            // ---
            // Act

            sut.Visible = false;

            // ------
            // Assert

            Assert.AreEqual(false, sut.Visible);
            Assert.AreEqual(false, control.Visible);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ValidateRequestMode_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var control = new Control();
            var sut = new ControlWrap(control);

            // ---
            // Act

            sut.ValidateRequestMode = ValidateRequestMode.Enabled;

            // ------
            // Assert

            Assert.AreEqual(ValidateRequestMode.Enabled, sut.ValidateRequestMode);
            Assert.AreEqual(ValidateRequestMode.Enabled, control.ValidateRequestMode);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void TemplateControl_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var control = new Control();
            var sut = new ControlWrap(control);
            var template = new UserControl();

            // ---
            // Act

            sut.TemplateControl = template;

            // ------
            // Assert

            Assert.AreSame(template, sut.TemplateControl);
            Assert.AreSame(template, control.TemplateControl);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Page_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var control = new Control();
            var sut = new ControlWrap(control);
            var page = new Page();

            // ---
            // Act

            sut.Page = page;

            // ------
            // Assert

            Assert.AreSame(page, sut.Page);
            Assert.AreSame(page, control.Page);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Site_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var control = new Control();
            var sut = new ControlWrap(control);
            var site = new Mock<ISite>().Object;

            // ---
            // Act

            sut.Site = site;

            // ------
            // Assert

            Assert.AreSame(site, sut.Site);
            Assert.AreSame(site, control.Site);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void NamingContainer_ChildInContainer_WrapsContainer()
        {
            // -------
            // Arrange

            var container = new UserControl { ID = "container" };
            var child = new Label { ID = "child" };
            var sut = new ControlWrap(child);

            container.Controls.Add(child);

            // ---
            // Act

            var result = sut.NamingContainer;

            // ------
            // Assert

            Assert.AreEqual("container", result.ID);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void BindingContainer_Default_ReturnsWrapper()
        {
            // -------
            // Arrange

            var control = new Control();
            var sut = new ControlWrap(control);

            // ---
            // Act

            var result = sut.BindingContainer;

            // ------
            // Assert

            Assert.IsNotNull(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void DataItemContainer_Default_ReturnsWrapper()
        {
            // -------
            // Arrange

            var control = new Control();
            var sut = new ControlWrap(control);

            // ---
            // Act

            var result = sut.DataItemContainer;

            // ------
            // Assert

            Assert.IsNotNull(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void DataKeysContainer_Default_ReturnsWrapper()
        {
            // -------
            // Arrange

            var control = new Control();
            var sut = new ControlWrap(control);

            // ---
            // Act

            var result = sut.DataKeysContainer;

            // ------
            // Assert

            Assert.IsNotNull(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Parent_ChildInContainer_WrapsParent()
        {
            // -------
            // Arrange

            var container = new UserControl { ID = "container" };
            var child = new Label { ID = "child" };
            var sut = new ControlWrap(child);

            container.Controls.Add(child);

            // ---
            // Act

            var result = sut.Parent;

            // ------
            // Assert

            Assert.AreEqual("container", result.ID);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Controls_Children_ReturnsCollectionWrap()
        {
            // -------
            // Arrange

            var control = new Control();
            var sut = new ControlWrap(control);

            control.Controls.Add(new Control());

            // ---
            // Act

            var result = sut.Controls;

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(ControlCollectionWrap));
            Assert.AreEqual(1, result.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void FindControl_ExistingId_ReturnsWrapper()
        {
            // -------
            // Arrange

            var container = new UserControl();
            var child = new Label { ID = "child" };
            var sut = new ControlWrap(container);

            container.Controls.Add(child);

            // ---
            // Act

            var result = sut.FindControl("child");

            // ------
            // Assert

            Assert.AreEqual("child", result.ID);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ApplyStyleSheetSkin_NullPage_DoesNotThrow()
        {
            // -------
            // Arrange

            var control = new Control();
            var sut = new ControlWrap(control);

            // ------------
            // Act & Assert

            sut.ApplyStyleSheetSkin(null);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void DataBind_NoChildren_DoesNotThrow()
        {
            // -------
            // Arrange

            var control = new Control();
            var sut = new ControlWrap(control);

            // ------------
            // Act & Assert

            sut.DataBind();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Dispose_Called_DoesNotThrow()
        {
            // -------
            // Arrange

            var control = new Control();
            var sut = new ControlWrap(control);

            // ------------
            // Act & Assert

            sut.Dispose();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void HasControls_NoChildren_IsFalse()
        {
            // -------
            // Arrange

            var control = new Control();
            var sut = new ControlWrap(control);

            // ---
            // Act

            var result = sut.HasControls();

            // ------
            // Assert

            Assert.IsFalse(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void HasControls_WithChild_IsTrue()
        {
            // -------
            // Arrange

            var control = new Control();
            var sut = new ControlWrap(control);

            control.Controls.Add(new Control());

            // ---
            // Act

            var result = sut.HasControls();

            // ------
            // Assert

            Assert.IsTrue(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RenderControl_LiteralControl_WritesText()
        {
            // -------
            // Arrange

            var control = new LiteralControl("hello");
            var sut = new ControlWrap(control);
            var text = new StringWriter();
            var writer = new HtmlTextWriter(text);

            // ---
            // Act

            sut.RenderControl(writer);

            // ------
            // Assert

            Assert.AreEqual("hello", text.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SetRenderMethodDelegate_Delegate_UsedWhenRendering()
        {
            // -------
            // Arrange

            var control = new Control();
            var sut = new ControlWrap(control);
            var text = new StringWriter();
            var writer = new HtmlTextWriter(text);

            // ---
            // Act

            sut.SetRenderMethodDelegate((output, owner) => output.Write("custom"));
            sut.RenderControl(writer);

            // ------
            // Assert

            Assert.AreEqual("custom", text.ToString());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SetTraceData_KeyValue_DoesNotThrow()
        {
            // -------
            // Arrange

            var control = new Control();
            var sut = new ControlWrap(control);

            // ------------
            // Act & Assert

            sut.SetTraceData("key", "value");
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SetTraceData_ObjectKeyValue_DoesNotThrow()
        {
            // -------
            // Arrange

            var control = new Control();
            var sut = new ControlWrap(control);

            // ------------
            // Act & Assert

            sut.SetTraceData(control, "key", "value");
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ResolveClientUrl_AbsoluteUrl_ReturnsUnchanged()
        {
            // -------
            // Arrange

            var control = new Control();
            var sut = new ControlWrap(control);

            // ---
            // Act

            var result = sut.ResolveClientUrl("http://example.com/a");

            // ------
            // Assert

            Assert.AreEqual("http://example.com/a", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ResolveUrl_AbsoluteUrl_ReturnsUnchanged()
        {
            // -------
            // Arrange

            var control = new Control();
            var sut = new ControlWrap(control);

            // ---
            // Act

            var result = sut.ResolveUrl("http://example.com/a");

            // ------
            // Assert

            Assert.AreEqual("http://example.com/a", result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ExplicitToLabel_MatchingControl_ReturnsControl()
        {
            // -------
            // Arrange

            var control = new Label();
            var sut = new ControlWrap(control);

            // ---
            // Act

            var result = (Label) sut;

            // ------
            // Assert

            Assert.AreSame(control, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ExplicitToLabel_OtherControl_ReturnsNull()
        {
            // -------
            // Arrange

            var sut = new ControlWrap(new Panel());

            // ---
            // Act

            var result = (Label) sut;

            // ------
            // Assert

            Assert.IsNull(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ExplicitToTextBox_MatchingControl_ReturnsControl()
        {
            // -------
            // Arrange

            var control = new TextBox();
            var sut = new ControlWrap(control);

            // ---
            // Act

            var result = (TextBox) sut;

            // ------
            // Assert

            Assert.AreSame(control, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ExplicitToTextBox_OtherControl_ReturnsNull()
        {
            // -------
            // Arrange

            var sut = new ControlWrap(new Label());

            // ---
            // Act

            var result = (TextBox) sut;

            // ------
            // Assert

            Assert.IsNull(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ExplicitToCheckBox_MatchingControl_ReturnsControl()
        {
            // -------
            // Arrange

            var control = new CheckBox();
            var sut = new ControlWrap(control);

            // ---
            // Act

            var result = (CheckBox) sut;

            // ------
            // Assert

            Assert.AreSame(control, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ExplicitToCheckBox_OtherControl_ReturnsNull()
        {
            // -------
            // Arrange

            var sut = new ControlWrap(new Label());

            // ---
            // Act

            var result = (CheckBox) sut;

            // ------
            // Assert

            Assert.IsNull(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ExplicitToDropDownList_MatchingControl_ReturnsControl()
        {
            // -------
            // Arrange

            var control = new DropDownList();
            var sut = new ControlWrap(control);

            // ---
            // Act

            var result = (DropDownList) sut;

            // ------
            // Assert

            Assert.AreSame(control, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ExplicitToDropDownList_OtherControl_ReturnsNull()
        {
            // -------
            // Arrange

            var sut = new ControlWrap(new Label());

            // ---
            // Act

            var result = (DropDownList) sut;

            // ------
            // Assert

            Assert.IsNull(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ExplicitToDataControlFieldCell_MatchingControl_ReturnsControl()
        {
            // -------
            // Arrange

            var control = new DataControlFieldCell(null);
            var sut = new ControlWrap(control);

            // ---
            // Act

            var result = (DataControlFieldCell) sut;

            // ------
            // Assert

            Assert.AreSame(control, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ExplicitToDataControlFieldCell_OtherControl_ReturnsNull()
        {
            // -------
            // Arrange

            var sut = new ControlWrap(new Label());

            // ---
            // Act

            var result = (DataControlFieldCell) sut;

            // ------
            // Assert

            Assert.IsNull(result);
        }

        // ----------------------------------------------------

        private static Tuple<object, Type> Outcome(Func<object> action)
        {
            try
            {
                return Tuple.Create(action(), (Type) null);
            }
            catch(Exception ex)
            {
                return Tuple.Create((object) null, ex.GetType());
            }
        }

        // ----------------------------------------------------

        private static void AssertSameOutcome(Tuple<object, Type> expected, Tuple<object, Type> actual)
        {
            Assert.AreEqual(expected.Item2, actual.Item2);

            if(expected.Item1 == null || expected.Item1 is string || expected.Item1.GetType().IsValueType)
            {
                Assert.AreEqual(expected.Item1, actual.Item1);
            }
            else
            {
                Assert.IsNotNull(actual.Item1);
            }
        }

        // ----------------------------------------------------

        [TestMethod]
        public void TemplateSourceDirectory_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Control();
            var actualInstance = new System.Web.UI.Control();
            var sut = new ControlWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.TemplateSourceDirectory);
            var actual = Outcome(() => (object) sut.TemplateSourceDirectory);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AppRelativeTemplateSourceDirectory_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Control();
            var actualInstance = new System.Web.UI.Control();
            var sut = new ControlWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.AppRelativeTemplateSourceDirectory);
            var actual = Outcome(() => (object) sut.AppRelativeTemplateSourceDirectory);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AppRelativeTemplateSourceDirectory_Set_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Control();
            var actualInstance = new System.Web.UI.Control();
            var sut = new ControlWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.AppRelativeTemplateSourceDirectory = "~/"; return null; });
            var actual = Outcome(() => { sut.AppRelativeTemplateSourceDirectory = "~/"; return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Focus_NoPage_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Control();
            var actualInstance = new System.Web.UI.Control();
            var sut = new ControlWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.Focus(); return null; });
            var actual = Outcome(() => { sut.Focus(); return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetRouteUrl_NameAndDictionary_MatchesInstance()
        {
            // -------
            // Arrange

            var values = new System.Web.Routing.RouteValueDictionary();
            var expectedInstance = new System.Web.UI.Control();
            var actualInstance = new System.Web.UI.Control();
            var sut = new ControlWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.GetRouteUrl("route", values));
            var actual = Outcome(() => (object) sut.GetRouteUrl("route", values));

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetRouteUrl_NameAndObject_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Control();
            var actualInstance = new System.Web.UI.Control();
            var sut = new ControlWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.GetRouteUrl("route", (object) new { id = 1 }));
            var actual = Outcome(() => (object) sut.GetRouteUrl("route", (object) new { id = 1 }));

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetRouteUrl_Dictionary_MatchesInstance()
        {
            // -------
            // Arrange

            var values = new System.Web.Routing.RouteValueDictionary();
            var expectedInstance = new System.Web.UI.Control();
            var actualInstance = new System.Web.UI.Control();
            var sut = new ControlWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.GetRouteUrl(values));
            var actual = Outcome(() => (object) sut.GetRouteUrl(values));

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetRouteUrl_Object_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Control();
            var actualInstance = new System.Web.UI.Control();
            var sut = new ControlWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.GetRouteUrl((object) new { id = 1 }));
            var actual = Outcome(() => (object) sut.GetRouteUrl((object) new { id = 1 }));

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetUniqueIDRelativeTo_Control_MatchesInstance()
        {
            // -------
            // Arrange

            var other = new System.Web.UI.Control();
            var expectedInstance = new System.Web.UI.Control();
            var actualInstance = new System.Web.UI.Control();
            var sut = new ControlWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.GetUniqueIDRelativeTo(other));
            var actual = Outcome(() => (object) sut.GetUniqueIDRelativeTo(other));

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }
    }
}
