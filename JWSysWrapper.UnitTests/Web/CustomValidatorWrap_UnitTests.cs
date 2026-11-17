#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Web.UI.WebControls;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl.Web;

namespace JWWrap.UnitTests.Web
{
    // ----------------------------------------------------
    /// <summary>
    ///     CustomValidatorWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class CustomValidatorWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Default_CreatesValidator()
        {
            // ---
            // Act

            var sut = new CustomValidatorWrap();

            sut.Text = "x";

            // ------
            // Assert

            Assert.AreEqual("x", sut.Text);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ClientValidationFunction_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var validator = new CustomValidator();
            var sut = new CustomValidatorWrap(validator);

            // ---
            // Act

            sut.ClientValidationFunction = "check";

            // ------
            // Assert

            Assert.AreEqual("check", sut.ClientValidationFunction);
            Assert.AreEqual("check", validator.ClientValidationFunction);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ValidateEmptyText_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var validator = new CustomValidator();
            var sut = new CustomValidatorWrap(validator);

            // ---
            // Act

            sut.ValidateEmptyText = true;

            // ------
            // Assert

            Assert.AreEqual(true, sut.ValidateEmptyText);
            Assert.AreEqual(true, validator.ValidateEmptyText);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ID_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var validator = new CustomValidator();
            var sut = new CustomValidatorWrap(validator);

            // ---
            // Act

            sut.ID = "v1";

            // ------
            // Assert

            Assert.AreEqual("v1", sut.ID);
            Assert.AreEqual("v1", validator.ID);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Text_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var validator = new CustomValidator();
            var sut = new CustomValidatorWrap(validator);

            // ---
            // Act

            sut.Text = "text";

            // ------
            // Assert

            Assert.AreEqual("text", sut.Text);
            Assert.AreEqual("text", validator.Text);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IsValid_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var validator = new CustomValidator();
            var sut = new CustomValidatorWrap(validator);

            // ---
            // Act

            sut.IsValid = false;

            // ------
            // Assert

            Assert.AreEqual(false, sut.IsValid);
            Assert.AreEqual(false, validator.IsValid);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Enabled_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var validator = new CustomValidator();
            var sut = new CustomValidatorWrap(validator);

            // ---
            // Act

            sut.Enabled = false;

            // ------
            // Assert

            Assert.AreEqual(false, sut.Enabled);
            Assert.AreEqual(false, validator.Enabled);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ToolTip_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var validator = new CustomValidator();
            var sut = new CustomValidatorWrap(validator);

            // ---
            // Act

            sut.ToolTip = "tip";

            // ------
            // Assert

            Assert.AreEqual("tip", sut.ToolTip);
            Assert.AreEqual("tip", validator.ToolTip);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ErrorMessage_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var validator = new CustomValidator();
            var sut = new CustomValidatorWrap(validator);

            // ---
            // Act

            sut.ErrorMessage = "bad";

            // ------
            // Assert

            Assert.AreEqual("bad", sut.ErrorMessage);
            Assert.AreEqual("bad", validator.ErrorMessage);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SetFocusOnError_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var validator = new CustomValidator();
            var sut = new CustomValidatorWrap(validator);

            // ---
            // Act

            sut.SetFocusOnError = true;

            // ------
            // Assert

            Assert.AreEqual(true, sut.SetFocusOnError);
            Assert.AreEqual(true, validator.SetFocusOnError);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ValidationGroup_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var validator = new CustomValidator();
            var sut = new CustomValidatorWrap(validator);

            // ---
            // Act

            sut.ValidationGroup = "group";

            // ------
            // Assert

            Assert.AreEqual("group", sut.ValidationGroup);
            Assert.AreEqual("group", validator.ValidationGroup);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ControlToValidate_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var validator = new CustomValidator();
            var sut = new CustomValidatorWrap(validator);

            // ---
            // Act

            sut.ControlToValidate = "box";

            // ------
            // Assert

            Assert.AreEqual("box", sut.ControlToValidate);
            Assert.AreEqual("box", validator.ControlToValidate);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void EnableClientScript_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var validator = new CustomValidator();
            var sut = new CustomValidatorWrap(validator);

            // ---
            // Act

            sut.EnableClientScript = false;

            // ------
            // Assert

            Assert.AreEqual(false, sut.EnableClientScript);
            Assert.AreEqual(false, validator.EnableClientScript);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void AssociatedControlID_Set_IsNotSupported()
        {
            // -------
            // Arrange

            var validator = new CustomValidator();
            var sut = new CustomValidatorWrap(validator);

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<NotSupportedException>(() => sut.AssociatedControlID = "box");
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Parent_Standalone_IsNull()
        {
            // -------
            // Arrange

            var validator = new CustomValidator();
            var sut = new CustomValidatorWrap(validator);

            // ---
            // Act

            var result = sut.Parent;

            // ------
            // Assert

            Assert.IsNull(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void NamingContainer_Standalone_IsNull()
        {
            // -------
            // Arrange

            var validator = new CustomValidator();
            var sut = new CustomValidatorWrap(validator);

            // ---
            // Act

            var result = sut.NamingContainer;

            // ------
            // Assert

            Assert.IsNull(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Validate_Disabled_LeavesValid()
        {
            // -------
            // Arrange

            var validator = new CustomValidator();
            var sut = new CustomValidatorWrap(validator);

            sut.Enabled = false;
            sut.IsValid = false;

            // ---
            // Act

            sut.Validate();

            // ------
            // Assert

            Assert.IsTrue(sut.IsValid);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ImplicitToCustomValidator_Wrap_ReturnsValidator()
        {
            // -------
            // Arrange

            var validator = new CustomValidator();
            var sut = new CustomValidatorWrap(validator);

            // ---
            // Act

            CustomValidator result = sut;

            // ------
            // Assert

            Assert.AreSame(validator, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ImplicitFromCustomValidator_Validator_ReturnsWrap()
        {
            // -------
            // Arrange

            var validator = new CustomValidator { ID = "v1" };

            // ---
            // Act

            CustomValidatorWrap result = validator;

            // ------
            // Assert

            Assert.AreEqual("v1", result.ID);
        }
    }
}
