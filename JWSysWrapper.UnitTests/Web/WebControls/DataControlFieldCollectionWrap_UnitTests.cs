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
    ///     DataControlFieldCollectionWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class DataControlFieldCollectionWrap_UnitTests
    {
        // ----------------------------------------------------

        [TestMethod]
        public void Add_Field_AddsToCollection()
        {
            // -------
            // Arrange

            var instance = new DataControlFieldCollection();
            var sut = new DataControlFieldCollectionWrap(instance);
            var field = new BoundField { HeaderText = "A" };

            // ---
            // Act

            sut.Add(field);

            // ------
            // Assert

            Assert.AreEqual(1, instance.Count);
            Assert.AreSame(field, instance[0]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Count_WithFields_ReturnsCount()
        {
            // -------
            // Arrange

            var instance = new DataControlFieldCollection();
            var sut = new DataControlFieldCollectionWrap(instance);
            var field = new BoundField { HeaderText = "A" };

            sut.Add(field);

            // ---
            // Act

            var result = sut.Count;

            // ------
            // Assert

            Assert.AreEqual(1, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Indexer_Index_ReturnsFieldWrap()
        {
            // -------
            // Arrange

            var instance = new DataControlFieldCollection();
            var sut = new DataControlFieldCollectionWrap(instance);
            var field = new BoundField { HeaderText = "A" };

            sut.Add(field);

            // ---
            // Act

            var result = sut[0];

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(DataControlFieldWrap));
            Assert.AreEqual("A", result.HeaderText);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Contains_Field_IsTrue()
        {
            // -------
            // Arrange

            var instance = new DataControlFieldCollection();
            var sut = new DataControlFieldCollectionWrap(instance);
            var field = new BoundField { HeaderText = "A" };

            sut.Add(field);

            // ---
            // Act

            var result = sut.Contains(field);

            // ------
            // Assert

            Assert.IsTrue(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Contains_Stranger_IsFalse()
        {
            // -------
            // Arrange

            var instance = new DataControlFieldCollection();
            var sut = new DataControlFieldCollectionWrap(instance);
            var field = new BoundField { HeaderText = "A" };

            // ---
            // Act

            var result = sut.Contains(field);

            // ------
            // Assert

            Assert.IsFalse(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IndexOf_Field_ReturnsIndex()
        {
            // -------
            // Arrange

            var instance = new DataControlFieldCollection();
            var sut = new DataControlFieldCollectionWrap(instance);
            var field = new BoundField { HeaderText = "A" };

            sut.Add(new BoundField());
            sut.Add(field);

            // ---
            // Act

            var result = sut.IndexOf(field);

            // ------
            // Assert

            Assert.AreEqual(1, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Insert_AtIndex_InsertsField()
        {
            // -------
            // Arrange

            var instance = new DataControlFieldCollection();
            var sut = new DataControlFieldCollectionWrap(instance);
            var field = new BoundField { HeaderText = "A" };

            sut.Add(new BoundField());

            // ---
            // Act

            sut.Insert(0, field);

            // ------
            // Assert

            Assert.AreSame(field, instance[0]);
            Assert.AreEqual(2, instance.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Remove_Field_RemovesField()
        {
            // -------
            // Arrange

            var instance = new DataControlFieldCollection();
            var sut = new DataControlFieldCollectionWrap(instance);
            var field = new BoundField { HeaderText = "A" };

            sut.Add(field);

            // ---
            // Act

            sut.Remove(field);

            // ------
            // Assert

            Assert.AreEqual(0, instance.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RemoveAt_Index_RemovesField()
        {
            // -------
            // Arrange

            var instance = new DataControlFieldCollection();
            var sut = new DataControlFieldCollectionWrap(instance);
            var field = new BoundField { HeaderText = "A" };

            sut.Add(field);

            // ---
            // Act

            sut.RemoveAt(0);

            // ------
            // Assert

            Assert.AreEqual(0, instance.Count);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CopyTo_Array_CopiesFields()
        {
            // -------
            // Arrange

            var instance = new DataControlFieldCollection();
            var sut = new DataControlFieldCollectionWrap(instance);
            var field = new BoundField { HeaderText = "A" };
            var array = new DataControlField[2];

            sut.Add(field);

            // ---
            // Act

            sut.CopyTo(array, 1);

            // ------
            // Assert

            Assert.IsNull(array[0]);
            Assert.AreSame(field, array[1]);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetEnumerator_Fields_EnumeratesFields()
        {
            // -------
            // Arrange

            var instance = new DataControlFieldCollection();
            var sut = new DataControlFieldCollectionWrap(instance);
            var field = new BoundField { HeaderText = "A" };

            sut.Add(field);

            // ---
            // Act

            var enumerator = sut.GetEnumerator();

            enumerator.MoveNext();

            // ------
            // Assert

            Assert.AreSame(field, enumerator.Current);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void CloneFields_WithFields_ReturnsClonedCollection()
        {
            // -------
            // Arrange

            var instance = new DataControlFieldCollection();
            var sut = new DataControlFieldCollectionWrap(instance);
            var field = new BoundField { HeaderText = "A" };

            sut.Add(field);

            // ---
            // Act

            var result = sut.CloneFields();

            // ------
            // Assert

            Assert.IsInstanceOfType(result, typeof(DataControlFieldCollectionWrap));
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("A", result[0].HeaderText);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ImplicitToCollection_Wrap_ReturnsCollection()
        {
            // -------
            // Arrange

            var instance = new DataControlFieldCollection();
            var sut = new DataControlFieldCollectionWrap(instance);
            var field = new BoundField { HeaderText = "A" };

            // ---
            // Act

            DataControlFieldCollection result = sut;

            // ------
            // Assert

            Assert.AreSame(instance, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void ImplicitFromCollection_Collection_ReturnsWrap()
        {
            // -------
            // Arrange

            var instance = new DataControlFieldCollection();
            var sut = new DataControlFieldCollectionWrap(instance);
            var field = new BoundField { HeaderText = "A" };

            instance.Add(field);

            // ---
            // Act

            DataControlFieldCollectionWrap result = instance;

            // ------
            // Assert

            Assert.AreEqual(1, result.Count);
        }
    }
}
