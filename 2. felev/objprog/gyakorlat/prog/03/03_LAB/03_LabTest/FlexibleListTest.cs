using _03_LAB;
using Type = _03_LAB.Type;

namespace _03_LabTest
{
    [TestClass]
    public sealed class FlexibleListTest
    {
        [TestMethod]
        // SingleElement
        // NoElement
        // MultipleElement
        public void Add_SingleElement_StoreElementAtFirstIndex()
        {
             // Declaration
            FlexibleList list = new FlexibleList();
            FlexibleType element = new(0, _03_LAB.Type.Number);
            
            // Do
            list.Add(element);
            
            // Test
            Assert.AreEqual(element, list[0]);
        }

        [TestMethod]
        public void Search_NoCorrectElement_ReturnFalseNull()
        {
            FlexibleList list = new FlexibleList();
            FlexibleType element = new(0, _03_LAB.Type.Character);

            (bool found, FlexibleType? selected) = list.Search(_03_LAB.Type.Number);
            
            Assert.AreEqual((false, null), (found, selected));
        }

        [TestMethod]
        public void Search_SingleCorrectElement_ReturnsTrueElement()
        {
            FlexibleList list = new FlexibleList();
            FlexibleType element = new(0, _03_LAB.Type.Number);
            
            list.Add(element);

            (bool found, FlexibleType? selected) = list.Search(_03_LAB.Type.Number);
            
            Assert.AreEqual((true, element), (found, selected));
        }

        [TestMethod]
        public void Search_MultipleCorrectElement_ReturnsTrueFirstElement()
        {
            FlexibleList list = new FlexibleList();
            FlexibleType element = new(0, _03_LAB.Type.Number);
            FlexibleType second_element = new(1, _03_LAB.Type.Number);
            
            list.Add(element);
            list.Add(second_element);

            (bool found, FlexibleType? selected) = list.Search(_03_LAB.Type.Number);
            
            Assert.AreEqual((true, element), (found, selected));
        }
    }
}

