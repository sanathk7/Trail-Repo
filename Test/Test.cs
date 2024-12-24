using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace RegistrationTests
{
    [Allure.NUnit.AllureNUnit]
    internal class Test
    {
        [Test, TestCaseSource(nameof(GetManagerTestData))]
        public void ManagerTest(string manager, string password)
        {
            bool isLoginSuccessful = VerifyLogin(manager, password, isManager: true);
            Assert.IsTrue(isLoginSuccessful, $"Manager login failed for user: {manager}");
            Console.WriteLine($"Login Success for Manager: {manager}");
        }

        public static IEnumerable<TestCaseData> GetManagerTestData()
        {
            yield return new TestCaseData("Sanath", "Sanath");
            
        }

        [Test, TestCaseSource(nameof(GetCustomerTestData))]
        public void CustomerLogin(string customer, string password)
        {
            bool isLoginSuccessful = VerifyLogin(customer, password, isManager: false);
            Assert.IsTrue(isLoginSuccessful, $"Customer login failed for user: {customer}");
            Console.WriteLine($"Login Success for Customer: {customer}");
        }

        public static IEnumerable<TestCaseData> GetCustomerTestData()
        {
            yield return new TestCaseData("Shravya", "121");
           
        }

        private bool VerifyLogin(string username, string password, bool isManager)
        {
            var managerAccounts = new Dictionary<string, string>
            {
                { "Sanath", "Sanath" }
                
            };

            var customerAccounts = new Dictionary<string, string>
            {
                { "Shravya", "121" }
               
            };

            if (isManager)
            {
                return managerAccounts.ContainsKey(username) && managerAccounts[username] == password;
            }
            else
            {
                return customerAccounts.ContainsKey(username) && customerAccounts[username] == password;
            }
        }
    }
}
