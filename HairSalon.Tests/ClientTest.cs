using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientTest : IDisposable
  {
    public ClientTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=hair_salon_test;";
    }

    [TestMethod]
    public void GetAll_GetAllClientsAtFirst_0()
    {
      int expected = 0;
      int actual = Client.GetAll().Count;

      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Save_SavesClientToDatabase_ClientList()
    {
      Client testClient = new Client("Sarah", 1);
      testClient.Save();

      List<Client> actual = Client.GetAll();
      List<Client> expected = new List<Client> {testClient};

      CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Find_FindsClientByIdInDatabase_Client()
    {
      Client expected = new Client("Raymond", 1);
      expected.Save();

      Client actual = Client.Find(expected.GetId());

      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void GetAll_ReturnAListOfAllClientsInStylist_ClientList()
    {
      Client client1 = new Client ("Buddy", 1);
      Client client2 = new Client ("Harry", 1);
      client1.Save();
      client2.Save();

      List<Client> expected = new List<Client> {client1, client2};
      List<Client> actual = Client.GetAll();

      CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Update_UpdatesClientNameInDatabase_Client()
    {
      Client testClient = new Client("Larry",1);
      Client testClient2 = new Client("John",2);
      testClient.Save();
      testClient2.Save();

      string newName = "David";
      testClient.Update(newName);

      string expected = newName;
      string actual = testClient.GetName();

      Assert.AreEqual(expected, actual);
    }

    public void Dispose()
    {
      Client.DeleteAll();
    }

  }
}
