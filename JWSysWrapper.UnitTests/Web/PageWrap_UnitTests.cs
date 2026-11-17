#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl.Web;

namespace JWWrap.UnitTests.Web
{
    // ----------------------------------------------------
    /// <summary>
    ///     PageWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class PageWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Default_CreatesPage()
        {
            // ---
            // Act

            var sut = new PageWrap();

            // ------
            // Assert

            Assert.IsNotNull(sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Page_WrapsInstance()
        {
            // -------
            // Arrange

            var page = new Page();

            // ---
            // Act

            var sut = new PageWrap(page);

            // ------
            // Assert

            Assert.AreSame(page, sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Theme_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var page = new Page();
            var sut = new PageWrap(page);

            // ---
            // Act

            sut.Theme = "Dark";

            // ------
            // Assert

            Assert.AreEqual("Dark", sut.Theme);
            Assert.AreEqual("Dark", page.Theme);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void MaxPageStateFieldLength_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var page = new Page();
            var sut = new PageWrap(page);

            // ---
            // Act

            sut.MaxPageStateFieldLength = 1000;

            // ------
            // Assert

            Assert.AreEqual(1000, sut.MaxPageStateFieldLength);
            Assert.AreEqual(1000, page.MaxPageStateFieldLength);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void MaintainScrollPositionOnPostBack_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var page = new Page();
            var sut = new PageWrap(page);

            // ---
            // Act

            sut.MaintainScrollPositionOnPostBack = true;

            // ------
            // Assert

            Assert.AreEqual(true, sut.MaintainScrollPositionOnPostBack);
            Assert.AreEqual(true, page.MaintainScrollPositionOnPostBack);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void EnableEventValidation_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var page = new Page();
            var sut = new PageWrap(page);

            // ---
            // Act

            sut.EnableEventValidation = false;

            // ------
            // Assert

            Assert.AreEqual(false, sut.EnableEventValidation);
            Assert.AreEqual(false, page.EnableEventValidation);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AsyncTimeout_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var page = new Page();
            var sut = new PageWrap(page);

            // ---
            // Act

            sut.AsyncTimeout = TimeSpan.FromSeconds(10);

            // ------
            // Assert

            Assert.AreEqual(TimeSpan.FromSeconds(10), sut.AsyncTimeout);
            Assert.AreEqual(TimeSpan.FromSeconds(10), page.AsyncTimeout);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Visible_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var page = new Page();
            var sut = new PageWrap(page);

            // ---
            // Act

            sut.Visible = false;

            // ------
            // Assert

            Assert.AreEqual(false, sut.Visible);
            Assert.AreEqual(false, page.Visible);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ID_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var page = new Page();
            var sut = new PageWrap(page);

            // ---
            // Act

            sut.ID = "page1";

            // ------
            // Assert

            Assert.AreEqual("page1", sut.ID);
            Assert.AreEqual("page1", page.ID);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ViewStateUserKey_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var page = new Page();
            var sut = new PageWrap(page);

            // ---
            // Act

            sut.ViewStateUserKey = "key";

            // ------
            // Assert

            Assert.AreEqual("key", sut.ViewStateUserKey);
            Assert.AreEqual("key", page.ViewStateUserKey);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ViewStateEncryptionMode_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var page = new Page();
            var sut = new PageWrap(page);

            // ---
            // Act

            sut.ViewStateEncryptionMode = ViewStateEncryptionMode.Always;

            // ------
            // Assert

            Assert.AreEqual(ViewStateEncryptionMode.Always, sut.ViewStateEncryptionMode);
            Assert.AreEqual(ViewStateEncryptionMode.Always, page.ViewStateEncryptionMode);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void UnobtrusiveValidationMode_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var page = new Page();
            var sut = new PageWrap(page);

            // ---
            // Act

            sut.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            // ------
            // Assert

            Assert.AreEqual(UnobtrusiveValidationMode.None, sut.UnobtrusiveValidationMode);
            Assert.AreEqual(UnobtrusiveValidationMode.None, page.UnobtrusiveValidationMode);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SkipFormActionValidation_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var page = new Page();
            var sut = new PageWrap(page);

            // ---
            // Act

            sut.SkipFormActionValidation = true;

            // ------
            // Assert

            Assert.AreEqual(true, sut.SkipFormActionValidation);
            Assert.AreEqual(true, page.SkipFormActionValidation);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ValidateRequestMode_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var page = new Page();
            var sut = new PageWrap(page);

            // ---
            // Act

            sut.ValidateRequestMode = ValidateRequestMode.Enabled;

            // ------
            // Assert

            Assert.AreEqual(ValidateRequestMode.Enabled, sut.ValidateRequestMode);
            Assert.AreEqual(ValidateRequestMode.Enabled, page.ValidateRequestMode);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void EnableViewState_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var page = new Page();
            var sut = new PageWrap(page);

            // ---
            // Act

            sut.EnableViewState = false;

            // ------
            // Assert

            Assert.AreEqual(false, sut.EnableViewState);
            Assert.AreEqual(false, page.EnableViewState);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void EnableViewState_ThroughInterface_UpdatesInstance()
        {
            // -------
            // Arrange

            var page = new Page();
            var sut = new PageWrap(page);

            // ---
            // Act

            ((JWWrap.Interface.Web.IPage) sut).EnableViewState = false;

            // ------
            // Assert

            Assert.IsFalse(page.EnableViewState);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ErrorPage_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var page = new Page();
            var sut = new PageWrap(page);

            // ---
            // Act

            sut.ErrorPage = "error.aspx";

            // ------
            // Assert

            Assert.AreEqual("error.aspx", sut.ErrorPage);
            Assert.AreEqual("error.aspx", page.ErrorPage);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AutoPostBackControl_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var page = new Page();
            var sut = new PageWrap(page);
            var control = new Control();

            // ---
            // Act

            sut.AutoPostBackControl = control;

            // ------
            // Assert

            Assert.AreSame(control, sut.AutoPostBackControl);
            Assert.AreSame(control, page.AutoPostBackControl);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ClientScript_Get_ReturnsInstanceManager()
        {
            // -------
            // Arrange

            var page = new Page();
            var sut = new PageWrap(page);

            // ---
            // Act

            var result = sut.ClientScript;

            // ------
            // Assert

            Assert.IsNotNull(result);
            Assert.AreSame(page.ClientScript, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ModelState_Get_ReturnsInstanceState()
        {
            // -------
            // Arrange

            var page = new Page();
            var sut = new PageWrap(page);

            // ---
            // Act

            var result = sut.ModelState;

            // ------
            // Assert

            Assert.IsNotNull(result);
            Assert.AreSame(page.ModelState, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Validators_Get_ReturnsInstanceValidators()
        {
            // -------
            // Arrange

            var page = new Page();
            var sut = new PageWrap(page);

            // ---
            // Act

            var result = sut.Validators;

            // ------
            // Assert

            Assert.IsNotNull(result);
            Assert.AreSame(page.Validators, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IsReusable_Page_MatchesInstance()
        {
            // -------
            // Arrange

            var page = new Page();
            var sut = new PageWrap(page);

            // ---
            // Act

            var result = sut.IsReusable;

            // ------
            // Assert

            Assert.AreEqual(page.IsReusable, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IsAsync_Page_IsFalse()
        {
            // -------
            // Arrange

            var page = new Page();
            var sut = new PageWrap(page);

            // ---
            // Act

            var result = sut.IsAsync;

            // ------
            // Assert

            Assert.IsFalse(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IsCallback_Page_IsFalse()
        {
            // -------
            // Arrange

            var page = new Page();
            var sut = new PageWrap(page);

            // ---
            // Act

            var result = sut.IsCallback;

            // ------
            // Assert

            Assert.IsFalse(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IsPostBack_NoRequest_MatchesInstance()
        {
            // -------
            // Arrange

            var page = new Page();
            var sut = new PageWrap(page);

            // ---
            // Act

            var result = sut.IsPostBack;

            // ------
            // Assert

            Assert.AreEqual(page.IsPostBack, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IsPostBackEventControlRegistered_NewPage_IsFalse()
        {
            // -------
            // Arrange

            var page = new Page();
            var sut = new PageWrap(page);

            // ---
            // Act

            var result = sut.IsPostBackEventControlRegistered;

            // ------
            // Assert

            Assert.IsFalse(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IdSeparator_Page_MatchesInstance()
        {
            // -------
            // Arrange

            var page = new Page();
            var sut = new PageWrap(page);

            // ---
            // Act

            var result = sut.IdSeparator;

            // ------
            // Assert

            Assert.AreEqual(page.IdSeparator, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetTypeHashCode_Page_MatchesInstance()
        {
            // -------
            // Arrange

            var page = new Page();
            var sut = new PageWrap(page);

            // ---
            // Act

            var result = sut.GetTypeHashCode();

            // ------
            // Assert

            Assert.AreEqual(page.GetTypeHashCode(), result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void FindControl_ExistingId_ReturnsControl()
        {
            // -------
            // Arrange

            var page = new Page();
            var sut = new PageWrap(page);
            var child = new Label { ID = "child" };

            page.Controls.Add(child);

            // ---
            // Act

            var result = sut.FindControl("child");

            // ------
            // Assert

            Assert.AreSame(child, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Validate_NoValidators_PageIsValid()
        {
            // -------
            // Arrange

            var page = new Page();
            var sut = new PageWrap(page);

            // ---
            // Act

            sut.Validate();

            // ------
            // Assert

            Assert.IsTrue(page.IsValid);
            Assert.IsTrue(sut.IsValid);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Validate_Group_PageIsValid()
        {
            // -------
            // Arrange

            var page = new Page();
            var sut = new PageWrap(page);

            // ---
            // Act

            sut.Validate("group");

            // ------
            // Assert

            Assert.IsTrue(page.IsValid);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetValidators_Group_ReturnsEmptyCollection()
        {
            // -------
            // Arrange

            var page = new Page();
            var sut = new PageWrap(page);

            // ---
            // Act

            var result = sut.GetValidators("group");

            // ------
            // Assert

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void DesignerInitialize_Called_DoesNotThrow()
        {
            // -------
            // Arrange

            var page = new Page();
            var sut = new PageWrap(page);

            // ------------
            // Act & Assert

            sut.DesignerInitialize();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ExecuteRegisteredAsyncTasks_NoTasks_DoesNotThrow()
        {
            // -------
            // Arrange

            var page = new Page();
            var sut = new PageWrap(page);

            // ------------
            // Act & Assert

            sut.ExecuteRegisteredAsyncTasks();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RegisterClientScriptBlock_Script_IsRegistered()
        {
            // -------
            // Arrange

            var page = new Page();
            var sut = new PageWrap(page);

            // ---
            // Act

            sut.RegisterClientScriptBlock("key", "alert(1);");

            // ------
            // Assert

            Assert.IsTrue(sut.IsClientScriptBlockRegistered("key"));
            Assert.IsFalse(sut.IsClientScriptBlockRegistered("other"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RegisterStartupScript_Script_IsRegistered()
        {
            // -------
            // Arrange

            var page = new Page();
            var sut = new PageWrap(page);

            // ---
            // Act

            sut.RegisterStartupScript("key", "alert(1);");

            // ------
            // Assert

            Assert.IsTrue(sut.IsStartupScriptRegistered("key"));
            Assert.IsFalse(sut.IsStartupScriptRegistered("other"));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RegisterArrayDeclaration_NameValue_DoesNotThrow()
        {
            // -------
            // Arrange

            var page = new Page();
            var sut = new PageWrap(page);

            // ------------
            // Act & Assert

            sut.RegisterArrayDeclaration("items", "1");
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RegisterHiddenField_NameValue_DoesNotThrow()
        {
            // -------
            // Arrange

            var page = new Page();
            var sut = new PageWrap(page);

            // ------------
            // Act & Assert

            sut.RegisterHiddenField("hidden", "1");
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RegisterOnSubmitStatement_Script_DoesNotThrow()
        {
            // -------
            // Arrange

            var page = new Page();
            var sut = new PageWrap(page);

            // ------------
            // Act & Assert

            sut.RegisterOnSubmitStatement("key", "return true;");
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RegisterRequiresControlState_Control_IsRequired()
        {
            // -------
            // Arrange

            var page = new Page();
            var sut = new PageWrap(page);
            var control = new Control();

            // ---
            // Act

            sut.RegisterRequiresControlState(control);

            // ------
            // Assert

            Assert.IsTrue(sut.RequiresControlState(control));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void UnregisterRequiresControlState_Control_IsNoLongerRequired()
        {
            // -------
            // Arrange

            var page = new Page();
            var sut = new PageWrap(page);
            var control = new Control();

            sut.RegisterRequiresControlState(control);

            // ---
            // Act

            sut.UnregisterRequiresControlState(control);

            // ------
            // Assert

            Assert.IsFalse(sut.RequiresControlState(control));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RegisterRequiresRaiseEvent_Handler_MarksRegistered()
        {
            // -------
            // Arrange

            var page = new Page();
            var sut = new PageWrap(page);
            var handler = new Mock<IPostBackEventHandler>().Object;

            // ---
            // Act

            sut.RegisterRequiresRaiseEvent(handler);

            // ------
            // Assert

            Assert.IsTrue(sut.IsPostBackEventControlRegistered);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RegisterRequiresViewStateEncryption_Called_DoesNotThrow()
        {
            // -------
            // Arrange

            var page = new Page();
            var sut = new PageWrap(page);

            // ------------
            // Act & Assert

            sut.RegisterRequiresViewStateEncryption();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RegisterViewStateHandler_Called_DoesNotThrow()
        {
            // -------
            // Arrange

            var page = new Page();
            var sut = new PageWrap(page);

            // ------------
            // Act & Assert

            sut.RegisterViewStateHandler();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CreateHtmlTextWriterFromType_HtmlWriter_ReturnsWriter()
        {
            // ---
            // Act

            var result = PageWrap.CreateHtmlTextWriterFromType(new StringWriter(), typeof(HtmlTextWriter));

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(HtmlTextWriter));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CreateHtmlTextWriterFromType_Html32Writer_ReturnsWriter()
        {
            // ---
            // Act

            var result = PageWrap.CreateHtmlTextWriterFromType(new StringWriter(), typeof(Html32TextWriter));

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(Html32TextWriter));
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
        public void StyleSheetTheme_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.StyleSheetTheme);
            var actual = Outcome(() => (object) sut.StyleSheetTheme);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void MetaKeywords_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.MetaKeywords);
            var actual = Outcome(() => (object) sut.MetaKeywords);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void MetaDescription_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.MetaDescription);
            var actual = Outcome(() => (object) sut.MetaDescription);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Title_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.Title);
            var actual = Outcome(() => (object) sut.Title);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Session_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.Session);
            var actual = Outcome(() => (object) sut.Session);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Cache_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.Cache);
            var actual = Outcome(() => (object) sut.Cache);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Server_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.Server);
            var actual = Outcome(() => (object) sut.Server);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RouteData_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.RouteData);
            var actual = Outcome(() => (object) sut.RouteData);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Response_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.Response);
            var actual = Outcome(() => (object) sut.Response);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Request_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.Request);
            var actual = Outcome(() => (object) sut.Request);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Trace_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.Trace);
            var actual = Outcome(() => (object) sut.Trace);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void MasterPageFile_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.MasterPageFile);
            var actual = Outcome(() => (object) sut.MasterPageFile);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Master_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.Master);
            var actual = Outcome(() => (object) sut.Master);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Header_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.Header);
            var actual = Outcome(() => (object) sut.Header);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ClientQueryString_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.ClientQueryString);
            var actual = Outcome(() => (object) sut.ClientQueryString);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ClientTarget_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.ClientTarget);
            var actual = Outcome(() => (object) sut.ClientTarget);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Application_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.Application);
            var actual = Outcome(() => (object) sut.Application);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void User_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.User);
            var actual = Outcome(() => (object) sut.User);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IsCrossPagePostBack_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.IsCrossPagePostBack);
            var actual = Outcome(() => (object) sut.IsCrossPagePostBack);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ModelBindingExecutionContext_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.ModelBindingExecutionContext);
            var actual = Outcome(() => (object) sut.ModelBindingExecutionContext);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Items_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.Items);
            var actual = Outcome(() => (object) sut.Items);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void PageAdapter_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.PageAdapter);
            var actual = Outcome(() => (object) sut.PageAdapter);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Form_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.Form);
            var actual = Outcome(() => (object) sut.Form);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SmartNavigation_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.SmartNavigation);
            var actual = Outcome(() => (object) sut.SmartNavigation);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void EnableViewStateMac_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.EnableViewStateMac);
            var actual = Outcome(() => (object) sut.EnableViewStateMac);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void TraceModeValue_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.TraceModeValue);
            var actual = Outcome(() => (object) sut.TraceModeValue);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void TraceEnabled_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.TraceEnabled);
            var actual = Outcome(() => (object) sut.TraceEnabled);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void UICulture_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.UICulture);
            var actual = Outcome(() => (object) sut.UICulture);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void LCID_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.LCID);
            var actual = Outcome(() => (object) sut.LCID);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Culture_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.Culture);
            var actual = Outcome(() => (object) sut.Culture);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ResponseEncoding_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.ResponseEncoding);
            var actual = Outcome(() => (object) sut.ResponseEncoding);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CodePage_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.CodePage);
            var actual = Outcome(() => (object) sut.CodePage);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ContentType_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.ContentType);
            var actual = Outcome(() => (object) sut.ContentType);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Buffer_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.Buffer);
            var actual = Outcome(() => (object) sut.Buffer);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void PreviousPage_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.PreviousPage);
            var actual = Outcome(() => (object) sut.PreviousPage);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void StyleSheetTheme_Set_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.StyleSheetTheme = "t"; return null; });
            var actual = Outcome(() => { sut.StyleSheetTheme = "t"; return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void MetaKeywords_Set_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.MetaKeywords = "k"; return null; });
            var actual = Outcome(() => { sut.MetaKeywords = "k"; return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void MetaDescription_Set_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.MetaDescription = "d"; return null; });
            var actual = Outcome(() => { sut.MetaDescription = "d"; return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Title_Set_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.Title = "t"; return null; });
            var actual = Outcome(() => { sut.Title = "t"; return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void MasterPageFile_Set_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.MasterPageFile = "~/m.master"; return null; });
            var actual = Outcome(() => { sut.MasterPageFile = "~/m.master"; return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ClientTarget_Set_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.ClientTarget = "uplevel"; return null; });
            var actual = Outcome(() => { sut.ClientTarget = "uplevel"; return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SmartNavigation_Set_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.SmartNavigation = true; return null; });
            var actual = Outcome(() => { sut.SmartNavigation = true; return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void EnableViewStateMac_Set_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.EnableViewStateMac = false; return null; });
            var actual = Outcome(() => { sut.EnableViewStateMac = false; return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void TraceModeValue_Set_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.TraceModeValue = System.Web.TraceMode.SortByTime; return null; });
            var actual = Outcome(() => { sut.TraceModeValue = System.Web.TraceMode.SortByTime; return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void TraceEnabled_Set_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.TraceEnabled = true; return null; });
            var actual = Outcome(() => { sut.TraceEnabled = true; return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void UICulture_Set_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.UICulture = "en-US"; return null; });
            var actual = Outcome(() => { sut.UICulture = "en-US"; return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void LCID_Set_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.LCID = 1033; return null; });
            var actual = Outcome(() => { sut.LCID = 1033; return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Culture_Set_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.Culture = "en-US"; return null; });
            var actual = Outcome(() => { sut.Culture = "en-US"; return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ResponseEncoding_Set_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.ResponseEncoding = "utf-8"; return null; });
            var actual = Outcome(() => { sut.ResponseEncoding = "utf-8"; return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CodePage_Set_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.CodePage = 65001; return null; });
            var actual = Outcome(() => { sut.CodePage = 65001; return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ContentType_Set_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.ContentType = "text/plain"; return null; });
            var actual = Outcome(() => { sut.ContentType = "text/plain"; return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Buffer_Set_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.Buffer = false; return null; });
            var actual = Outcome(() => { sut.Buffer = false; return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IPage_EnableViewState_Get_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.EnableViewState);
            var actual = Outcome(() => (object) ((JWWrap.Interface.Web.IPage) sut).EnableViewState);

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AddOnPreRenderCompleteAsync_NoContext_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.AddOnPreRenderCompleteAsync((s, e, cb, st) => null, ar => { }); return null; });
            var actual = Outcome(() => { sut.AddOnPreRenderCompleteAsync((s, e, cb, st) => null, ar => { }); return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AddOnPreRenderCompleteAsyncWithState_NoContext_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.AddOnPreRenderCompleteAsync((s, e, cb, st) => null, ar => { }, null); return null; });
            var actual = Outcome(() => { sut.AddOnPreRenderCompleteAsync((s, e, cb, st) => null, ar => { }, null); return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetDataItem_NoContext_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.GetDataItem());
            var actual = Outcome(() => (object) sut.GetDataItem());

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetPostBackClientEvent_NoContext_MatchesInstance()
        {
            // -------
            // Arrange

            var control = new System.Web.UI.Control();
            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.GetPostBackClientEvent(control, "arg"));
            var actual = Outcome(() => (object) sut.GetPostBackClientEvent(control, "arg"));

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetPostBackClientHyperlink_NoContext_MatchesInstance()
        {
            // -------
            // Arrange

            var control = new System.Web.UI.Control();
            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.GetPostBackClientHyperlink(control, "arg"));
            var actual = Outcome(() => (object) sut.GetPostBackClientHyperlink(control, "arg"));

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetPostBackEventReferenceWithArgument_NoContext_MatchesInstance()
        {
            // -------
            // Arrange

            var control = new System.Web.UI.Control();
            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.GetPostBackEventReference(control, "arg"));
            var actual = Outcome(() => (object) sut.GetPostBackEventReference(control, "arg"));

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetPostBackEventReference_NoContext_MatchesInstance()
        {
            // -------
            // Arrange

            var control = new System.Web.UI.Control();
            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.GetPostBackEventReference(control));
            var actual = Outcome(() => (object) sut.GetPostBackEventReference(control));

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void MapPath_NoContext_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.MapPath("~/page.aspx"));
            var actual = Outcome(() => (object) sut.MapPath("~/page.aspx"));

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ProcessRequest_NoContext_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.ProcessRequest((System.Web.HttpContext) null); return null; });
            var actual = Outcome(() => { sut.ProcessRequest((System.Web.HttpContext) null); return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RegisterAsyncTask_NoContext_MatchesInstance()
        {
            // -------
            // Arrange

            var task = new System.Web.UI.PageAsyncTask((s, e, cb, st) => null, ar => { }, ar => { }, null);
            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.RegisterAsyncTask(task); return null; });
            var actual = Outcome(() => { sut.RegisterAsyncTask(task); return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RegisterRequiresPostBack_NoContext_MatchesInstance()
        {
            // -------
            // Arrange

            var control = new System.Web.UI.Control();
            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.RegisterRequiresPostBack(control); return null; });
            var actual = Outcome(() => { sut.RegisterRequiresPostBack(control); return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SetFocusControl_NoContext_MatchesInstance()
        {
            // -------
            // Arrange

            var control = new System.Web.UI.Control();
            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.SetFocus(control); return null; });
            var actual = Outcome(() => { sut.SetFocus(control); return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SetFocusClientId_NoContext_MatchesInstance()
        {
            // -------
            // Arrange

            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.SetFocus("clientId"); return null; });
            var actual = Outcome(() => { sut.SetFocus("clientId"); return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void TryUpdateModelWithProvider_NoContext_MatchesInstance()
        {
            // -------
            // Arrange

            var model = new object();
            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.TryUpdateModel<object>(model, (System.Web.ModelBinding.IValueProvider) null));
            var actual = Outcome(() => (object) sut.TryUpdateModel<object>(model, (System.Web.ModelBinding.IValueProvider) null));

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void TryUpdateModel_NoContext_MatchesInstance()
        {
            // -------
            // Arrange

            var model = new object();
            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => (object) expectedInstance.TryUpdateModel<object>(model));
            var actual = Outcome(() => (object) sut.TryUpdateModel<object>(model));

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void UpdateModelWithProvider_NoContext_MatchesInstance()
        {
            // -------
            // Arrange

            var model = new object();
            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.UpdateModel<object>(model, (System.Web.ModelBinding.IValueProvider) null); return null; });
            var actual = Outcome(() => { sut.UpdateModel<object>(model, (System.Web.ModelBinding.IValueProvider) null); return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void UpdateModel_NoContext_MatchesInstance()
        {
            // -------
            // Arrange

            var model = new object();
            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.UpdateModel<object>(model); return null; });
            var actual = Outcome(() => { sut.UpdateModel<object>(model); return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void VerifyRenderingInServerForm_NoContext_MatchesInstance()
        {
            // -------
            // Arrange

            var control = new System.Web.UI.Control();
            var expectedInstance = new System.Web.UI.Page();
            var actualInstance = new System.Web.UI.Page();
            var sut = new PageWrap(actualInstance);

            // ---
            // Act

            var expected = Outcome(() => { expectedInstance.VerifyRenderingInServerForm(control); return null; });
            var actual = Outcome(() => { sut.VerifyRenderingInServerForm(control); return null; });

            // ------
            // Assert

            AssertSameOutcome(expected, actual);
        }
    }
}
