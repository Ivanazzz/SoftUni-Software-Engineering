namespace DatabaseExtended.Tests
{
    using System;
    using System.Collections.Generic;

    using ExtendedDatabase;
    using NUnit.Framework;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [TestCaseSource("TestCaseConstructorData")]
        public void Constructor_ShouldCreate_Database_PositiveTest(Person[] people, int expectedCount)
        {
            Database database = new Database(people);

            Assert.AreEqual(expectedCount, database.Count);
        }

        [TestCaseSource("TestCaseAddData")]
        public void Add_ShouldAdd_Database_PositiveTest(Person[] peopleCtor, Person[] peopleAdd, int expectedCount)
        {
            Database database = new Database(peopleCtor);

            foreach (var person in peopleAdd)
            {
                database.Add(person);
            }

            Assert.AreEqual(expectedCount, database.Count);
        }

        [TestCaseSource("TestCaseAddInvalidData")]
        public void Add_ShouldThrowException_WithInvalidData_NegativeTest(Person[] peopleCtor, Person[] peopleAdd, Person invalidPerson)
        {
            Database database = new Database(peopleCtor);

            foreach (var person in peopleAdd)
            {
                database.Add(person);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(invalidPerson);
            });
        }

        [TestCaseSource("TestCaseRemoveData")]
        public void Remove_ShouldRemove_WithValidData_PositiveTest(Person[] peopleCtor, Person[] peopleAdd, int toRemove, int expectedCount)
        {
            Database database = new Database(peopleCtor);

            foreach (var person in peopleAdd)
            {
                database.Add(person);
            }

            for (int i = 0; i < toRemove; i++)
            {
                database.Remove();
            }

            Assert.AreEqual(expectedCount, database.Count);
        }

        [Test]
        public void Remove_ShouldThrowException_WithZeroData_NegativeTest()
        {
            Database database = new Database();

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            });
        }

        [Test]
        public void FindByUsername_ShouldSuccess_WithValidData_PositiveTest()
        {
            Database database = new Database();
            Person person1 = new Person(1, "Ivan");
            Person person2 = new Person(2, "David");

            database.Add(person1);
            database.Add(person2);

            Person foundPerson = database.FindByUsername(person2.UserName);

            Assert.AreEqual(person2, foundPerson);
        }

        [TestCaseSource("TestCaseFindByUsernameInvalidData")]
        public void FindByUsername_ShouldThrowException_WithInvalidData_NegativeTest(Person[] peopleCtor, string name)
        {
            Database database = new Database(peopleCtor);

            Assert.Throws<ArgumentNullException>(() =>
            {
                database.FindByUsername(name);
            });
        }

        [Test]
        public void FindByUsername_ShouldThrowException_WithMissingPerson_NegativeTest()
        {
            Database database = new Database();
            Person person = new Person(1, "Ivan");

            string name = "Peter";

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindByUsername(name);
            });
        }

        [Test]
        public void FindByID_ShouldSuccess_WithValidData_PositiveTest()
        {
            Database database = new Database();
            Person person1 = new Person(1, "Ivan");
            Person person2 = new Person(2, "David");

            database.Add(person1);
            database.Add(person2);

            Person foundPerson = database.FindById(person2.Id);

            Assert.AreEqual(person2, foundPerson);
        }

        [TestCaseSource("TestCaseFindByIDNegativeData")]
        public void FindByID_ShouldThrowException_WithNegativeData_NegativeTest(Person[] peopleCtor, long id)
        {
            Database database = new Database(peopleCtor);

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                database.FindById(id);
            });
        }

        [Test]
        public void FindByID_ShouldThrowException_WithMissingID_NegativeTest()
        {
            Database database = new Database();
            Person person = new Person(1, "Ivan");

            long id = 13;

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindById(id);
            });
        }

        public static IEnumerable<TestCaseData> TestCaseConstructorData()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "Ivan"),
                        new Person(2, "Peter"),
                        new Person(3, "Kiril"),
                    },
                    3),
                new TestCaseData(
                    new Person[]
                    {
                    },
                    0),
            };

            foreach (var testCase in testCases)
            {
                yield return testCase;
            }
        }

        public static IEnumerable<TestCaseData> TestCaseAddData()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "Ivan"),
                        new Person(2, "Peter"),
                        new Person(3, "Kiril"),
                    },
                    new Person[]
                    {
                        new Person(4, "Martin"),
                        new Person(5, "Boris"),
                        new Person(6, "Pavel"),
                    },
                    6),
                new TestCaseData(
                    new Person[]
                    {
                    },
                    new Person[]
                    {
                        new Person(1, "Ivan"),
                        new Person(2, "Peter"),
                        new Person(3, "Kiril"),
                    },
                    3),
            };

            foreach (var testCase in testCases)
            {
                yield return testCase;
            }
        }

        public static IEnumerable<TestCaseData> TestCaseAddInvalidData()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "Ivan"),
                        new Person(2, "Peter"),
                        new Person(3, "Kiril"),
                        new Person(4, "Pavel"),
                        new Person(5, "Stanislav"),
                        new Person(6, "David"),
                        new Person(7, "Miroslav"),
                        new Person(8, "Svetlin"),
                        new Person(9, "Nikolay"),
                        new Person(10, "Victor"),
                        new Person(11, "Ioan"),
                        new Person(12, "Alex"),
                        new Person(13, "Martin"),
                    },
                    new Person[]
                    {
                        new Person(14, "Boris"),
                        new Person(15, "Stiliyan"),
                        new Person(16, "Manoil"),
                    },
                    new Person(17, "Ivaylo")),
                new TestCaseData(
                    new Person[]
                    {
                    },
                    new Person[]
                    {
                        new Person(1, "Ivan"),
                        new Person(2, "Peter"),
                        new Person(3, "Kiril"),
                    },
                    new Person(17, "Kiril")),
                new TestCaseData(
                    new Person[]
                    {
                    },
                    new Person[]
                    {
                        new Person(1, "Ivan"),
                        new Person(2, "Peter"),
                        new Person(3, "Kiril"),
                    },
                    new Person(3, "Ivaylo")),
            };

            foreach (var testCase in testCases)
            {
                yield return testCase;
            }
        }

        public static IEnumerable<TestCaseData> TestCaseRemoveData()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "Ivan"),
                        new Person(2, "Peter"),
                        new Person(3, "Kiril"),
                    },
                    new Person[]
                    {
                        new Person(4, "Martin"),
                        new Person(5, "Pavel"),
                        new Person(6, "Atanas"),
                    },
                    3,
                    3),
            };

            foreach (var testCase in testCases)
            {
                yield return testCase;
            }
        }

        public static IEnumerable<TestCaseData> TestCaseFindByUsernameInvalidData()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "Ivan"),
                        new Person(2, "Peter"),
                    },
                    null),
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "Ivan"),
                        new Person(2, "Peter"),
                    },
                    string.Empty),
            };

            foreach (var testCase in testCases)
            {
                yield return testCase;
            }
        }

        public static IEnumerable<TestCaseData> TestCaseFindByIDNegativeData()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "Ivan"),
                        new Person(2, "Peter"),
                    },
                    -1),
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "Ivan"),
                        new Person(2, "Peter"),
                    },
                    -200),
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "Ivan"),
                        new Person(2, "Peter"),
                    },
                    long.MinValue),
            };

            foreach (var testCase in testCases)
            {
                yield return testCase;
            }
        }
    }
}