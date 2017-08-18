using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Client
  {
    private int _id;
    private string _name;
    private int _cuisineId;

    public Client(string name, int stylistId, int id = 0)
    {
      _id = id;
      _name = name;
      _stylistId = stylistId;
    }
    
    public string GetName()
    {
      return _name;
    }
    public int GetId()
    {
      return _id;
    }
    public int GetStylistId()
    {
      return _stylistId;
    }

    public override bool Equals(Object otherClient)
    {
      if (!(otherClient is Client))
      {
        return false;
      }
      else
      {
        Client newClient = (Client) otherClient;

        bool idEquality = (this.GetId() == newClient.GetId());
        bool nameEquality = (this.GetName() == newClient.GetName());
        bool cuisineEquality = (this.GetStylistId() == newClient.GetStylistId());

        return (idEquality && nameEquality && StylistEquality);
      }
    }

    public override int GetHashCode()
    {
      return this.GetName().GetHashCode();
    }
  }
}
