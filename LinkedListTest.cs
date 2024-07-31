using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment3.Utility;
using Assignment3.ProblemDomain;

namespace Assignment3.Tests
{
    public class LinkedListTest
    {
        private ILinkedListADT users;

        [SetUp]
        public void Setup()
        {
            users = new SLL();
        }

        [Test]
        public void TestIsEmpty()
        {
            Assert.IsTrue(users.IsEmpty());
        }

        [Test]
        public void TestAddFirst()
        {
            User user = new User(1, "First User", "first.user@example.com", "password1");
            users.AddFirst(user);
            Assert.AreEqual(1, users.Count());
            Assert.AreEqual(user, users.GetValue(0));
        }

        [Test]
        public void TestAddLast()
        {
            User user = new User(2, "Last User", "last.user@example.com", "password2");
            users.AddLast(user);
            Assert.AreEqual(1, users.Count());
            Assert.AreEqual(user, users.GetValue(0));
        }

        [Test]
        public void TestAddAtIndex()
        {
            User user1 = new User(1, "First User", "first.user@example.com", "password1");
            User user2 = new User(2, "Second User", "second.user@example.com", "password2");
            users.AddLast(user1);
            users.Add(user2, 1);
            Assert.AreEqual(2, users.Count());
            Assert.AreEqual(user1, users.GetValue(0));
            Assert.AreEqual(user2, users.GetValue(1));
        }

        [Test]
        public void TestReplace()
        {
            User user1 = new User(1, "First User", "first.user@example.com", "password1");
            User user2 = new User(2, "Replaced User", "replaced.user@example.com", "password2");
            users.AddLast(user1);
            users.Replace(user2, 0);
            Assert.AreEqual(1, users.Count());
            Assert.AreEqual(user2, users.GetValue(0));
        }

        [Test]
        public void TestRemoveFirst()
        {
            User user = new User(1, "First User", "first.user@example.com", "password1");
            users.AddFirst(user);
            users.RemoveFirst();
            Assert.IsTrue(users.IsEmpty());
        }

        [Test]
        public void TestRemoveLast()
        {
            User user = new User(1, "Last User", "last.user@example.com", "password1");
            users.AddLast(user);
            users.RemoveLast();
            Assert.IsTrue(users.IsEmpty());
        }

        [Test]
        public void TestRemoveAtIndex()
        {
            User user1 = new User(1, "First User", "first.user@example.com", "password1");
            User user2 = new User(2, "Second User", "second.user@example.com", "password2");
            User user3 = new User(3, "Third User", "third.user@example.com", "password3");
            users.AddLast(user1);
            users.AddLast(user2);
            users.AddLast(user3);
            users.Remove(1);
            Assert.AreEqual(2, users.Count());
            Assert.AreEqual(user1, users.GetValue(0));
            Assert.AreEqual(user3, users.GetValue(1));
        }

        [Test]
        public void TestFindAndRetrieve()
        {
            User user = new User(1, "Test User", "test.user@example.com", "password1");
            users.AddLast(user);
            int index = users.IndexOf(user);
            Assert.AreEqual(0, index);
            Assert.AreEqual(user, users.GetValue(index));
        }

        [Test]
        public void TestContains()
        {
            User user = new User(1, "Test User", "test.user@example.com", "password1");
            users.AddLast(user);
            Assert.IsTrue(users.Contains(user));
        }
    }
}
