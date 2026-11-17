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
    }
}
