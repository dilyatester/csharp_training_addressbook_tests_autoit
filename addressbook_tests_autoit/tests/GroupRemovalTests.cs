using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_tests_autoit.tests
{
    [TestFixture]
    class GroupRemovalTests : TestBase
    {
        [Test]
        public void TestGroupRemoval()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            //Если групп меньше 2, то создадим группу
            if (oldGroups.Count < 2)
            {

                GroupData newGroup = new GroupData()
                {
                    Name = "testAuto"
                };

                app.Groups.Add(newGroup);

                oldGroups = app.Groups.GetGroupList();
            }

            //Удалим первую группу в списке
            app.Groups.Remove(0);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups); 
        }
    }
}
