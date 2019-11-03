using NUnit.Framework;
using SimulationLibrary;

namespace SimulationTests
{
    public class Tests
    {
        [Test]
        public void TestAdultName_IsNotNull()
        {
            Adult adult = new Adult();

            Assert.IsNotNull(adult.Name);
        }

        [Test]
        public void TestAdultCountOfChildren_Works()
        {
            Adult adult1 = new Adult();
            Adult adult2 = new Adult();

            Couple.MakeCouple(adult1, adult2, 1);
            Couple.MakeChild(adult1, 1);
            Couple.MakeChild(adult1, 1);

            Assert.IsTrue(adult1.CountOfChildren() == 2 && adult2.CountOfChildren() == 2);
        }

        [Test]
        public void TestAdultCountOfChildren_WorksWithMultipleGenerations()
        {
            Adult adult1 = new Adult();
            Adult adult2 = new Adult();

            Couple.MakeCouple(adult1, adult2, 1);
            Human human1 = Couple.MakeChild(adult1, 1);
            Human human2 = Couple.MakeChild(adult1, 1);

            human1 = new Adult((Child)human1);
            human2 = new Adult((Child)human2);

            Couple.MakeCouple((Adult)human1, (Adult)human2, 1);
            Couple.MakeChild((Adult)human1, 1);
            Couple.MakeChild((Adult)human1, 1);

            Assert.IsTrue(adult1.CountOfChildren() == 4 && adult2.CountOfChildren() == 4);
        }

        [Test]
        public void TestHumanOccupation_PaysMoney()
        {
            Human human1 = new Adult();
            Human human2 = new Child();

            human1.GetOccupation(1);
            human1.Occupation.GetSalary(human1);

            human2.GetOccupation(1);
            human2.Occupation.GetSalary(human2);

            Assert.IsTrue(human1.Balance > 0 && human2.Balance > 0);
        }

        [Test]
        public void TestChildName_IsNotNull()
        {
            Child child = new Child();

            Assert.IsNotNull(child.Name);
        }

        [Test]
        public void TestCouple_MakeCouple_Works()
        {
            Adult adult1 = new Adult();
            Adult adult2 = new Adult();

            Couple.MakeCouple(adult1, adult2, 1);

            Assert.IsTrue((adult1.Partner == adult2 && adult1.HasPartner) &&  (adult2.Partner == adult1 && adult2.HasPartner));
        }

        [Test]
        public void TestCouple_BreakUp_Works()
        {
            Adult adult1 = new Adult();
            Adult adult2 = new Adult();

            Couple.MakeCouple(adult1, adult2, 1);
            Couple.BreakUp(adult1);

            Assert.IsTrue((adult1.Partner == null && !adult1.HasPartner) && (adult2.Partner == null && !adult2.HasPartner));
        }

        [Test]
        public void TestCouple_MakeChild_ReturnsChild()
        {
            Adult adult1 = new Adult();
            Adult adult2 = new Adult();

            Couple.MakeCouple(adult1, adult2, 1);
            var human = Couple.MakeChild(adult1, 1);

            Assert.IsTrue(human.GetType() == typeof(Child));

        }

        [Test]
        public void TestCouple_MakeChild_ReturnsNull_WhenHasPartner_IsFalse()
        {
            Adult adult = new Adult();

            var human = Couple.MakeChild(adult, 1);

            Assert.IsNull(human);
        }

        [Test]
        public void TestCouple_CantMakeCouple_WithThemselves()
        {
            Adult adult = new Adult();

            Couple.MakeCouple(adult, adult, 1);

            Assert.IsNull(adult.Partner);
        }

        [Test]
        public void TestCouple_CantMakeCouple_WithAlreadyCoupleAdult()
        {
            Adult adult1 = new Adult();
            Adult adult2 = new Adult();
            Adult adult3 = new Adult();


            Couple.MakeCouple(adult1, adult2, 1);
            Couple.MakeCouple(adult3, adult1, 1);

            Assert.IsNull(adult3.Partner);
        }

        [Test]
        public void TestMakingChild_Adult_KeepsName()
        {
            Human human = new Child();
            string childName = human.Name;

            human = new Adult((Child)human);
            string adultName = human.Name;

            Assert.AreEqual(childName, adultName);
        }

        [Test]
        public void TestMakingChild_Adult_KeepsBalance()
        {
            Human human = new Child();
            
            human.GetOccupation(1);
            human.Occupation.GetSalary(human);
            int childBalance = human.Balance;

            human = new Adult((Child)human);
            int adultBalance = human.Balance;

            Assert.AreEqual(childBalance, adultBalance);
        }

        [Test]
        public void TestChild_CountOfChildren_ReturnsZero()
        {
            Child child = new Child();

            Assert.AreEqual(child.CountOfChildren(), 0);
        }

        [Test]
        public void TestChild_GetOccupation()
        {
            Child child = new Child();

            child.GetOccupation(1);

            Assert.IsTrue(child.Occupation.Name == "Student");
        }

        [Test]
        public void TestHuman_BuyFood_DecreasesBalance()
        {
            Human human = new Adult();
            human.GetOccupation(1);
            human.Occupation.GetSalary(human);
            int tempBalance = human.Balance;

            human.BuyFood();

            Assert.IsTrue(human.Balance < tempBalance);
        }

        [Test]
        public void TestHuman_EatFood_IncreasesHunger()
        {
            Human human = new Adult();

            human.GetOccupation(1);
            human.Occupation.GetSalary(human);

            human.ReduceHunger(50);
            human.BuyFood();
            human.EatFood();

            Assert.IsTrue(human.Hunger > 50);

        }

        [Test]
        public void TestHuman_EatFood_DoesNotIncreaseHunger_WithoutFood()
        {
            Human human = new Adult();

            human.ReduceHunger(50);
            human.EatFood();

            Assert.IsTrue(human.Hunger == 50);
        }
    }
}