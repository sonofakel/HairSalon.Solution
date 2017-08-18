using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Stylist
  {
    private int _id;
    private string _name;


    public Stylist(string name, int id = 0)
    {
      _name = name;
      _id = id;
    }

    public int GetId()
    {
      return _id;
    }
    public string GetName()
    {
      return _name;
    }

    public override bool Equals(System.Object otherObject)
    {
      if (!(otherObject is Stylist))
      {
        return false;
      }
      else
      {
        Stylist newStylist = (Stylist) otherObject;
        return this.GetId().Equals(newStylist.GetId());
      }
    }

    public override int GetHashCode()
    {
        return this.GetId().GetHashCode();
    }

    public static List<Stylist> GetAll()
    {
      List<Stylist> stylistList = new List<Stylist> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylists;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int stylistId = rdr.GetInt32(0);
        string stylistName = rdr.GetString(1);
        Stylist newStylist = new Stylist(stylistName, stylistId);
        stylistList.Add(newStylist);
      }
      conn.Close();
      return stylistList;
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO stylists (name) VALUES (@name);";

      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@name";
      name.Value = this._name;
      cmd.Parameters.Add(name);

      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
      conn.Close();
    }

    public static Stylist Find(int id)
  {
    MySqlConnection conn = DB.Connection();
    conn.Open();

    var cmd = conn.CreateCommand() as MySqlCommand;
    cmd.CommandText = @"SELECT * FROM stylists WHERE id = (@stylistId);";

    MySqlParameter searchId = new MySqlParameter();
    searchId.ParameterName = "@stylistId";
    searchId.Value = id;
    cmd.Parameters.Add(searchId);

    var rdr = cmd.ExecuteReader() as MySqlDataReader;
    int stylistId = 0;
    string stylistName = "";

    while(rdr.Read())
    {
      stylistId = rdr.GetInt32(0);
      stylistName = rdr.GetString(1);
    }
    Stylist foundStylist = new Stylist(stylistName, stylistId);
    conn.Close();
    return foundStylist;
  }

  public List<Client> SearchAllClients()
  {
    List<Client> newClientList = new List<Client>{};

    MySqlConnection conn = DB.Connection();
    conn.Open();

    var cmd = conn.CreateCommand() as MySqlCommand;
    cmd.CommandText = @"SELECT * FROM clients WHERE client_id = @thisId;";

    MySqlParameter searchId = new MySqlParameter();
    searchId.ParameterName = "@thisId";
    searchId.Value = _id;
    cmd.Parameters.Add(searchId);

    var rdr = cmd.ExecuteReader() as MySqlDataReader;

    while(rdr.Read())
    {
        int clientId = rdr.GetInt32(0);
        string clientName= rdr.GetString(1);
        int clientCuisineId = rdr.GetInt32(2);

        Client newClient = new Client(clientName, clientCuisineId, clientId);
        newClientList.Add(newClient);

    }
    conn.Close();
    return newClientList;
  }

  public static void DeleteAll()
  {
    MySqlConnection conn = DB.Connection();
    conn.Open();

    var cmd = conn.CreateCommand() as MySqlCommand;
    cmd.CommandText = @"DELETE FROM stylists;";
    cmd.ExecuteNonQuery();
    conn.Close();

  }

  }
}
