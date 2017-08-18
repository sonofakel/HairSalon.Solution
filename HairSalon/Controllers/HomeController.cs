using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View(Stylist.GetAll());
    }

    [HttpPost("/")]
    public ActionResult IndexPost()
    {
      string stylistName = Request.Form["stylist-name"];
      Stylist newStylist = new Stylist(stylistName);
      newStylist.Save();
      List<Stylist> allStylists = Stylist.GetAll();
      return View("Index", allStylists);
    }

    [HttpGet("/stylist-details/{id}")]
    public ActionResult StylistDetails(int id)
    {
      Stylist newStylist = Stylist.Find(id);

      return View(newStylist);
    }

    [HttpPost("/stylist-details/{id}")]
    public ActionResult StylistDetailsPost(int id)
    {
      Client newClient = new Client(Request.Form["client-name"], id);

      newClient.Save();

      return View("StylistDetails", Stylist.Find(id));
    }

    [HttpGet("/stylist-details/{stylistId}/edit/{clientId}")]
    public ActionResult ClientEdit(int stylistId, int clientId)
    {
      Dictionary<string,object> model = new Dictionary<string,object>{};
      Stylist myStylist = Stylist.Find(stylistId);
      Client myClient = Client.Find(clientId);

      model.Add("stylist", myStylist);
      model.Add("client", myClient);
      return View(model);
    }

    [HttpPost("/stylist-details/{stylistId}/client-edited/{clientId}")]
    public ActionResult ClientEdited(int stylistId, int clientId)
    {
      Client updatedClient = Client.Find(clientId);
      updatedClient.Update(Request.Form["updated-client"]);

      return View("StylistDetails", Stylist.Find(stylistId));
    }

    [HttpPost("/stylist-details/{stylistId}/deleted/{clientId}")]
    public ActionResult ClientDeleted(int stylistId, int clientId)
    {
      Client deletedClient = Client.Find(clientId);
      deletedClient.Delete();


      return View("StylistDetails", Stylist.Find(stylistId));
    }



  }
}
