#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.Web.UI.WebControls;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl.Web.WebControls;

namespace JWWrap.UnitTests.Web.WebControls
{
    // ----------------------------------------------------
    /// <summary>
    ///     LinkButtonWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class LinkButtonWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void ValidationGroup_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var button = new LinkButton();
            var sut = new LinkButtonWrap(button);

            // ---
            // Act

            sut.ValidationGroup = "group";

            // ------
            // Assert

            Assert.AreEqual("group", sut.ValidationGroup);
            Assert.AreEqual("group", button.ValidationGroup);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void PostBackUrl_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var button = new LinkButton();
            var sut = new LinkButtonWrap(button);

            // ---
            // Act

            sut.PostBackUrl = "~/next.aspx";

            // ------
            // Assert

            Assert.AreEqual("~/next.aspx", sut.PostBackUrl);
            Assert.AreEqual("~/next.aspx", button.PostBackUrl);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Text_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var button = new LinkButton();
            var sut = new LinkButtonWrap(button);

            // ---
            // Act

            sut.Text = "Click";

            // ------
            // Assert

            Assert.AreEqual("Click", sut.Text);
            Assert.AreEqual("Click", button.Text);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void OnClientClick_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var button = new LinkButton();
            var sut = new LinkButtonWrap(button);

            // ---
            // Act

            sut.OnClientClick = "return false;";

            // ------
            // Assert

            Assert.AreEqual("return false;", sut.OnClientClick);
            Assert.AreEqual("return false;", button.OnClientClick);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CausesValidation_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var button = new LinkButton();
            var sut = new LinkButtonWrap(button);

            // ---
            // Act

            sut.CausesValidation = false;

            // ------
            // Assert

            Assert.AreEqual(false, sut.CausesValidation);
            Assert.AreEqual(false, button.CausesValidation);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CommandArgument_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var button = new LinkButton();
            var sut = new LinkButtonWrap(button);

            // ---
            // Act

            sut.CommandArgument = "arg";

            // ------
            // Assert

            Assert.AreEqual("arg", sut.CommandArgument);
            Assert.AreEqual("arg", button.CommandArgument);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CommandName_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var button = new LinkButton();
            var sut = new LinkButtonWrap(button);

            // ---
            // Act

            sut.CommandName = "cmd";

            // ------
            // Assert

            Assert.AreEqual("cmd", sut.CommandName);
            Assert.AreEqual("cmd", button.CommandName);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SupportsDisabledAttribute_Default_MatchesInstance()
        {
            // -------
            // Arrange

            var button = new LinkButton();
            var sut = new LinkButtonWrap(button);

            // ---
            // Act

            var result = sut.SupportsDisabledAttribute;

            // ------
            // Assert

            Assert.AreEqual(button.SupportsDisabledAttribute, result);
        }
    }
}
