using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KomodoBadges_Repository;
using System.Collections.Generic;

namespace KomodoBadges_Tests
{
    [TestClass]
    public class BadgesTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            BadgesRepository MyBadges = new BadgesRepository();
            bool check = MyBadges.CheckKey(100);
            Dictionary<int, List<string>> Check = new Dictionary<int, List<string>>();
            List<string> m = new List<string>();

            Assert.AreEqual(true,check);
        }
    }
}
